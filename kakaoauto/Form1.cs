using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace kakaoauto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 9; i++)
            {
                FileInfo file = new FileInfo("value" +i.ToString()+".txt");
                FileStream fs = file.Create();

                fs.Close();
            }

            TextBox[] textbox = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9};
            for(int i = 1; i <= 9; i++)
            {
                Stream FS = new FileStream("value" + i.ToString() + ".txt", FileMode.Create, FileAccess.Write);
                StreamWriter sr = new StreamWriter(FS, Encoding.UTF8);
                sr.WriteLine(textbox[i-1].Text);
                sr.Close();
                sr.Dispose();
            }

            for (int i = 1; i <= 9; i++)
            {
                StreamReader sr = new StreamReader("value" + i.ToString() + ".txt",Encoding.Default);
                movevalue.value[i - 1] = sr.ReadToEnd();
                sr.Close();
            }

            Form2 fomr2 = new Form2();
            fomr2.ShowDialog();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i <= 9; i++)
                {
                    using (StreamReader sr = new StreamReader("value"+i.ToString()+".txt",Encoding.Default))
                    {
                        movevalue.value[i-1] = sr.ReadToEnd();
                        sr.Close();
                    }
                }

                Form2 frm = new Form2();
                frm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
        }
    }
}
