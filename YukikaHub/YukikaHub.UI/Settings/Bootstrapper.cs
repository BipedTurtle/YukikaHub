using Autofac;
using Prism;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.DataAccess;
using YukikaHub.UI.Data;
using YukikaHub.UI.ViewModels;

namespace YukikaHub.UI.Settings
{
    public class Bootstrapper
    {
        private static IContainer _container;
        public static IContainer Container
        {
            get
            {
                if (_container == null)
                    _container = BootsTrap();
                return _container;
            }
        }

        private static IContainer BootsTrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<YukikaHubDbContext>().AsSelf();
            builder.RegisterType<BasicToolbarViewModel>().AsSelf();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<AlbumRepository>().As<IAlbumRepository>();
            builder.RegisterType<SongRepository>().As<ISongRepository>();
            builder.RegisterType<TicketRepository>().As<ITicketRepository>();

            builder.RegisterType<BasicToolbarViewModel>().As<IBasicToolBarViewModel>();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();

            builder.RegisterType<AddAlbumViewModel>()
                   .Keyed<IDetailViewModel>(nameof(AddAlbumViewModel));
            builder.RegisterType<AlbumsViewModel>()
                   .Keyed<IDetailViewModel>(nameof(AlbumsViewModel));
            builder.RegisterType<TicketsViewModel>()
                   .Keyed<IDetailViewModel>(nameof(TicketsViewModel));
            builder.RegisterType<AddModifyTicketViewModel>()
                   .Keyed<IDetailViewModel>(nameof(AddModifyTicketViewModel));

            return builder.Build();
        }
    }
}