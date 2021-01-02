using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace rename_file_from_csv
{
    class Program
    {
        static void Main(string[] args)
        {
            // CSVから取得したデータ格納用リスト
            List<string[]> csv_data = new List<string[]>();

            if (!File.Exists(args[0]))
            {
                Console.WriteLine("CSVファイルが見つからない");
                return;
            }
            if (!Directory.Exists(args[1]))
            {
                Console.WriteLine("名称変更対象ファイルの格納ディレクトリが見つからない");
                return;
            }
            var csv_file_path = args[0];
            var target_directory_path = args[1];
            
            // CSVファイル読み込み
            TextFieldParser parser = new TextFieldParser(@csv_file_path);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            // ヘッダーの読み込み
            string[] header = parser.ReadFields();
            while (!parser.EndOfData)
            {
                string[] values = parser.ReadFields();
                csv_data.Add(values);
            }

            // テスト用コード
            foreach (var item in csv_data)
            {
                foreach (var item2 in item)
                {
                    System.Console.Write(item2);
                }
                System.Console.WriteLine();
            }

            // ファイル名変更の実行
            foreach (var values in csv_data)
            {
                // 名前変更対象のファイルパス
                string file_path = Path.Combine(@target_directory_path, values[0]);
                // 拡張子の取得
                string extension = Path.GetExtension(file_path);
                // ファイルの格納先ディレクトリの取得
                string file_directory = Path.GetDirectoryName(file_path);
                string changed_file_name = $"{values[1]}_{values[2]}{extension}";
                string changed_file_path = Path.Combine(file_directory, changed_file_name);
                // ファイル名変更の実行
                File.Move(file_path, changed_file_path);
            }

        }
    }
}
