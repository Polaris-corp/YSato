using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using WindowsFormsApp2.Model;
using WindowsFormsApp2.Controller;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string InputFilePath = @"..\..\testfile\ysato_testdata.tsv";
            StreamReader reader = new StreamReader(InputFilePath);
            List<TestModel> testModels = new List<TestModel>();
            bool header = true;
            var cnt = 0;
            //ファイルレコードが存在するまでループ
            while (reader.Peek() >= 0)
            {
                if (header)
                {
                    header = false;
                    reader.ReadLine();
                    continue;
                }

                //読み取った行をタブで区切り、文字列配列に格納
                string[] cols = reader.ReadLine().Split('\t');

                //項目値取得
                TestModel testModel = new TestModel();
                testModel.ClickTime = DateTime.Parse(cols[10]);
                testModel.Result = Convert.ToBoolean(cols[11]);
                testModel.HistoryModel.LoginFailureCount = Convert.ToInt32(cols[2]);
                testModel.HistoryModel.NewestTimes = DateTime.Parse(cols[9]);
                testModel.HistoryModel.OldestTimes = DateTime.Parse(cols[8]);
                testModels.Add(testModel);
            }
            LoginController loginController = new LoginController();
            foreach (var item in testModels)
            {
                Assert.AreEqual(loginController.IsLoginLock(item.HistoryModel, item.ClickTime), item.Result);
                cnt++;
            }
        }
    }
}
