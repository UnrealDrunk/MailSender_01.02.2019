

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using MailSender.lib.Services;
using MailSender.lib.Services.Iterfaces2;
using MailSender_01._02._2019.Infrastructure.Services.Interfaces;
using MailSender_01._02._2019.Infrastructure.Services;

namespace MailSender_01._02._2019.ViewModel
{
 
    public class ViewModelLocator
    {
        
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            ///

            var services = SimpleIoc.Default;

            services.Register<MainViewModel>();

            services.Register<IrecipientManager, RecipientsManager>();

            services.Register<IRecipientsStore, RecipientsStoreInMemory>();
            services.Register<IMailStore, MailsStoreInMemory>();
            services.Register<ISenderStore, SendersStoreInMemory>();
            services.Register<IServersStore, ServersStoreInMemory>();

            services.Register<ISenderEditor, WindowSenderEditor>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}