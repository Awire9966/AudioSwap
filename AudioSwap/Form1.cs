using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioSwap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string sp = Application.StartupPath + @"\";
        static string lame = sp + "lame.exe";
        public static void s_lame(string infile, string outfile) 
        {
            Process.Start(lame, "-V2 \"" + infile + "\" " + "\"" + outfile);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(lame) || !File.Exists(sp + "lame_enc.dll"))
            {
                var res = MessageBox.Show("Required Files Not found. Being the good program I am, I come with a copy! Would you like me to extract that copy?", "oops", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(res == DialogResult.Yes)
                {
                    if (!File.Exists(lame))
                    {
                        var resource = Properties.Resources.lame;

                        FileStream fileStream = new FileStream(lame, FileMode.CreateNew);
                        for (int i = 0; i < resource.Length; i++)
                            fileStream.WriteByte((byte)resource[i]);
                        fileStream.Close();
                    }
                    if(!File.Exists(sp +"lame_enc.dll"))
                    {
                        var resource = Properties.Resources.lame_enc;

                        FileStream fileStream = new FileStream(sp + "lame_enc.dll", FileMode.CreateNew);
                        for (int i = 0; i < resource.Length; i++)
                            fileStream.WriteByte((byte)resource[i]);
                        fileStream.Close();
                    }
                }
                if(res == DialogResult.No)
                {
                    var res2 = MessageBox.Show("Okay.. But this program wont work without them. Would you like to get them yourself?", "okay..", MessageBoxButtons.YesNo);
                      if(res == DialogResult.Yes)
                      {
                        Process.Start("https://lame.sourceforge.io/");
                      }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "wave files (*.wav)|*.wav|All files *RISKY* (*.*)|*.*";
            ofd.Title = "Select a Wave File";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text= ofd.FileName;
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "mp3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            sfd.Title = "Save to mp3 File";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = sfd.FileName;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            s_lame(textBox1.Text, textBox2.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "mp3 files (*.mp3)|*.mp3|All files *RISKY* (*.*)|*.*";
            ofd.Title = "Select a mp3 File";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = ofd.FileName;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "wave files (*.wav)|*.wav|All files (*.*)|*.*";
            sfd.Title = "Save to a wave File";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = sfd.FileName;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            s_lame(textBox4.Text, textBox3.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Awire9966/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://lame.sourceforge.io/");
        }
    }
}

