﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shisensho
{
    public partial class Shisensho : Form
    {
        public class Coordinate
        {
            public Coordinate(int r = 0, int c = 0)
            {
                row = r;
                col = c;
            }
            public int row { get; set; }
            public int col { get; set; }
        }
        public Shisensho()
        {
            InitializeComponent();
            buttons = new Button[maxrow + 2, maxcol + 2];
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            this.BackColor = Color.DarkGreen;
        }

        int maxrow = 8;
        int maxcol = 17;

        Button[,] buttons;
        Button firstTimeClickButton;
        bool iSFirstTimeClick = true;

        List<string> textItem = new List<string>();

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
            ShuffleList(textItem);

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
                    buttons[i, j].TabIndex = 0;
                    buttons[i, j].Text = "";
                    buttons[i, j].TabStop = false;
                    buttons[i, j].Font = new Font("Meiryo UI", 20);
                    buttons[i, j].UseVisualStyleBackColor = true;
                    buttons[i, j].Click += new EventHandler(this.button_Click);

                    if (i == 0 || i == maxrow + 1 || j == 0 || j == maxcol + 1)
                    {
                        buttons[i, j].Visible = false;
                    }

                    this.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void buttonText_set()
        {
            for (int i = 1; i <= maxrow; i++)
            {
                for (int j = 1; j <= maxcol; j++)
                {
                    buttons[i, j].Text = textItem[(i - 1) * maxcol + (j - 1)];
                }
            }
        }

        private void ShuffleList(List<string> list)
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
        }

        #endregion

        #region イベント
        private void Form1_Load(object sender, EventArgs e)
        {
            button_set();
            textItem_set();
            buttonText_set();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button; // クリックされたボタンを取得

            if (iSFirstTimeClick)
            {
                firstTimeClickButton = clickedButton;
                firstTimeClickButton.FlatAppearance.BorderColor = Color.Red;
            }
            else
            {
                if (clickedButton != firstTimeClickButton && TileCheck(firstTimeClickButton, clickedButton))
                {
                    // クリックされたボタンを非表示にする
                    clickedButton.Visible = false;
                    firstTimeClickButton.Visible = false;
                }
                else
                {
                    firstTimeClickButton = null;
                }
            }
            iSFirstTimeClick = !iSFirstTimeClick;

        }

        #endregion

        #region 座標取得関数
        private Coordinate GetCoordinate(Button button)
        {
            Point xy = (Point)button.Tag;
            return new Coordinate(xy.Y, xy.X);
        }

        private (Coordinate, Coordinate) ConvertLeftSide(Coordinate xy1, Coordinate xy2)
        {
            if (xy1.col > xy2.col)
            {
                var tmp = xy1;
                xy1 = xy2;
                xy2 = tmp;
            }
            else if (xy1.col == xy2.col)
            {
                int min = Math.Min(xy1.row, xy2.row);
                int max = Math.Max(xy1.row, xy2.row);
                xy1.row = min;
                xy2.row = max;
            }
            return (xy1, xy2);
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
            (xy1, xy2) = ConvertLeftSide(xy1, xy2);
            if (StraightCheck(xy1, xy2))
            {
                return true;
            }
            if (LShapeCheck(xy1, xy2))
            {
                return true;
            }
            if (ZShapeCheck(xy1, xy2))
            {
                return true;
            }
            return false;
        }

        private bool StraightCheck(Coordinate xy1, Coordinate xy2)
        {
            return VerticalCheck(xy1, xy2) || HorizontalCheck(xy1, xy2);
        }

        private bool VerticalCheck(Coordinate xy1, Coordinate xy2)
        {
            if (xy1.col == xy2.col)
            {
                int min = Math.Min(xy1.row, xy2.row) + 1;
                int max = Math.Max(xy1.row, xy2.row);
                for (int row = min; row < max; row++)
                {
                    if (buttons[row, xy1.col].Visible == true)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        private bool HorizontalCheck(Coordinate xy1, Coordinate xy2)
        {
            if (xy1.row == xy2.row)
            {
                int min = Math.Min(xy1.col, xy2.col) + 1;
                int max = Math.Max(xy1.col, xy2.col);
                for (int col = min; col < max; col++)
                {
                    if (buttons[xy1.row, col].Visible == true)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        private bool RelayPointCheck(Coordinate xy1, Coordinate xy2)
        {
            Coordinate relay = new Coordinate(xy1.row, xy2.col);
            if (!buttons[relay.row, relay.col].Visible)
            {
                return HorizontalCheck(xy1, relay) && VerticalCheck(relay, xy2);
            }
            return false;
        }

        private bool LShapeCheck(Coordinate xy1, Coordinate xy2)
        {
            return RelayPointCheck(xy1, xy2) || RelayPointCheck(xy2, xy1);
        }

        private bool ColumRelayPointCheck(Coordinate xy1, Coordinate xy2, int pn)
        {
            Coordinate relay = new Coordinate(xy1.row, xy1.col);
            for (int col = xy1.col + pn; 0 <= col && col < maxcol + 2; col += pn)
            {
                relay.col = col;
                if (buttons[relay.row, relay.col].Visible)
                {
                    break;
                }
                if (LShapeCheck(relay, xy2))
                {
                    return true;
                }
            }
            return false;
        }

        private bool RowRelayPointCheck(Coordinate xy1, Coordinate xy2, int pn)
        {
            Coordinate relay = new Coordinate(xy1.row, xy1.col);
            for (int row = xy1.row + pn; 0 <= row && row < maxrow + 2; row += pn)
            {
                relay.row = row;
                if (buttons[relay.row, relay.col].Visible)
                {
                    break;
                }
                if (LShapeCheck(relay, xy2))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ZShapeCheck(Coordinate xy1, Coordinate xy2)
        {
            if (ColumRelayPointCheck(xy1, xy2, 1) || ColumRelayPointCheck(xy1, xy2, -1))
            {
                return true;
            }
            if (RowRelayPointCheck(xy1, xy2, 1) || RowRelayPointCheck(xy1, xy2, -1))
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}