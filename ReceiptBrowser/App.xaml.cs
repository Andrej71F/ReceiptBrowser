using System.Windows;
using Prism.Ioc;
using ReceiptBrowser.ViewModels;
using ReceiptBrowser.Views;

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

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IReceiptApi, ReceiptApiStub>();

            containerRegistry.RegisterSingleton<FilterViewModel>();
            containerRegistry.RegisterSingleton<TableViewModel>();
            containerRegistry.RegisterSingleton<DetailsViewModel>();
            containerRegistry.RegisterSingleton<ReceiptBrowserViewModel>();
        }

        #endregion Protected Methods
    }
}