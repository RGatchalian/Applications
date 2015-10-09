using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private classes.Settings _settings = new classes.Settings();
        private List<classes.GridValue> _gridvalues = new List<classes.GridValue>();
        private bool playerTurn = false;
        private List<classes.Combinations> _combinations = new List<classes.Combinations>();
        private int gridcount = 0;
        private void LoadCombinations()
        {
            _combinations.Add(new classes.Combinations { a = "0", b = "1", c = "2" });
            _combinations.Add(new classes.Combinations { a = "3", b = "4", c = "5" });
            _combinations.Add(new classes.Combinations { a = "6", b = "7", c = "8" });
            _combinations.Add(new classes.Combinations { a = "0", b = "3", c = "6" });
            _combinations.Add(new classes.Combinations { a = "1", b = "4", c = "7" });
            _combinations.Add(new classes.Combinations { a = "2", b = "5", c = "8" });
            _combinations.Add(new classes.Combinations { a = "0", b = "4", c = "8" });
            _combinations.Add(new classes.Combinations { a = "2", b = "4", c = "6" });
            
        }
        public Form1()
        {
            InitializeComponent();
            lblP1.Text = "0";
            lblP2.Text = "0";

            Reset();
        }
        private void Reset()
        {
            gridcount = 0;
            pbTurn.Image = imgList.Images[1];
            _settings.GameType = classes.GameTypeEnum.Player1;
            gbP1.Text = "Player 1";
            gbP2.Text = "Player 2";
            _gridvalues.Clear();
            LoadCombinations();
            ClearGameBox();
        }

        private void ClearGameBox()
        {
            foreach (var c in gbGameBox.Controls)
            {
                if (c is PictureBox)
                {
                    ((PictureBox)c).Image = null;
                }
            }
        }
       

        private void b_Click(object sender, EventArgs e)
        {
            var b = sender;
            bool curturn = playerTurn;
            if (((PictureBox)b).Image == null)
            {
                if (playerTurn == false)
                {
                    ((PictureBox)b).Image = imgList.Images[1];
                    _gridvalues.Add(new classes.GridValue { Tag = ((PictureBox)b).Tag.ToString(), Value = "X" });
                    playerTurn = true;
                }
                else
                {
                    ((PictureBox)b).Image = imgList.Images[0];
                    _gridvalues.Add(new classes.GridValue { Tag = ((PictureBox)b).Tag.ToString(), Value = "O" });
                    playerTurn = false;
                }
                if (CheckGame())
                {
                    playerTurn = curturn;
                    if (playerTurn == false)
                    {

                        lblP1.Text = (int.Parse(lblP1.Text) + 1).ToString();
                    }
                    else
                    {
                        lblP2.Text = (int.Parse(lblP2.Text) + 1).ToString();
                    }
                    if (MessageBox.Show((playerTurn == false ? "Player 1" : "Player 2") + " wins!") == System.Windows.Forms.DialogResult.OK)
                    {
                        Reset();
                        if (playerTurn == false)
                        {
                            pbTurn.Image = imgList.Images[1];
                        }
                        else
                        {
                            pbTurn.Image = imgList.Images[0];
                        }

                        return;
                    }
                }
                else
                {
                    if (playerTurn == false)
                    {
                        pbTurn.Image = imgList.Images[1];
                    }
                    else
                    {
                        pbTurn.Image = imgList.Images[0];
                    }

                }
                if (_gridvalues.Count==9)
                {
                    if (MessageBox.Show("Draw") == System.Windows.Forms.DialogResult.OK)
                    {
                        Reset();
                    }

                }

            }

         }

        private bool CheckGame()
        {
            bool res = false;

            foreach (var c in _combinations)
            {
                string v1 = GetValueByTag(c.a);
                string v2 = GetValueByTag(c.b);
                string v3 = GetValueByTag(c.c);
                if (v1 != "" && v2 != "" && v3 != "")
                {
                    if (v1 == v2 && v2 == v3 && v1 == v3)
                    {
                        return true;
                    }

                }

            }
            return res;
        }
        private string GetValueByTag(string tag)
        {
            foreach(var gv in _gridvalues){
                if (gv.Tag == tag)
                {
                    return gv.Value;
                }
            }
            return "";
        }
    }
}
