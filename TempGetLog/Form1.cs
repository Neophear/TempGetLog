using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TempGetLog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach (string path in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\log\"))
            {
                foreach (string line in File.ReadAllLines(path))
                {
                    string username = line.Substring(line.LastIndexOf(" - ") + 3).Trim();
                    string pcname = Path.GetFileNameWithoutExtension(path);
                    string time = line.Substring(0, 19);
                    int type = line.Split('-')[3].Trim().ToLower() == "logon" ? 1 : 2;
                    DateTime timestamp = DateTime.Parse(time);
                    textBox1.AppendText($"INSERT INTO [TempLog] ([TimeStamp], [Username], [ComputerName], [ActionRefID]) VALUES('{timestamp.ToString("yyyy-MM-dd HH:mm:ss")}', '{username}', '{pcname}', {type})\n");
                }
            }
        }
    }
}
