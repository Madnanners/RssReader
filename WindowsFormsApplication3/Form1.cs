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
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                listView1.Clear();              
                CurrentFeed = new feed(textBox1.Text);
                foreach (item feedItem in CurrentFeed.Items)
                    {
                    ListViewItem listViewItem = new ListViewItem(feedItem.title);                    
                    listViewItem.Name = feedItem.title;
                    listView1.Items.Add(listViewItem);
                }
            }
        }   
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && CurrentFeed != null && CurrentFeed.Items.Count > 0)
            {
                webBrowser1.DocumentText = CurrentFeed.Items.GetItem(listView1.SelectedItems[0].Text).description;
            }
        }           
    }
}
