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
    public partial class frmMain : Form
    {
        int puzzlecount = 3;
        string selectedtag = "";
        string selectedvalue = "";
        bool resize = false;
        bool change = false;
        List<int> numbers = new List<int>();
        public frmMain()
        {
            InitializeComponent();
            CreateGrid(puzzlecount* puzzlecount);
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            change = false;
            resize = false;
            CreateGrid(puzzlecount* puzzlecount);
        }
        private void CreateGrid(int num)
        {
            pnlPuzzle.Controls.Clear();
            Label[] buttonlabels = new Label[num];
            int boxcount = Convert.ToInt32(Math.Sqrt(num));
            int width = pnlPuzzle.Width / boxcount;
            int height = pnlPuzzle.Height / boxcount;
            int left = 0;
            int top = 0;
            int count = 0;
            int y_coord = 0;
            int x_coord = 0;
            //if (resize == false)
            //{
                numbers = GenerateNumbers(num);
            //}
            for (int x = 0; x <= buttonlabels.GetUpperBound(0); x++)
            {
                buttonlabels[x] = new Label();
                buttonlabels[x].Click += LabelClick;
                buttonlabels[x].DragOver += LabelDragOver;
                buttonlabels[x].MouseDown += LabelMouseDown;
                buttonlabels[x].DragDrop += LabelDragDrop;
                buttonlabels[x].Font = new Font(FontFamily.GenericSansSerif, 42.0f, FontStyle.Bold);
                buttonlabels[x].TextAlign = ContentAlignment.MiddleCenter;
                buttonlabels[x].AllowDrop = true;
                if (x== buttonlabels.GetUpperBound(0))
                {
                    buttonlabels[x].BorderStyle = BorderStyle.None;
                    buttonlabels[x].BackColor = Color.DarkGray;

                }
                else
                {
                    buttonlabels[x].BorderStyle = BorderStyle.Fixed3D;
                    buttonlabels[x].BackColor = Color.White;

                }
                buttonlabels[x].Width = width;
                buttonlabels[x].Height = height;
   
                if (count == 0)
                {
                    buttonlabels[x].Location = new Point(0, top);
                }
                else
                {
                    if (count == boxcount)
                    {
                        left = 0;
                        top += height;
                        count = 0;
                        buttonlabels[x].Location = new Point(0, top);
                        y_coord++;
                        x_coord = 0;

                    }
                    else
                    {
                        buttonlabels[x].Location = new Point(left + width, top);
                        left += width;
                        x_coord++;
                    }
                }
                count++;
                buttonlabels[x].Tag = x_coord.ToString() + "," + y_coord.ToString();

                if (x < buttonlabels.GetUpperBound(0))
                {
                    buttonlabels[x].Text = numbers[x].ToString();
                }
                pnlPuzzle.Controls.Add(buttonlabels[x]);
            }
            

        }

        private void LabelDragDrop(object sender, DragEventArgs e)
        {
            LabelAction(sender);
            //MessageBox.Show((string)e.Data.GetData(DataFormats.Text));
            //MessageBox.Show(((Label)sender).Text);
        }

        private void LabelMouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(((Label)sender).Text);
            LabelAction(sender);
            DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);
        }

        private void LabelDragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void LabelClick(object sender, EventArgs e)
        {
            LabelAction(sender);
        }
        private void LabelAction(object sender)
        {        
            Label selected = (Label)sender;
            string newselectedtag = "";
            string newselectedvalue = "";
            int value1 = 0;
            int value2 = 0;
            if (selectedtag == "")
            {
                if (selected.Text != "")
                {
                    change = true;
                    selectedtag = selected.Tag.ToString();
                    selectedvalue = selected.Text;
                    selected.BackColor = Color.LightGray;

                    SwitchColor(selectedtag);

                }
                else
                {
                    selectedtag = "";
                    selectedvalue = "";
                }
            }
            else
            {
                newselectedtag = selected.Tag.ToString();
                if (newselectedtag != selectedtag)
                {
                    change = true;
                    newselectedvalue = selected.Text;
                    value1 = int.Parse(selectedvalue);
                    value2 = int.Parse((newselectedvalue == "" ? "0" : newselectedvalue));
                    string[] coord1 = selectedtag.Split(new char[] { ',' });
                    string[] coord2 = newselectedtag.Split(new char[] { ',' });
                    int x1 = int.Parse(coord1[0]);
                    int y1 = int.Parse(coord1[1]);

                    int x2 = int.Parse(coord2[0]);
                    int y2 = int.Parse(coord2[1]);


                    if (IsMoveAllowed(x1, y1, x2, y2, value1, value2))
                    {
                        SwapValueByTag(selectedtag, selectedvalue, newselectedtag, newselectedvalue);
                        if (CheckPuzzle())
                        {
                            MessageBox.Show("Congratulations");
                        }

                    }
                    else
                    {
                        SwitchColor("");
                        selectedtag = "";
                        selectedvalue = "";
                    }

                    selectedtag = "";

                }
                else
                {
                    SwitchColor("");
                    selectedtag = "";
                    selectedvalue = "";

                }
            }

        }
        public void SwitchColor(string tag)
        {
            foreach (var c in pnlPuzzle.Controls)
            {
                if (((Label)c).Tag.ToString() == tag)
                {
                    ((Label)c).BackColor = Color.LightGray;
                }
                else
                {
                    if (((Label)c).Text != "")
                    {
                        ((Label)c).BackColor = Color.White;
                    }
                    else
                    {
                        ((Label)c).BackColor = Color.DarkGray;
                    }
                }
            }
        }
        public void SwapValueByTag(string tag1,string value1,string tag2,string value2)
        {
            foreach(var c in pnlPuzzle.Controls)
            {
                if (((Label)c).Tag.ToString() == tag1)
                {
                    ((Label)c).Text = value2;
                    ((Label)c).BorderStyle = BorderStyle.None;
                    ((Label)c).BackColor = Color.DarkGray;

                    break;
                }
            }
            foreach (var c in pnlPuzzle.Controls)
            {
                if (((Label)c).Tag.ToString() == tag2)
                {
                    ((Label)c).Text = value1;
                    ((Label)c).BorderStyle = BorderStyle.Fixed3D;
                    ((Label)c).BackColor = Color.White;
                    break;
                }
            }
        }
        bool IsMoveAllowed(int x1,int y1,int x2,int y2,int value1,int value2)
        {
            int diff_x = (x1 > x2 ? x1 - x2 : x2 - x1);
            int diff_y = (y1 > y2 ? y1 - y2 : y2 - y1);
            bool bvalue = false;
            if (value1 == 0 && value2>0)
            {
                bvalue= true;
            }
            else if (value1 > 0 && value2 == 0)
            {
                bvalue= true;
            }
            else
            {
                bvalue= false;
            }
            if(diff_x==1 && diff_y == 0 && bvalue==true)
            {
                return true;
            }
            if (diff_x == 0 && diff_y==1 && bvalue == true)
            {
                return true;
            }
            return false;
        }
        List<int> GenerateNumbers(int num)
        {
            Random r = new Random();
            List<int> _nums = new List<int>();
            while (_nums.Count < (num-1))
            {
                int newnum = r.Next(1, num);
                if (_nums.IndexOf(newnum) < 0)
                {
                    _nums.Add(newnum);
                }

            }
            return _nums;
        }
        bool IsPerfectSquare(int num)
        {
            double n = Math.Round(Math.Sqrt(num), 1);
            if ((n * n) == num)
            {
                return true;
            }
            return false;
        }
        bool CheckPuzzle()
        {
            for(int x=0;x<pnlPuzzle.Controls.Count;x++)
            {
                if(x == (pnlPuzzle.Controls.Count - 1))
                {
                    if (((Label)pnlPuzzle.Controls[x]).Text != (x + 1).ToString())
                    {
                        return true;
                    }
                }
                else {
                    if (((Label)pnlPuzzle.Controls[x]).Text != (x + 1).ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings fs = new frmSettings();
            if (fs.ShowDialog() == DialogResult.OK)
            {
                resize = false;
                change = false;
                puzzlecount = fs.Count;
                CreateGrid(puzzlecount * puzzlecount);
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (change == false)
            {
                resize = true;
                CreateGrid(puzzlecount * puzzlecount);
            }
    
            
        }
    }

}
