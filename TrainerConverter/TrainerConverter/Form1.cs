using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TrainerConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UpldTrnr_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.txt";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String path = dialog.FileName;
                string[] text = System.IO.File.ReadAllLines(path);
                //i'm writting on D drive id you have C then change this
                TextWriter txt = new StreamWriter("D:\\CnvTrainer\\trainers.txt");
                for (int i = 0; i < text.Length; i++)
                {
                    string GetTxt = text[i];

                    //Write on txt
                    if (i == 0)
                    {
                        txt.Write(GetTxt);
                    }
                    else
                    {
                        if (text[i] == "#-------------------------------")
                        {
                            txt.Write("\n" + GetTxt);
                        }
                        else
                        {
                            if (GetTxt == "1" || GetTxt == "2" || GetTxt == "3" || GetTxt == "4" || GetTxt == "5" || GetTxt == "6")
                            {

                            }
                            else if (ChkCap(GetTxt) == true)
                            {
                                var endIndex = GetTxt.LastIndexOf(',');
                                if (endIndex != -1)
                                {
                                    txt.Write("\n" + "Pokemon =" + GetTxt);
                                }
                                else
                                {
                                    txt.Write("\n" + "[" + GetTxt + "]");
                                }
                            }
                            else if (ChkCap(GetTxt) == false)
                            {
                                txt.Write("\nLoseText = Test");
                            }
                        }
                    }
                }
                txt.Close();
                MessageBox.Show("Converted!!");
            }
        }

        public static bool ChkCap(string str1)
        {
            return str1 == str1.ToUpper() | str1 == str1.ToLower();
        }
    }
}
