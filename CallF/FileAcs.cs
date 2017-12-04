using System;
using System.IO;
using System.Linq;

namespace CallF
{
    public class FileAcs
    {
        public string WriteCallToFile(Call call, string fileName)
        {
            string msg = $"BenchName:{call.BenchName}|";
            msg += $"Problem:{call.Problem}|";
            msg += $"Comment:{call.Comment}";

            string write = Write2File(msg, fileName);

            return write;
        }

        public Call ReadCallsFromFile(string fileName)
        {
            string fileText = ReadFromFile(fileName);

            string[] callInfo = fileText.Split('|');

            Call callRead = new Call();

            callRead.BenchName = callInfo[0].Split(':').Last();
            callRead.Problem = callInfo[1].Split(':').Last();
            callRead.Comment = callInfo[2].Split(':').Last();

            return callRead;
        }


        public string Write2File(string message, string fileName)
        {
            StreamWriter sw = new StreamWriter(fileName, false);

            int retryCount = 5;

            for (int i = 0; i < retryCount; i++)
            {
                try
                {
                    sw.Write(message);
                    sw.Flush();
                    sw.Close();
                    return "Success";
                }
                catch (Exception ex)
                {
                    if (i == retryCount)
                    {
                        return ex.Message;
                    }
                }
            }

            return "Nothing Written To File";
        }

        public string ReadFromFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);

            string textLineInFile = "";

            while (!sr.EndOfStream)
            {
                textLineInFile = sr.ReadLine();
            }

            return textLineInFile;
        }





    }
}
