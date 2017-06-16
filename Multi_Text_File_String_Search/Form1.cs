using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multi_Text_File_String_Search
{
    public partial class Form1 : Form
    {
        public static string filetoload = String.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox2.Text = folderBrowserDialog1.SelectedPath.ToString();
            button1.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (textBox1.Text == @"Text to Search?")
            {
                MessageBox.Show("Please change the text to be searched");
                return;
            }
                DirectoryInfo dinfo = new DirectoryInfo(textBox2.Text);
               
                Regex FileRegex = new Regex(@"\*\.\w\w\w");
            FileInfo[] Files;
            foreach (Match match in FileRegex.Matches(textBox3.Text))
            {
                Files = dinfo.GetFiles(match.Value);
            
            tabControl1.SelectTab(1);

            
            foreach (FileInfo file in Files)
            {
                listBox1.Items.Add(file.Name);
               // listBox1.SelectedIndex = listBox1.Items.Count - 1;
                filetoload = textBox2.Text + "\\" + file.Name;
                richTextBox1.LoadFile(filetoload, RichTextBoxStreamType.PlainText);
                int indexTotext =  richTextBox1.Find(textBox1.Text);
                if (indexTotext >= 0)
                {
                    MessageBox.Show(@"Found an occurance of the string you are looking for in " + file.Name);
                    richTextBox1.SelectionColor = Color.White;
                    richTextBox1.SelectionBackColor = Color.Black;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filetoload = textBox2.Text + @"\" + listBox1.SelectedItem;
            richTextBox1.LoadFile(filetoload, RichTextBoxStreamType.PlainText);
            int indexTotext = richTextBox1.Find(textBox1.Text);
            if (indexTotext >= 0)
            {
                richTextBox1.SelectionStart = indexTotext;
                int wordlength = textBox2.Text.Length;
                richTextBox1.SelectionColor = Color.White;
                richTextBox1.SelectionBackColor = Color.Black;

            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
