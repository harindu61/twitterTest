using SeShell.Test.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeShell.Test.TestData.Data
{
    class TweetMessageData : AbstractTestData
    {

        public String password { get; set; }
        public String username { get; set; }
        public String message { get; set; }

        public static List<TweetMessageData> GetTweetMessageData()
        {
            List<TweetMessageData> testData = new List<TweetMessageData>();
            string inputLine;
            using (FileStream inputStream =
                new FileStream(Configuration.TestDataFilePath + @"\TweetMessageData.csv",
                    FileMode.Open,
                    FileAccess.Read))
            {
                StreamReader streamReader = new StreamReader(inputStream);

                while ((inputLine = streamReader.ReadLine()) != null)
                {
                    var data = inputLine.Split(',');
                    testData.Add(new TweetMessageData
                    {
                        username = Convert.ToString((data[0])),
                        password = Convert.ToString((data[1])),
                        message = Convert.ToString(data[2])
                    });
                }

                streamReader.Close();
                inputStream.Close();
            }

            return testData;
        }

        public override string[] GetClassPropertiesAsArray()
        {
            throw new NotImplementedException();
        }

    }
}
