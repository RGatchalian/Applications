using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace YanasSpelling
{
    public partial class frmMain : Form
    {
        private bool isFileSaved = true;
        public frmMain()
        {
            InitializeComponent();
            LoadConfig();
        }
        private void LoadConfig()
        {
            Settings.DefaultFolder =Application.StartupPath + "\\db";
            Settings.DefaultConfigFile = Settings.DefaultFolder  + "\\wordomizer.bin";
            if (!Directory.Exists(Settings.DefaultFolder))
            {
                Directory.CreateDirectory(Settings.DefaultFolder);
            }
            if (!File.Exists(Settings.DefaultConfigFile))
            {
                FileStream fs = new FileStream(Settings.DefaultConfigFile,FileMode.CreateNew);
                fs.Close();
            }
            LoadSettings();
            LoadNames();

        }
        private void LoadSettings()
        {
            Settings.CurrentFileName = "";
            Settings.LastFileOpen = "";
            Settings.Names = new List<string>();

            using (StreamReader sr = new StreamReader(Settings.DefaultConfigFile))
            {
                string line = "";
                bool isSettingsFound = false;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.ToUpper() == "[SETTINGS]")
                    {
                        isSettingsFound = true;
                    }
                    if (isSettingsFound)
                    {
                        if (line == "[/]")
                        {
                            return;
                        }
                        else
                        {
                            string[] arr = line.Split(new char[] { '=' });
                            if (arr.GetUpperBound(0) > 0)
                            {
                                string setting = arr[0];
                                string value = arr[1];
                                switch (setting.ToUpper())
                                {
                                    case "LAST":
                                        Settings.LastFileOpen = value;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstList.Items.IndexOf(txtWord.Text) < 0)
            {
                isFileSaved = false;
                lstList.Items.Add(txtWord.Text);
            }
            txtWord.Text = "";
        }

        private void SaveList()
        {
            Settings.LastFileOpen = Settings.CurrentFileName;
            if (IsFileFound())
            {
                using (StreamWriter sw = new StreamWriter(Settings.DefaultConfigFile))
                {
                    sw.WriteLine("[LIST]");
                    foreach (string s in Settings.Names)
                    {
                        sw.WriteLine(s);
                    }
                    sw.WriteLine("[/]");
                }
            }
        }

        private void SaveWordsToFile()
        {
            string file = Settings.DefaultFolder + "\\" + Settings.CurrentFileName + ".txt";
            using (StreamWriter sw = new StreamWriter(file))
            {
                foreach (string s in lstList.Items)
                {
                    sw.WriteLine(s);
                }
            }
        }

        private bool IsFileFound()
        {
            foreach (string s in Settings.Names)
            {
                if (s == Settings.CurrentFileName)
                {
                    return true;
                }
            }
            return false;
        }
        private void LoadNames()
        {
            using (StreamReader sr = new StreamReader(Settings.DefaultConfigFile))
            {
                string line="";
                bool isListFound=false;
                while ((line = sr.ReadLine()) != null)
                {
                    if (isListFound)
                    {
                        if (line != "[/]")
                        {
                            Settings.Names.Add(line);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (line.ToUpper() == "[LIST]")
                        {
                            isListFound = true;
                        }

                    }
                }
            }

        }
        private void saveListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.CurrentFileName == "")
            {
                if (lstList.Items.Count > 0)
                {
                    frmInput fi = new frmInput();
                    fi.Caption = "Wordomize";
                    fi.Label = "Please enter list name";
                    if (fi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Settings.CurrentFileName = fi.Value;
                        Settings.Names.Add(Settings.CurrentFileName);
                        SaveList();
                        SaveWordsToFile();
                        isFileSaved = true;
                    }

                }
                else
                {
                    MessageBox.Show("Nothing to Save");
                }

            }
            else
            {
                SaveWordsToFile();
                isFileSaved = true;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isFileSaved)
            {
                if (MessageBox.Show("Do you want to save file?", "Wordomize", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (Settings.CurrentFileName != "")
                    {
                        SaveWordsToFile();
                        isFileSaved = true;
                    }
                    else
                    {
                        saveListToolStripMenuItem_Click(sender, e);
                    }
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isFileSaved == false)
            {
                if (MessageBox.Show("Do you want to save file?", "Wordomize", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (Settings.CurrentFileName != "")
                    {
                        SaveWordsToFile();
                        isFileSaved = true;
                    }
                    else
                    {
                        saveListToolStripMenuItem_Click(sender, e);
                    }
                }
            }
            Settings.CurrentFileName = "";
            isFileSaved = false;
            lstList.Items.Clear();
            lstRandom.Items.Clear();
        }

        private void txtWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAdd_Click(sender, e);
            }
        }

        private void loadListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmList fl = new frmList();
            fl.Names = Settings.Names;
            if (fl.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {                
                Settings.CurrentFileName = fl.SelectedValue;
                LoadWords();
            }
        }
        private void LoadWords()
        {
            string file = Settings.DefaultFolder + "\\" + Settings.CurrentFileName + ".txt";
            if (File.Exists(file))
            {
                lstList.Items.Clear();
                using (StreamReader sr = new StreamReader(file))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        lstList.Items.Add(line);
                    }
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            int count = lstList.Items.Count;
            List<string> _lstCopy = new List<string>();
            Random rand = new Random();

            lstRandom.Items.Clear();
            foreach (string s in lstList.Items)
            {
                _lstCopy.Add(s);
            }
            do
            {
                int index = rand.Next(0,_lstCopy.Count);
                string curStr = _lstCopy[index];
                lstRandom.Items.Add(curStr);
                _lstCopy.Remove(curStr);
            } while (_lstCopy.Count>0);
        }

        private void lstRandom_DoubleClick(object sender, EventArgs e)
        {
            if (lstRandom.Items.Count <= 0) return;
            string selected = (string)lstRandom.Items[lstRandom.SelectedIndex];
            this.Text = "Wordomize - " + selected;
            lstRandom.Items.RemoveAt(lstRandom.SelectedIndex);

        }
        
    }
    public class Settings
    {
        public static List<string> Names { get; set; }
        public static string DefaultFolder { get; set; }
        public static string CurrentFileName { get; set; }
        public static string DefaultConfigFile { get; set; }
        public static List<string> Words { get; set; }
        public static string LastFileOpen { get; set; }
    }
}
