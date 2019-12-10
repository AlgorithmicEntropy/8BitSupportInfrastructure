using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlLogicEEPROMGenerator.Core;

namespace ControlLogicEEPROMGenerator
{
    class FileGenerator
    {
        [STAThread]
        static void Main(string[] args)
        {
            Setup();

            var path = GetSourceFile();
            if (path == "")
            {
                return;
            }
            CSVParser parser = new CSVParser();
            Console.WriteLine("reading CSV file...");
            var data = parser.ReadControlData(path);

            //Console.WriteLine(data.ToString());
            Console.WriteLine("done");

            Console.WriteLine("processing data...");
            DataToFileSplitter splitter = new DataToFileSplitter();
            var res = splitter.SplitData(data);
            Console.WriteLine("writing files..");
            var outputPath = GetOutputDirectory();
            if (outputPath == "")
            {
                return;
            }
            splitter.WriteFiles(res, outputPath);

            Console.WriteLine("DONE");
            Console.ReadKey();
        }

        private static void Setup()
        {
            Console.Title = "CSV Control Data Processor";
        }

        private static string GetSourceFile()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            fileDialog.ShowDialog();
            Console.WriteLine(fileDialog.FileName);
            return fileDialog.FileName;
        }

        private static string GetOutputDirectory()
        {
            var folderDialog = new FolderBrowserDialog
            {
                Description = "Select output directory"
            };
            folderDialog.ShowDialog();
            var path = folderDialog.SelectedPath;
            folderDialog.Dispose();
            return path;
        }
    }
}
