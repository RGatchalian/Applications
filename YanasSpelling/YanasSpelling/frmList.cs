using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YanasSpelling
{
    public partial class frmList : Form
    {
        public string SelectedValue;
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
    }
}
