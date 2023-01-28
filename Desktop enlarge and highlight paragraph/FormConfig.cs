using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Desktop_enlarge_and_highlight_paragraph
{
    public partial class FormConfig : Form
    {
        Size picsize;
        Size dfs;

        public FormConfig(Size s, Size defaultSize)
        {
            InitializeComponent();

            labelWidth.Text = "Width : " + s.Width;
            labelHeight.Text = "Height : " + s.Height;
            picsize = s;
            dfs = defaultSize;
            
            numericUpDown1.Value = s.Width;
            numericUpDown2.Value = s.Height;

            checkBox1.Checked = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            var videoDevicesList = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo videoDevice in videoDevicesList)
            {
                comboBoxVideoSource.Items.Add(videoDevice.Name);
            }

            String line;
            try
            {
               
                StreamReader sr = new StreamReader("myco.ini");
                line = sr.ReadLine();

                if (line != "")
                {
                    comboBoxVideoSource.SelectedIndex = Convert.ToInt32(line);
                    //comboBoxVideoSource.Text = line;
                }

                sr.Close();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                StreamWriter w = new StreamWriter("s.ini");
                //sw.WriteLine(comboBoxVideoSource.SelectedIndex.ToString());
                w.WriteLine(numericUpDown1.Value + " " + numericUpDown2.Value);
                w.Close();

                StreamWriter sw = new StreamWriter("myco.ini");
                sw.WriteLine(comboBoxVideoSource.SelectedIndex.ToString());
                //sw.WriteLine(comboBoxVideoSource.Text);
                sw.Close();

                

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void FormConfig_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown1.Value = Convert.ToInt32(Convert.ToDouble(numericUpDown2.Value) * 8.5 / 11);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown2.Value = Convert.ToInt32(Convert.ToDouble(numericUpDown1.Value) * 11 / 8.5);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            numericUpDown1.Value = dfs.Width;
            numericUpDown2.Value = dfs.Height;
        }
    }
}
