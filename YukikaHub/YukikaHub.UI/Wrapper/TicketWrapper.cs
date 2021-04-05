using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.Model;

namespace YukikaHub.UI.Wrapper
{
    public class TicketWrapper : ModelWrapper<Ticket>, IImageWrapper
    {
        public TicketWrapper(Ticket ticket) : base(ticket)
        {
            
        }

        public string Title
        {
            get => GetValue<string>();
            set { SetValue<string>(value); }
        }

        public DateTime Date
        {
            get => GetValue<DateTime>();
            set { SetValue<DateTime>(value); }
        }

        public double Price
        {
            get => GetValue<double>();
            set { SetValue<double>(value); }
        }

        public byte[] Image
        {
            get => GetValue<byte[]>();
            set { SetValue<byte[]>(value); }
        }

        public string Description
        {
            get => GetValue<string>();
            set { SetValue<string>(value); }
        }

        public void SetImage(byte[] imageByteStream)
        {
            this.Image = imageByteStream;
        }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Date):
                    var today = DateTime.Today;
                    if (this.Date < today)
                        yield return "The date cannot be before the date today";
                    break;
                default:
                    break;
            }
        }
    }
}
