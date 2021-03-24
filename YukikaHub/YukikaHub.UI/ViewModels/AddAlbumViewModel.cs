using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YukikaHub.UI.ViewModels
{
    public class AddAlbumViewModel : ViewModelBase, IDetailViewModel
    {
        public AddAlbumViewModel()
        {
            this.BrowseImageCommand = new DelegateCommand(this.BrowseImage_Execute);   
        }


        #region Commands
        public ICommand BrowseImageCommand { get; }
        public ICommand AddSongCommand { get; }
        public ICommand RemoveSongCommand { get; }
        public ICommand UploadAlbumCommand { get; }
        #endregion

        #region Command Handlers
        public void BrowseImage_Execute()
        {

        }
        #endregion
    }
}