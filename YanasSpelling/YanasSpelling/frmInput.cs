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
    public partial class frmInput : Form
    {
        private string _caption = "Wordomaize";
        private string _label = "Please Enter Text";
        private string _value = "";
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;

                txtInput.Text = _value;
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                this.Text = value;
            }
        }
        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
                this.lbInput.Text = value;
            }
        }
        public frmInput()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != "")
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Value = txtInput.Text;
                this.Close();
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                MessageBox.Show("Please Enter Text");
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
