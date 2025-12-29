using Prism.Ioc;
using ReceiptBrowser.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReceiptBrowser.Views
{
    /// <summary>
    /// Interaction logic for ReceiptBrowserView.xaml
    /// </summary>
    public partial class ReceiptBrowserView : UserControl
    {
        #region Protected Methods

        protected override void OnInitialized(System.EventArgs e)
        {
            base.OnInitialized(e);

            var container = ContainerLocator.Container;

            DataContext = container.Resolve<ReceiptBrowserViewModel>();
        }

        #endregion Protected Methods

        #region Public Constructors

        public ReceiptBrowserView()
        {
            InitializeComponent();
        }

        #endregion Public Constructors
    }
}