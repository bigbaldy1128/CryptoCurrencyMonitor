using System.Threading.Tasks;
using Xamarin.Forms;
using CryptoCurrencyMonitor.Business;

namespace CryptoCurrencyMonitor
{
    public partial class MainPage : ContentPage, IMainPage
    {
        DataHelper dataHelper;
        public MainPage()
        {
            InitializeComponent();
            dataHelper = new DataHelper(this, Business.Type.OperatingSystem.ANDROID);
            Handle_Clicked_Get_Data(null, null);
        }

        async void Handle_Clicked_Get_Data(object sender, System.EventArgs e)
        {
            button_get_data.IsEnabled = false;
            var data = await dataHelper.GetResult();
            editor_address.Text = data.address;
            label_quantity.Text = data.quantity.ToString("N0");
            label_delta_quantity.Text = "";
            if (data.deltaQuantity > 0)
            {
                label_delta_quantity.TextColor = Color.Red;
                label_delta_quantity.Text = "+";
            }
            else if (data.deltaQuantity < 0)
            {
                label_delta_quantity.TextColor = Color.Green;
            }
            else
            {
                label_delta_quantity.TextColor = Color.Black;
            }
            if (data.deltaQuantity != 0)
            {
                label_delta_quantity.Text += data.deltaQuantity.ToString("N0");
            }
            button_get_data.IsEnabled = true;
        }

        void Handle_Clicked_Clear(object sender, System.EventArgs e)
        {
            editor_address.Text = null;
            label_quantity.Text = null;
            label_delta_quantity.Text = null;
            label_timestamp.Text = null;
            dataHelper.ClearLocalData();
        }

        public void SetLableTimestamp(string str)
        {
            label_timestamp.Text = str;
        }

        public new Task DisplayAlert(string title, string message, string cancel)
        {
            return base.DisplayAlert("Alert", "Address has been changed", "OK");
        }
    }
}
