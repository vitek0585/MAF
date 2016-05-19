using System.Windows.Forms;
using System;
using System.AddIn.Hosting;
using System.Collections.ObjectModel;
using System.Security;
using Demo.HostView;

namespace SampleHost
{
    public partial class Form1 : Form
    {
        Collection<AddInToken> _addinTokens;
        Collection<HostView> _addinList = new Collection<HostView>();
        HostView calcAddin;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            LoadAddins();
        }

        public void LoadAddins()
        {
            // Set root directory for finding Add-ins
            string addinRoot = Environment.CurrentDirectory;

            // Rebuild the add-ins and pipeline components 
            AddInStore.Rebuild(addinRoot);

            // Find add-ins of type HostView
            _addinTokens = AddInStore.FindAddIns(typeof(HostView), addinRoot);

            foreach (AddInToken addinToken in _addinTokens)
            {
            

                // Activate the add-in
                _addinList.Add(addinToken.Activate<HostView>(AddInSecurityLevel.Internet));

                // Display Addin-Details
                richText1.AppendText(String.Format("Loaded Add-in {0} Version {1}", addinToken.Name, addinToken.Version));
            }

            calcAddin = _addinList[0];
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (calcAddin != null)
            {
                //Invoking the AddIn method
                int sum = calcAddin.ComputeSum(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                lblResult.Text = sum.ToString();
            }
            else
                MessageBox.Show("AddIn is not loaded"); 
        }

    }
}
