using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormClient
{
    public partial class Form1 : Form
    {
        private int response { get; set; }
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Form1()
        {
            InitializeComponent();
            Logger.Info("Start Application");
        }
    
        public async Task<int> callService(int i)
        {
            try
            { 
            localhost.Service service = new localhost.Service();
            Logger.Info("caling the service at "+service.Url);
            int r =  service.Fibonacci(10);
            Thread.Sleep(2000);
            Logger.Info("Resposne is OK");
            return r;
            }
            catch(Exception e)
            {
                Logger.Error("Error When calling the web Service " + e.Message);
                return 0;
            }
        }

        private async void callCalculateServcie()
        {
            Task<int> taskCalcule = callService(10);

            response =  await taskCalcule;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (BusyForm frm = new BusyForm(callCalculateServcie))
            {

                frm.ShowDialog(this);
                MessageBox.Show("Response : " + response);
            }
        }
    }
}
