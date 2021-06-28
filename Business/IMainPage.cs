using System.Threading.Tasks;

namespace CryptoCurrencyMonitor.Business
{
    public interface IMainPage
    {
        void SetLableTimestamp(string str);
        Task DisplayAlert(string title, string message, string cancel);
    }
}
