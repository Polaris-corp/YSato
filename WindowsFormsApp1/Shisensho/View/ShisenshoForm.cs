using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Shisensho
{
    public partial class ShisenshoForm : Form
    {
        #region 変数宣言
        public class Coordinate
        {
            public Coordinate(int r = 0, int c = 0, int d = 0)
            {
                row = r;
                col = c;
                dir = d;
            }
            public int row { get; set; }
            public int col { get; set; }
            public int dir { get; set; }
        }

        public ShisenshoForm()
        {
            InitializeComponent();
            buttons = new Button[MaxRow + 2, MaxCol + 2];
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            TileColor tileColor = new TileColor();
            tilePairs = tileColor.TilePairs;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Tick += new EventHandler(TimerMethod);
        }

        int MaxRow = 8;
        int MaxCol = 17;
        int DeletedPairs = 0;
        int ClearPairs = 68;
        int WhoTurn = 0;
        TimeSpan PenaltyTime = new TimeSpan();

        Button[,] buttons;
        Button firstTimeClickButton;
        bool iSFirstTimeClick = true;
        Dictionary<string, Color> tilePairs;
        Dictionary<string, List<Coordinate>> CoordinatePairs = new Dictionary<string, List<Coordinate>>();
        List<Coordinate> hintList = new List<Coordinate>();

        Stopwatch stopwatch = new Stopwatch();
        DispatcherTimer timer = new DispatcherTimer();
        List<string> textItem = new List<string>();

        #endregion

        #region 初期設定
        private void textItem_set()
        {
            for (int i = 0; i < 9; i++)
            {
                textItem.Add(((char)('①' + i)).ToString());
                textItem.Add(((char)('Ⅰ' + i)).ToString());
            }
            textItem.Add("一");
            textItem.Add("二");
            textItem.Add("三");
            textItem.Add("四");
            textItem.Add("五");
            textItem.Add("六");
            textItem.Add("七");
            textItem.Add("八");
            textItem.Add("九");
            textItem.Add("東");
            textItem.Add("南");
            textItem.Add("西");
            textItem.Add("北");
            textItem.Add("白");
            textItem.Add("發");
            textItem.Add("中");
            textItem = textItem.Concat(textItem).ToList();
        }

        private void button_set()
        {
            for (int i = 0; i < MaxRow + 2; i++)
            {
                for (int j = 0; j < MaxCol + 2; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Location = new Point(60 * j, 76 * i);
                    buttons[i, j].Tag = new Point(j, i);
                    buttons[i, j].Name = "btn" + i + "-" + j;
                    buttons[i, j].Size = new Size(60, 76);
                    buttons[i, j].BackColor = Color.White;
                    buttons[i, j].TabIndex = 0;
                    buttons[i, j].Text = "";
                    buttons[i, j].TabStop = false;
                    buttons[i, j].Font = new Font("Meiryo UI", 20);
                    buttons[i, j].Click += new EventHandler(this.button_Click);

                    if (i == 0 || i == MaxRow + 1 || j == 0 || j == MaxCol + 1)
                    {
                        buttons[i, j].Visible = false;
                    }
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void buttonText_set(List<string> item)
        {
            int ind = 0;
            CoordinatePairs.Clear();
            for (int i = 1; i <= MaxRow; i++)
            {
                for (int j = 1; j <= MaxCol; j++)
                {
                    if (!buttons[i, j].Visible)
                    {
                        continue;
                    }

                    buttons[i, j].Text = item[ind];

                    if (item[ind] == "")
                    {
                        ind++;
                        buttons[i, j].Visible = false;
                        continue;
                    }

                    buttons[i, j].ForeColor = tilePairs[buttons[i, j].Text];

                    string t = buttons[i, j].Text;
                    if (CoordinatePairs.ContainsKey(t))
                    {
                        CoordinatePairs[t].Add(new Coordinate(i, j));
                    }
                    else
                    {
                        CoordinatePairs.Add(t, new List<Coordinate>() { new Coordinate(i, j) });
                    }

                    ind++;
                }
            }
        }

        private List<string> ShuffleList(List<string> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        private void ChangeTileVisible(bool val)
        {
            for (int i = 1; i <= MaxRow; i++)
            {
                for (int j = 1; j <= MaxCol; j++)
                {
                    buttons[i, j].Visible = val;
                }
            }
        }

        private void ClearHintList()
        {
            foreach (var item in hintList)
            {
                buttons[item.row, item.col].BackColor = Color.White;
            }
            hintList.Clear();
        }

        private void SetNewTimer()
        {
            stopwatch.Start();
            timer.Start();
        }

        private void ClearTimer()
        {
            lblTimer.Text = "";
            stopwatch.Reset();
        }

        private void StopTimer()
        {
            stopwatch.Stop();
            timer.Stop();
        }

        private string WhoTurnNow()
        {
            return "Player" + (WhoTurn % int.Parse(txtPlayerCount.Text) + 1) + "の番です。";
        }

        #endregion

        #region イベント
        private void Form1_Load(object sender, EventArgs e)
        {
            button_set();
            textItem_set();
            var list = new List<string>(textItem.Concat(textItem).ToList());
            buttonText_set(ShuffleList(list));
            stopwatch.Reset();
            SetNewTimer();
            lblMessageOrder.Text = WhoTurnNow();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button; // クリックされたボタンを取得

            if (iSFirstTimeClick)
            {
                firstTimeClickButton = clickedButton;
                firstTimeClickButton.BackColor = Color.Yellow;
                hintList.Add(GetCoordinate(firstTimeClickButton));
            }
            else
            {
                ClearHintList();
                if (clickedButton != firstTimeClickButton && TileCheck(firstTimeClickButton, clickedButton))
                {
                    // クリックされたボタンを非表示にする
                    clickedButton.Visible = false;
                    firstTimeClickButton.Visible = false;
                    DeletedPairs++;
                    WhoTurn++;
                    lblMessageOrder.Text = WhoTurnNow();

                    if (DeletedPairs == ClearPairs)
                    {
                        StopTimer();
                        btnHint.Enabled = false;
                        ShisenshoRankingForm result = new ShisenshoRankingForm(lblTimer.Text, rbtNormalMode.Checked);
                        result.StartPosition = FormStartPosition.CenterParent;
                        result.ShowDialog();
                    }
                }
                else
                {
                    firstTimeClickButton = null;
                }
            }
            iSFirstTimeClick = !iSFirstTimeClick;

        }

        private void reStartButton_Click(object sender, EventArgs e)
        {
            ClearHintList();
            firstTimeClickButton = null;
            iSFirstTimeClick = true;
            btnHint.Enabled = true;
            DeletedPairs = 0;
            PenaltyTime = new TimeSpan();
            ChangeTileVisible(false);
            var list = new List<string>(textItem);
            if (rbtNormalMode.Checked)
            {
                list = list.Concat(textItem).ToList();
                MaxRow = 8;
                ClearPairs = 68;
            }
            else
            {
                list = list.Concat(Enumerable.Repeat("", 68)).ToList();
                ClearPairs = 34;
            }
            ChangeTileVisible(true);
            buttonText_set(ShuffleList(list));
            ClearTimer();
            SetNewTimer();
        }

        private void btnHint_Click(object sender, EventArgs e)
        {
            ClearHintList();
            firstTimeClickButton = null;
            iSFirstTimeClick = true;
            PenaltyTime += TimeSpan.FromSeconds(10);

            foreach (var item in CoordinatePairs)
            {
                for (int i = 0; i < item.Value.Count; i++)
                {
                    Coordinate xy1 = item.Value[i];
                    if (!buttons[xy1.row, xy1.col].Visible)
                    {
                        continue;
                    }
                    for (int j = i + 1; j < item.Value.Count; j++)
                    {

                        Coordinate xy2 = item.Value[j];
                        if (!buttons[xy2.row, xy2.col].Visible)
                        {
                            continue;
                        }
                        if (TileCheck(buttons[xy1.row, xy1.col], buttons[xy2.row, xy2.col]))
                        {

                            buttons[xy1.row, xy1.col].BackColor = Color.Yellow;
                            buttons[xy2.row, xy2.col].BackColor = Color.Yellow;
                            hintList.Add(xy1);
                            hintList.Add(xy2);
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("これ以上消せる組み合わせはありません。\r\n再配置します。");
            buttonText_set(ShuffleList(GetTilesList()));
        }

        private void TimerMethod(object sender, EventArgs e)
        {
            lblTimer.Text = TimeSpanToString(stopwatch.Elapsed + PenaltyTime);
        }

        #endregion

        #region 値取得関数

        /// <summary>
        /// 座標取得メソッド
        /// </summary>
        /// <param name="button">座標を取得したいボタン</param>
        /// <returns>引数のボタンの座標</returns>
        private Coordinate GetCoordinate(Button button)
        {
            Point xy = (Point)button.Tag;
            return new Coordinate(xy.Y, xy.X);
        }

        /// <summary>
        /// DateTime型をstring型(年月日)へ変換するメソッド
        /// </summary>
        /// <param name="date">DateTime型変数</param>
        /// <returns>string型の年月日</returns>
        private string YYYYMMDDToString(DateTime date)
        {
            return date.Year.ToString("0000") + "/" + date.Month.ToString("00") + "/" + date.Day.ToString("00");
        }

        /// <summary>
        /// TimeSpan型をstring型(HH:MM:SS)へ変換するメソッド
        /// </summary>
        /// <param name="span">TimeSpan型変数</param>
        /// <returns>string型の時間(HH:MM:SS)</returns>
        private string TimeSpanToString(TimeSpan span)
        {
            return span.Hours.ToString("00") + ":" + span.Minutes.ToString("00") + ":" + span.Seconds.ToString("00");
        }

        /// <summary>
        /// 図柄リスト取得メソッド
        /// </summary>
        /// <returns>図柄のリスト</returns>
        private List<string> GetTilesList()
        {
            List<string> list = new List<string>();
            for (int i = 1; i <= MaxRow; i++)
            {
                for (int j = 1; j <= MaxCol; j++)
                {
                    if (buttons[i, j].Visible)
                    {
                        list.Add(buttons[i, j].Text);
                    }
                }
            }
            return list;
        }

        #endregion

        #region チェック関数

        /// <summary>
        /// 図柄チェックメソッド
        /// </summary>
        /// <param name="firstClickButton">一回目に押されたボタン</param>
        /// <param name="secondClickButton">二回目に押されたボタン</param>
        /// <returns>二角で取れるかどうかの真偽値</returns>
        private bool TileCheck(Button firstClickButton, Button secondClickButton)
        {
            if (firstClickButton.Text != secondClickButton.Text)
            {
                return false;
            }
            Coordinate xy1 = GetCoordinate(firstClickButton);
            Coordinate xy2 = GetCoordinate(secondClickButton);

            return BFS(xy1, xy2);
        }

        /// <summary>
        /// 幅優先探索を用いた図柄チェックメソッド
        /// </summary>
        /// <param name="xy1">ボタンの座標</param>
        /// <param name="xy2">ボタンの座標</param>
        /// <returns>二角で繋げられるかの真偽値</returns>
        private bool BFS(Coordinate xy1, Coordinate xy2)
        {
            int[] dx = new int[] { 1, 0, -1, 0 };
            int[] dy = new int[] { 0, -1, 0, 1 };
            List<List<List<int>>> cost = new List<List<List<int>>>();
            for (int i = 0; i <= MaxRow + 1; i++)
            {
                cost.Add(new List<List<int>>());
                for (int j = 0; j <= MaxCol + 1; j++)
                {
                    cost[i].Add(new List<int>());
                    for (int k = 0; k < 4; k++)
                    {
                        cost[i][j].Add(int.MaxValue);
                    }
                }
            }
            cost[xy1.row][xy1.col][0] = 0;
            cost[xy1.row][xy1.col][1] = 0;
            cost[xy1.row][xy1.col][2] = 0;
            cost[xy1.row][xy1.col][3] = 0;


            Queue<Coordinate> q = new Queue<Coordinate>();
            q.Enqueue(new Coordinate(xy1.row, xy1.col, 0));
            q.Enqueue(new Coordinate(xy1.row, xy1.col, 1));
            q.Enqueue(new Coordinate(xy1.row, xy1.col, 2));
            q.Enqueue(new Coordinate(xy1.row, xy1.col, 3));
            while (q.Any())
            {
                Coordinate p = q.Dequeue();
                if (p.row == xy2.row && p.col == xy2.col)
                {
                    return true;
                }
                if (buttons[p.row, p.col].Visible)
                {
                    if (!(p.row == xy1.row && p.col == xy1.col))
                    {
                        continue;
                    }
                }
                int ldir = (p.dir + 1) % 4;
                if (cost[p.row][p.col][p.dir] + 1 < cost[p.row][p.col][ldir] && cost[p.row][p.col][p.dir] + 1 < 3)
                {
                    q.Enqueue(new Coordinate(p.row, p.col, ldir));
                    cost[p.row][p.col][ldir] = cost[p.row][p.col][p.dir] + 1;
                }
                int rdir = (p.dir + 3) % 4;
                if (cost[p.row][p.col][p.dir] + 1 < cost[p.row][p.col][rdir] && cost[p.row][p.col][p.dir] + 1 < 3)
                {
                    q.Enqueue(new Coordinate(p.row, p.col, rdir));
                    cost[p.row][p.col][rdir] = cost[p.row][p.col][p.dir] + 1;
                }

                int ty = p.row + dy[p.dir];
                int tx = p.col + dx[p.dir];
                int tc = cost[p.row][p.col][p.dir];
                if (MaxRow + 2 <= ty || ty < 0 || MaxCol + 2 <= tx || tx < 0 || 2 < tc)
                {
                    continue;
                }
                q.Enqueue(new Coordinate(ty, tx, p.dir));
                cost[ty][tx][p.dir] = tc;
            }
            return false;
        }

        #endregion

    }
}