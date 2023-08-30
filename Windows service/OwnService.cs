using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_service
{
    public class OwnService
    {
        public void Start()
        {
            WriteToFile("Service started. Timestamp " + DateTime.Now);
        }
        public void Stop()
        {
            WriteToFile("Service stopped. Timestamp " + DateTime.Now);
        }
        public void Execute()
        {
            WriteToFile("Service executing. Timestamp " + DateTime.Now);

        }
        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\LocalLog";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\LocalLog\\Log_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}
