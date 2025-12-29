using Prism.Ioc;
using Prism.Regions;
using ReceiptBrowser.ViewModels;
using ReceiptBrowser.Views;
using System.Windows;

namespace ReceiptBrowser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        #region Protected Methods

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var rm = Container.Resolve<IRegionManager>();
            rm.RequestNavigate("MainRegion", nameof(ReceiptBrowserView));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IReceiptApi, ReceiptApiStub>();

            containerRegistry.RegisterSingleton<FilterViewModel>();
            containerRegistry.RegisterSingleton<TableViewModel>();
            containerRegistry.RegisterSingleton<DetailsViewModel>();

            containerRegistry.RegisterForNavigation<ReceiptBrowserView>();
        }

        #endregion Protected Methods
    }
}