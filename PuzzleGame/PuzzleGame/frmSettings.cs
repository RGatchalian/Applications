using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleGame
{
    public partial class frmSettings : Form
    {
        public int Count { get; set; }
        public frmSettings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsTextNumeric(txtCount.Text.Trim())){
                MessageBox.Show("You must enter a number.");
                return;
            }
            else
            {
                if (int.Parse(txtCount.Text.Trim()) <= 10)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Count = int.Parse(txtCount.Text.Trim());
                }
            }
        }
        private bool IsTextNumeric(string text)
        {
            for(int x = 0; x < text.Length; x++)
            {
                if (!char.IsNumber(text[x]))
                {
                    return false;
                }
            }
            return true;
        }

        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(sender, e);
            }
        }
    }
}
