using CryptoCurrencyMonitor.Business;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoCurrencyMonitor.WinFormsApp
{
    public partial class Form1 : Form, IMainPage
    {
        DataHelper dataHelper;
        public Form1()
        {
            InitializeComponent();
            dataHelper = new DataHelper(this, Business.Type.OperatingSystem.WINDOWS);
            button1_Click(null, null);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button_get_data.Enabled = false;
            var data = await dataHelper.GetResult();
            editor_address.Text = data.address;
            label_quantity.Text = data.quantity.ToString("N0");
            label_delta_quantity.Text = "";
            if (data.deltaQuantity > 0)
            {
                label_delta_quantity.ForeColor = Color.Red;
                label_delta_quantity.Text = "+";
            }
            else if (data.deltaQuantity < 0)
            {
                label_delta_quantity.ForeColor = Color.Green;
            }
            else
            {
                label_delta_quantity.ForeColor = Color.Black;
            }
            if (data.deltaQuantity != 0)
            {
                label_delta_quantity.Text += data.deltaQuantity.ToString("N0");
            }
            button_get_data.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            editor_address.Text = null;
            label_quantity.Text = null;
            label_delta_quantity.Text = null;
            label_timestamp.Text = null;
            dataHelper.ClearLocalData();
        }

        public Task DisplayAlert(string title, string message, string cancel)
        {
            return Task.FromResult(MessageBox.Show(message, title, MessageBoxButtons.OK));
        }

        public void SetLableTimestamp(string str)
        {
            label_timestamp.Text = str;
        }
    }
}
