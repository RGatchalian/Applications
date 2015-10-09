using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class frmTest : Form
    {
        AnalogClock _analogclock = new AnalogClock();
        public frmTest()
        {
            InitializeComponent();
            _analogclock.Location = new Point(10, 10);
            _analogclock.Size = new Size(300, 300);
            this.Controls.Add(_analogclock);
        }
    }
}
