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
    public partial class frmList : Form
    {
        public string SelectedValue;
        public string ApplicationName;
        public string RepositoryPath;
        private List<string> _names = new List<string>();
        public List<string> Names
        {
            get
            {
                return _names;
            }
            set
            {
                _names = value;
                lstList.Items.Clear();
                foreach (string s in _names)
                {
                    lstList.Items.Add(s);
                }
            }

        }
        public frmList()
        {
            InitializeComponent();
        }

        private void lstList_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SelectedValue = lstList.Text;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstList.SelectedItems.Count > 0)
            {
                int index = lstList.SelectedIndex;
                if (MessageBox.Show("Are you sure you want to delete?", this.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string name = lstList.Items[index].ToString();
                    File.Delete(RepositoryPath + "\\" + name + ".txt");
                    lstList.Items.RemoveAt(index);
                    this._names.Clear();
                    foreach (string s in lstList.Items)
                    {
                        this._names.Add(s);
                    }
                }
            }
        }
    }
}
