using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string strFont;
        float sizeFont;
        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Update();
            DialogResult= DialogResult.OK;
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
            this.Close();   
        }

       

        
        
        //property of buttons 

        public string FontProprety 
        {
            get
            {
                if(radioButton1.Checked==true)
                {
                    strFont = "Times New Roman";
                }

                if(radioButton2.Checked==true)
                {
                    strFont = "Arial";
                }

                if(radioButton3.Checked==true)
                {
                    strFont = "Courier New";
                }
                
                return strFont;
                
            }
            set 
            {
                strFont= value;
                if(strFont == "Times New Roman")
                {
                    radioButton1.Checked= true;
                }

                if(strFont=="Arial")
                {
                    radioButton2.Checked= true;
                }

                if (strFont=="Courier New")
                {
                    radioButton3.Checked= true;
                }
            }
            
        }
            
        public float SizeProprety
        {
            get { 
                if(radioButton4.Checked==true) 
                {
                    sizeFont = 16;
                }
                if(radioButton5.Checked==true)
                {
                    sizeFont = 20;
                }
                if(radioButton6.Checked==true)
                {
                    sizeFont = 24;
                }
       
                return sizeFont; 
            }


            set
            {
                sizeFont = value; 
                if(sizeFont==16)
                { radioButton4.Checked= true; }

                if(sizeFont==20)
                {
                    radioButton5.Checked= true;
                }

                if(sizeFont==24)
                {
                    radioButton6.Checked= true;
                }
            
            }
        }

        public string textBox
        {
            get
            {
                if(textBox2.Text=="")
                {
                    strFont = textBox1.Text;
                }
                else
                {
                    strFont = textBox2.Text;
                }
                return strFont;
            }
            set
            {
                textBox1.Text = value;
            }
        }

        public Color ColorDlg
        {
            get { return colorDialog1.Color; }

            set { colorDialog1.Color = value; }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();

        }
    }
}
