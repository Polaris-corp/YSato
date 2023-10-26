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
    public partial class Shisensho : Form
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

        public Shisensho()
        {
            InitializeComponent();
            buttons = new Button[maxrow + 2, maxcol + 2];
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            TileColor tileColor = new TileColor();
            tilePairs = tileColor.TilePairs;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += new EventHandler(TimerMethod);
        }

        int maxrow = 8;
        int maxcol = 17;
        int DeletedPairs = 0;

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
            textItem = textItem.Concat(textItem).Concat(textItem).Concat(textItem).ToList();

        }

        private void button_set()
        {
            for (int i = 0; i < maxrow + 2; i++)
            {
                for (int j = 0; j < maxcol + 2; j++)
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

                    if (i == 0 || i == maxrow + 1 || j == 0 || j == maxcol + 1)
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
            for (int i = 1; i <= maxrow; i++)
            {
                for (int j = 1; j <= maxcol; j++)
                {
                    if (!buttons[i, j].Visible)
                    {
                        continue;
                    }
                    buttons[i, j].Text = item[ind];
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

        private void ChangeTileVisible()
        {
            for (int i = 1; i <= maxrow; i++)
            {
                for (int j = 1; j <= maxcol; j++)
                {
                    buttons[i, j].Visible = true;
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

        #endregion

        #region イベント
        private void Form1_Load(object sender, EventArgs e)
        {
            button_set();
            textItem_set();
            buttonText_set(ShuffleList(textItem));
            stopwatch.Reset();
            SetNewTimer();
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
                    if (DeletedPairs == 68)
                    {
                        StopTimer();
                        ShisenshoRankingForm result = new ShisenshoRankingForm(lblTimer.Text);
                        result.StartPosition = FormStartPosition.CenterParent;
                        result.ShowDialog();
                        btnHint.Enabled = false;
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
            ChangeTileVisible();
            buttonText_set(ShuffleList(textItem));
            ClearTimer();
            SetNewTimer();
        }

        private void btnHint_Click(object sender, EventArgs e)
        {
            ClearHintList();
            firstTimeClickButton = null;
            iSFirstTimeClick = true;
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
            buttonText_set(ShuffleList(GetTilesText()));
        }

        private void TimerMethod(object sender, EventArgs e)
        {
            lblTimer.Text = TimeSpanToString(stopwatch.Elapsed);
        }

        #endregion

        #region 値取得関数
        private Coordinate GetCoordinate(Button button)
        {
            Point xy = (Point)button.Tag;
            return new Coordinate(xy.Y, xy.X);
        }

        private string YYYYMMDDToString(DateTime date)
        {
            return date.Year.ToString("0000") + "/" + date.Month.ToString("00") + "/" + date.Day.ToString("00");
        }

        private string TimeSpanToString(TimeSpan span)
        {
            return span.Hours.ToString("00") + ":" + span.Minutes.ToString("00") + ":" + span.Seconds.ToString("00");
        }

        private List<string> GetTilesText()
        {
            List<string> list = new List<string>();
            for (int i = 1; i <= maxrow; i++)
            {
                for (int j = 1; j <= maxcol; j++)
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
        private bool BFS(Coordinate xy1, Coordinate xy2)
        {
            int[] dx = new int[] { 1, 0, -1, 0 };
            int[] dy = new int[] { 0, -1, 0, 1 };
            List<List<List<int>>> cost = new List<List<List<int>>>();
            for (int i = 0; i <= maxrow + 1; i++)
            {
                cost.Add(new List<List<int>>());
                for (int j = 0; j <= maxcol + 1; j++)
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
                if (maxrow + 2 <= ty || ty < 0 || maxcol + 2 <= tx || tx < 0 || 2 < tc)
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