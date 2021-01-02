using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace rename_file_from_csv
{
    class Logger
    {
        //ログのファイルパス
        string log_path;
        public Logger(string log_name)
        {
            string current_dir = Directory.GetCurrentDirectory();
            this.log_path = Path.Combine(current_dir, log_name);

        }

        public void WriteLogAndConsole(string mes)
        {
            DateTime now = DateTime.Now;
            mes = $"{now},{mes}" + Environment.NewLine;
            Console.WriteLine(mes);
            File.AppendAllText(log_path, mes);
        }

        public void WriteLog(string mes)
        {
            DateTime now = DateTime.Now;
            mes = $"{now},{mes}" + Environment.NewLine;
            File.AppendAllText(log_path, mes);
        }
    }
}
