using System.Threading.Tasks;

namespace YukikaHub.UI.ViewModels
{
    public interface IDetailViewModel
    {
        Task LoadAsync(object parameter);
    }
}