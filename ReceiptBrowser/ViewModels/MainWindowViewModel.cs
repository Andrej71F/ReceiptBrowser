using Prism.Mvvm;

namespace ReceiptBrowser.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Private Fields

        private string _title = "Receipt Browser";

        #endregion Private Fields

        #region Public Constructors

        public MainWindowViewModel()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        #endregion Public Properties
    }
}