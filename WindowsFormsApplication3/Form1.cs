using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        feed CurrentFeed;
        decimal timeLeft;
        bool countactive = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                listView1.Clear();
                webBrowser1.Navigate("about:blank");
                CurrentFeed = new feed(textBox1.Text);
                foreach (item feedItem in CurrentFeed.Items)
                {
                    ListViewItem listViewItem = new ListViewItem(feedItem.title);
                    listViewItem.Name = feedItem.title;
                    listView1.Items.Add(listViewItem);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && CurrentFeed != null && CurrentFeed.Items.Count > 0)
            {
                webBrowser1.DocumentText = CurrentFeed.Items.GetItem(listView1.SelectedItems[0].Text).description;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                label1.Text = timeLeft + " секунд до обновления";
            }
            else
            {
                timer1.Stop();
                countactive = false;
                label1.Text = "Секунд до обновления";
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    listView1.Clear();
                    webBrowser1.Navigate("about:blank");
                    CurrentFeed = new feed(textBox1.Text);
                    foreach (item feedItem in CurrentFeed.Items)
                    {
                        ListViewItem listViewItem = new ListViewItem(feedItem.title);
                        listViewItem.Name = feedItem.title;
                        listView1.Items.Add(listViewItem);
                    }
                }


            }
        }

        private void label1_Click(object sender, EventArgs e)
        {            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (countactive == true)
            {
                timer1.Stop();
                countactive = false;                
                label1.Text = "Секунд до обновления";

            }
            else
            {
                timer1.Start();
                countactive = true;
                timeLeft = numericUpDown1.Value;                
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            countactive = false;
            label1.Text = "Секунд до обновления";
        }
    }
}
    
