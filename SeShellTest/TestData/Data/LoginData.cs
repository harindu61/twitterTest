using SeShell.Test.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeShell.Test.TestData.Data
{
    class LoginData : AbstractTestData
    {

        public String password { get; set; }
        public String username { get; set; }
        public String expectedResult { get; set; }

        public static List<LoginData> GetLoginTestData()
        {
            List<LoginData> testData = new List<LoginData>();
            string inputLine;
            using (FileStream inputStream =
                new FileStream(Configuration.TestDataFilePath + @"\LoginData.csv",
                    FileMode.Open,
                    FileAccess.Read))
            {
                StreamReader streamReader = new StreamReader(inputStream);

                while ((inputLine = streamReader.ReadLine()) != null)
                {
                    var data = inputLine.Split(',');
                    testData.Add(new LoginData
                    {
                        username = Convert.ToString((data[0])),
                        password = Convert.ToString((data[1])),
                        expectedResult = Convert.ToString(data[2])
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
