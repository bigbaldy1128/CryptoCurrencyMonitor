using CryptoCurrencyMonitor.Business.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using System.IO;
using Newtonsoft.Json;

namespace CryptoCurrencyMonitor.Business
{
    public class DataHelper
    {
        private Type.OperatingSystem os;
        private IMainPage page;
        private LocalData localData;
        private string localFilePath;

        public DataHelper(IMainPage page, Type.OperatingSystem os)
        {
            this.page = page;
            this.os = os;
        }

        public async Task<RemoteData> GetResult()
        {
            RemoteData ret = new RemoteData();
            string json = await "https://dncapi.bqrank.net/api/v3/coin/holders?code=dogecoin&webp=1".GetStringAsync();
            JObject jObject = JObject.Parse(json);
            string address = (string)jObject["data"]["flows"][0]["address"];

            if (localData != null && localData.address != null && localData.address != address)
            {
                await page.DisplayAlert("Alert", "Address has been changed", "OK");
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
            string basePath = null;
            if (os == Type.OperatingSystem.ANDROID)
            {
                basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            }
            else if (os == Type.OperatingSystem.WINDOWS)
            {
                basePath = Directory.GetCurrentDirectory();
            }
            localFilePath = Path.Combine(basePath, "db.json");
            return localFilePath;
        }

        public void LoadLocalData()
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
                page.SetLableTimestamp(localData.timestamp.ToString("yyyy-MM-dd HH:mm"));
            }
        }

        public void SaveLocalData()
        {
            localData.timestamp = DateTime.Now;
            page.SetLableTimestamp(localData.timestamp.ToString("yyyy-MM-dd HH:mm"));
            string json = JsonConvert.SerializeObject(localData);
            File.WriteAllText(GetLocalFilePath(), json);
        }

        public void ClearLocalData()
        {
            localData = null;
            if (File.Exists(GetLocalFilePath()))
            {
                File.Delete(GetLocalFilePath());
            }
        }
    }
}
