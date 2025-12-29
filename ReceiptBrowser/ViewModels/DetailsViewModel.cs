using Prism.Mvvm;

namespace ReceiptBrowser.ViewModels
{
    public class DetailsViewModel : BindableBase
    {
        #region Private Fields

        private Receipt _receipt;

        #endregion Private Fields

        #region Public Properties

        public Receipt Receipt
        {
            get => _receipt;
            set => SetProperty(ref _receipt, value);
        }

        #endregion Public Properties
    }
}