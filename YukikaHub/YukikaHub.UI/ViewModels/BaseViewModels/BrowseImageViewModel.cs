﻿using Microsoft.Win32;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using YukikaHub.UI.Wrapper;

namespace YukikaHub.UI.ViewModels
{
    public abstract class BrowseImageViewModel : ViewModelBase
    {
        protected IImageWrapper _imageWrapper;

        public BrowseImageViewModel()
        {
            this.BrowseImageCommand = new DelegateCommand<object>(this.BrowseImage);
        }

        public ICommand BrowseImageCommand { get; set; }

        public void BrowseImage(object ImageControl)
        {
            var browseImage = (Image)ImageControl;
            var fileDialog = new OpenFileDialog();

            fileDialog.Filter = "Image Files (*.img;*.jpg)|*img;*jpg;*jpeg";
            if (fileDialog.ShowDialog() == false)
                return;

            var uri = new Uri(fileDialog.FileName);
            var bitmapImage = new BitmapImage();
            using (var imageStream = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read))
            {
                bitmapImage.BeginInit();
                bitmapImage.UriSource = uri;
                bitmapImage.StreamSource = imageStream;
                bitmapImage.EndInit();
                browseImage.Source = bitmapImage;

                using (var reader = new BinaryReader(imageStream))
                {
                    var imageByteStream = reader.ReadBytes((int)imageStream.Length);
                    _imageWrapper.SetImage(imageByteStream);
                }
            }
        }
    }
}
