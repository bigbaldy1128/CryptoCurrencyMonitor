using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Flurl.Http;

using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;

namespace CryptoCurrencyMonitor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Handle_Clicked_Get_Data(null, null);
        }

        private LocalData localData;
        private string localFilePath;

        async void Handle_Clicked_Get_Data(object sender, System.EventArgs e)
        {
            button_get_data.IsEnabled = false;
            var data = await GetResult();
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
            ClearLocalData();
        }

        private class RemoteData
        {
            public string address;
            public long quantity;
            public long deltaQuantity;
        }

        private class LocalData
        {
            public string address;
            public long firstQuantity;
            public DateTime timestamp;
        }

        private async Task<RemoteData> GetResult()
        {
            RemoteData ret = new RemoteData();
            string json = await "https://dncapi.bqrank.net/api/v3/coin/holders?code=dogecoin&webp=1".GetStringAsync();
            JObject jObject = JObject.Parse(json);
            string address = (string)jObject["data"]["flows"][0]["address"];

            if (localData != null && localData.address != null && localData.address != address)
            {
                await DisplayAlert("Alert", "Address has been changed", "OK");
                localData = null;
            }

            ret.address = address;

            long quantity = (long)double.Parse(await ("https://dogechain.info/chain/Dogecoin/q/addressbalance/" + address).GetStringAsync());
            ret.quantity = quantity;

            LoadLocalData();
            if (localData.firstQuantity != 0)
            {
                ret.deltaQuantity = quantity - localData.firstQuantity;
            }
            else
            {
                localData.firstQuantity = quantity;
                localData.address = address;
                SaveLocalData();
            }
            return ret;
        }

        private string GetLocalFilePath()
        {
            if (localFilePath != null)
            {
                return localFilePath;
            }
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            localFilePath = Path.Combine(basePath, "db.json");
            return localFilePath;
        }

        private void LoadLocalData()
        {
            if (localData != null)
            {
                return;
            }
            if (!File.Exists(GetLocalFilePath()))
            {
                localData = new LocalData();
                return;
            }
            string json = File.ReadAllText(GetLocalFilePath());
            localData = JsonConvert.DeserializeObject<LocalData>(json);
            if (localData.timestamp != null)
            {
                label_timestamp.Text = localData.timestamp.ToString("yyyy-MM-dd HH:mm");
            }
        }

        private void SaveLocalData()
        {
            localData.timestamp = DateTime.Now;
            label_timestamp.Text = localData.timestamp.ToString("yyyy-MM-dd HH:mm");
            string json = JsonConvert.SerializeObject(localData);
            File.WriteAllText(GetLocalFilePath(), json);
        }

        private void ClearLocalData()
        {
            localData = null;
            if (File.Exists(GetLocalFilePath()))
            {
                File.Delete(GetLocalFilePath());
            }
        }

    }
}
