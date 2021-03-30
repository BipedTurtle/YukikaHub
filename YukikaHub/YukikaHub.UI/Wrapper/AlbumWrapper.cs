using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using YukikaHub.Model;

namespace YukikaHub.UI.Wrapper
{
    public class AlbumWrapper : ModelWrapper<Album>
    {
        public AlbumWrapper(Album album)
            : base(album)
        {

        }

        public int Id { get => base.GetValue<int>(); }

        public byte[] Picture
        {
            get => GetValue<byte[]>();
            set { SetValue<byte[]>(value); }
        }

        public BitmapImage Image
        {
            get
            {
                using var stream = new MemoryStream(this.Picture);

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        public ObservableCollection<Song> Songs
        {
            get => GetValue<ObservableCollection<Song>>();
            set { SetValue<ObservableCollection<Song>>(value); }
        }

        public string Title
        {
            get => GetValue<string>();
            set { SetValue<string>(value); }
        }

        public double Price
        {
            get => GetValue<double>();
            set { SetValue<double>(value); }
        }

        public DateTime Released
        {
            get => GetValue<DateTime>();
            set { SetValue<DateTime>(value); }
        }

        public string Distribution
        {
            get => GetValue<string>();
            set { SetValue<string>(value); }
        }

        private readonly DateTime KikaBirthDate = new DateTime(1993, 2, 16);
        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Released):
                    if (Released <= KikaBirthDate)
                        yield return "The release date can't be earlier than Kika's birthdate";
                    break;
                default:
                    break;
            }
        }
    }
}