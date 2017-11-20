using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP=Microsoft.SharePoint.Client;

namespace SIRTHandler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string siteUrl = textBox1.Text;
            SP.ClientContext clientContext = new SP.ClientContext(siteUrl);
            SP.Web oWebsite = clientContext.Web;
            SP.ListCollection collList = oWebsite.Lists;

            clientContext.Load(collList);

            clientContext.ExecuteQuery();
            string data = "";
            foreach (SP.List oList in collList)
            {
                data= "Title: "+oList.Title + "Created: "+oList.Created.ToString();
                comboBox1.Items.Add(data);
            }
        }
    }
}
