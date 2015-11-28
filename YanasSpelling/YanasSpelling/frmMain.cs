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
using System.Diagnostics;

namespace YanasSpelling
{
    public partial class frmMain : Form
    {
        private bool isFileSaved = true;
        private string lastremovedword = "";
        public frmMain()
        {
            InitializeComponent();
            LoadConfig();
            GetAppInfo();
            CleanList();
        }
        private void LoadConfig()
        {
            Settings.DefaultFolder =Application.StartupPath + "\\db";
            Settings.Repository = Application.StartupPath + "\\db\\repository";
            Settings.ActivityRepository = Application.StartupPath + "\\db\\repository\\activity";
            Settings.DefaultConfigFile = Settings.DefaultFolder  + "\\wordomizer.bin";
            if (!Directory.Exists(Settings.DefaultFolder))
            {
                Directory.CreateDirectory(Settings.DefaultFolder);
            }
            if (!Directory.Exists(Settings.Repository))
            {
                Directory.CreateDirectory(Settings.Repository);
            }
            if (!Directory.Exists(Settings.ActivityRepository))
            {
                Directory.CreateDirectory(Settings.ActivityRepository);
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
            Settings.AutoShuffle = "";
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
                                        Settings.CurrentFileName = value;
                                        break;
                                    case "LOADLAST":
                                        Settings.LoadLastFileOpen = value;
                                        if (Settings.LoadLastFileOpen.ToUpper() == "TRUE")
                                        {
                                            loadLastListToolStripMenuItem.Checked = true;
                                            LoadWords();
                                        }
                                        else
                                        {
                                            loadLastListToolStripMenuItem.Checked = false;
                                        }
                                        break;
                                    case "AUTOSHUFFLE":
                                        Settings.AutoShuffle = value;
                                        if (Settings.AutoShuffle.ToUpper() == "TRUE")
                                        {
                                            autoShuffleToolStripMenuItem.Checked = true;
                                            btnProcess_Click(new object(), new EventArgs());
                                        }
                                        else
                                        {
                                            autoShuffleToolStripMenuItem.Checked = false;
                                        }
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

        private void SaveConfig()
        {
            Settings.LastFileOpen = Settings.CurrentFileName;
            if (Settings.Names.Count > 0)
            {
                using (StreamWriter sw = new StreamWriter(Settings.DefaultConfigFile))
                {
                    sw.WriteLine("[INFO]");
                    sw.WriteLine("APPNAME=" + Settings.ApplicationName);
                    sw.WriteLine("VERSION=" + Settings.Version);
                    sw.WriteLine("DEVELOPER=" + Settings.Developer);
                    sw.WriteLine("[/]");
                    sw.WriteLine("[SETTINGS]");
                    sw.WriteLine("LAST=" + Settings.CurrentFileName);
                    sw.WriteLine("LOADLAST=" + (loadLastListToolStripMenuItem.Checked ? "TRUE" : "FALSE"));
                    sw.WriteLine("AUTOSHUFFLE=" + (autoShuffleToolStripMenuItem.Checked ? "TRUE" : "FALSE"));
                    sw.WriteLine("[/]");
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
            string file = Settings.Repository + "\\" + Settings.CurrentFileName + ".txt";
            using (StreamWriter sw = new StreamWriter(file))
            {
                foreach (string s in lstList.Items)
                {
                    sw.WriteLine(s);
                }
            }
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
                    fi.Caption = Settings.ApplicationName;
                    fi.Label = "Please enter list name";
                    if (fi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Settings.CurrentFileName = fi.Value;
                        if (Settings.Names.IndexOf(Settings.CurrentFileName) < 0)
                        {
                            Settings.Names.Add(Settings.CurrentFileName);
                        }
                        SaveConfig();
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
                if (MessageBox.Show("Do you want to save file?", Settings.ApplicationName, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
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
                SaveConfig();
                LoadWords();
            }
        }
        private void LoadWords()
        {
            string file = Settings.Repository + "\\" + Settings.CurrentFileName + ".txt";
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
            if (lstList.Items.Count > 0)
            {
                foreach (string s in lstList.Items)
                {
                    _lstCopy.Add(s);
                }
                do
                {
                    int index = rand.Next(0, _lstCopy.Count);
                    string curStr = _lstCopy[index];
                    lstRandom.Items.Add(curStr);
                    _lstCopy.Remove(curStr);
                } while (_lstCopy.Count > 0);
                string dName = DateTime.Now.ToString("ddMMMyyyy_hhmmss");
                Settings.CurrentRandomFile = Settings.CurrentFileName + "_" + dName;

                SaveRandom();
            }
        }
        private void SaveRandom()
        {
            using (StreamWriter sw = new StreamWriter(Settings.ActivityRepository + "\\" + Settings.CurrentRandomFile + ".dat"))
            {
                foreach(string s in lstRandom.Items)
                {
                    sw.WriteLine(s);
                }
            }
        }
        private void lstRandom_DoubleClick(object sender, EventArgs e)
        {
            if (lstRandom.Items.Count <= 0) return;
            string selected = (string)lstRandom.Items[lstRandom.SelectedIndex];
            if (selected.ToUpper().ToUpper().IndexOf("DONE") < 0)
            {
                this.Text = "Wordomizer - " + selected;
                lastremovedword = selected;
                lstRandom.Items[lstRandom.SelectedIndex] = selected + "=Done";
                SaveRandom();

            }
            //lstRandom.Items.RemoveAt(lstRandom.SelectedIndex);

        }

        private void loadLastListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadLastListToolStripMenuItem.Checked = !loadLastListToolStripMenuItem.Checked;
            SaveConfig();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstRandom_DoubleClick(sender, e);
        }

        private void undoRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //lstRandom.Items.Add(lastremovedword);
            string selectedstring = "";
            if (lstRandom.SelectedItems.Count > 0)
            {
                string tmpselectedstring = lstRandom.SelectedItems[0].ToString();
                string[] arr = tmpselectedstring.Split('=');
                if (arr.GetUpperBound(0) == 1)
                {
                    selectedstring = arr[0];
                }
                else
                {
                    selectedstring = lastremovedword;
                }
            }
            for(int x=0;x< lstRandom.Items.Count;x++)
            {
                if (lstRandom.Items[x].ToString().IndexOf(selectedstring) >= 0)
                {
                    lstRandom.Items[x] = selectedstring;
                }
            }
            this.Text = Settings.ApplicationName;
            SaveRandom();
        }

        private void clearActivityFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete all the files?",Settings.ApplicationName,MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                foreach (string s in Directory.GetFiles(Settings.ActivityRepository))
                {
                    File.Delete(s);
                }

            }
        }
        private void GetAppInfo()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            Settings.Version = fvi.FileVersion;
        }

        private void autoShuffleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoShuffleToolStripMenuItem.Checked = !autoShuffleToolStripMenuItem.Checked;
            SaveConfig();
        }

        private void deleteFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmList fl = new frmList();
            fl.Names = Settings.Names;
            fl.RepositoryPath = Settings.Repository;
            fl.ShowDialog();
            Settings.Names= fl.Names;
            SaveConfig();
        }

        private void CleanList()
        {
            List<string> _list = new List<string>();
            foreach(string s in Settings.Names)
            {
                string file = Settings.Repository + "\\" + s + ".txt";
                if (!File.Exists(file))
                {
                    _list.Add(s);
                }
            }
            foreach(string s in _list)
            {
                Settings.Names.Remove(s);
            }
            SaveConfig();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void correctToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedstring = "";
            if (lstRandom.SelectedItems.Count > 0)
            {
                string tmpselectedstring = lstRandom.SelectedItems[0].ToString();
                if (tmpselectedstring.ToUpper().IndexOf("=") > 0)
                {
                    string[] arr = tmpselectedstring.Split('=');
                    selectedstring = arr[0];
                }
                else
                {
                    selectedstring = tmpselectedstring;

                }
                for (int x = 0; x < lstRandom.Items.Count; x++)
                {
                    if (lstRandom.Items[x].ToString().IndexOf(selectedstring) >= 0)
                    {
                        lstRandom.Items[x] = selectedstring + "=CORRECT";
                    }
                }

            }
            this.Text = Settings.ApplicationName;
            SaveRandom();
        }

        private void wrongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedstring = "";
            if (lstRandom.SelectedItems.Count > 0)
            {
                string tmpselectedstring = lstRandom.SelectedItems[0].ToString();
                if (tmpselectedstring.ToUpper().IndexOf("=") > 0)
                {
                    string[] arr = tmpselectedstring.Split('=');
                    selectedstring = arr[0];
                }
                else
                {
                    selectedstring = tmpselectedstring;

                }
                for (int x = 0; x < lstRandom.Items.Count; x++)
                {
                    if (lstRandom.Items[x].ToString().IndexOf(selectedstring) >= 0)
                    {
                        lstRandom.Items[x] = selectedstring + "=WRONG";
                    }
                }

            }
            this.Text = Settings.ApplicationName;
            SaveRandom();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstList.SelectedItems.Count > 0)
            {
                string tmpselectedstring = lstList.SelectedItem.ToString();
                int index = lstList.SelectedIndex;
                frmInput fi = new frmInput();
                fi.Caption = Settings.ApplicationName + "-" + tmpselectedstring;
                fi.Label = "Change Text";
                fi.Value = tmpselectedstring;
                if (fi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lstList.Items[lstList.SelectedIndex] = fi.Value;
                    SaveWordsToFile();
                }
            }
        }
    }
    public class Settings
    {
        public static List<string> Names { get; set; }
        public static string DefaultFolder { get; set; }
        public static string Repository { get; set; }
        public static string ActivityRepository { get; set; }
        public static string CurrentFileName { get; set; }
        public static string DefaultConfigFile { get; set; }
        public static List<string> Words { get; set; }
        public static string LastFileOpen { get; set; }
        public static string AutoShuffle { get; set; }
        public static string LoadLastFileOpen { get; set; }
        public static string Version = "1.0.0";
        public static string Developer = "Reydan Gatchalian";
        public static string ApplicationName = "Wordomizer";
        public static string CurrentRandomFile { get; set; }
    }
}
