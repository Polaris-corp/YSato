using Formtest.Model;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shisensho
{
    public partial class ShisenshoRankingForm : Form
    {
        public ShisenshoRankingForm(string time)
        {
            InitializeComponent();
            this.time = time;
        }
        string time;
        private static string DirectoryPath = @".\Shisensho_score";
        private static string FileName = "score.csv";
        private static string FilePath = Path.Combine(DirectoryPath, FileName);
        List<Score> scoreList = new List<Score>();
        Label[] labels = new Label[5];


        #region イベント

        private void ShisenshoRankingForm_Load(object sender, EventArgs e)
        {
            InPutFile();
            SetRankingText();
            lblResultTimeMessage.Text = "あなたの記録は" + time + "でした！";
            if (IsNewRecord())
            {
                lblResultMessage.Visible = true;
            }
            else
            {
                lblRegistering.Visible = false;
                btnRankingLeft.Visible = false;
                btnRankingRight.Text = "閉じる";
            }
        }

        private void btnRankingLeft_Click(object sender, EventArgs e)
        {
            if (lblResultMessage.Visible)
            {
                pnlRegistration.Visible = true;
            }
            else
            {
                this.Close();
            }
        }

        private void btnRankingRight_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            OutPutFile(txtNameInputField.Text, time, DateTime.Now);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlRegistration.Visible = false;
        }

        #endregion

        #region 値の取得と出力

        private void InPutFile()
        {
            FileCreater();

            using (TextFieldParser textFieldParser = new TextFieldParser(FilePath))
            {
                textFieldParser.SetDelimiters(",");
                while (!textFieldParser.EndOfData)
                {
                    string[] values = textFieldParser.ReadFields();
                    if (values is null)
                    {
                        continue;
                    }
                    Score score = new Score();
                    score.Name = values[0];
                    score.Time = values[1];
                    score.Date = values[2];
                    scoreList.Add(score);
                }
            }
        }

        private void OutPutFile(string name, string time, DateTime date)
        {
            Score newScore = new Score();
            newScore.Name = name;
            newScore.Time = time;
            newScore.Date = YYYYMMDDToString(date);
            scoreList.Add(newScore);
            scoreList = scoreList.OrderBy(x => x.Time).ThenBy(x => x.Name).ThenByDescending(x => x.Date).ToList();
            FileCreater();
            using (StreamWriter writer = new StreamWriter(FilePath, false, Encoding.UTF8))
            {
                writer.WriteLine(CreateOutPutText());
            }
        }

        private string CreateOutPutText()
        {
            List<string> item = new List<string>();
            for (int i = 0; i < scoreList.Count; i++)
            {
                item.Add(string.Join(",", scoreList[i].Name, scoreList[i].Time, scoreList[i].Date));
            }

            return string.Join("\r\n", item);
        }

        private string YYYYMMDDToString(DateTime date)
        {
            return date.Year.ToString("0000") + "/" + date.Month.ToString("00") + "/" + date.Day.ToString("00");
        }

        private void SetRankingText()
        {
            labels[0] = lblRanking1st;
            labels[1] = lblRanking2nd;
            labels[2] = lblRanking3rd;
            labels[3] = lblRanking4th;
            labels[4] = lblRanking5th;

            for (int i = 0; i < scoreList.Count; i++)
            {
                labels[i].Text = string.Join(" ", scoreList[i].Name, scoreList[i].Time, scoreList[i].Date);
            }

        }

        private void FileCreater()
        {
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            if (!File.Exists(FilePath))
            {
                using (File.Create(FilePath)) { }
            }
        }

        private bool IsNewRecord()
        {
            if (scoreList.Count < 5)
            {
                return true;
            }
            TimeSpan oldTime = TimeSpan.Parse(scoreList[4].Time);
            TimeSpan newTime = TimeSpan.Parse(time);
            if (newTime < oldTime)
            {
                return true;
            }
            return false;
        }



        #endregion

    }
}
