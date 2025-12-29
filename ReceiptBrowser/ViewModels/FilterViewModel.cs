using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace ReceiptBrowser.ViewModels
{
    public class FilterViewModel : BindableBase
    {
        #region Private Fields

        private readonly IReceiptApi _api;

        #endregion Private Fields

        #region Private Methods

        private void OnLoad()
        {
            var receipts = _api.LoadReceipts();
            ReceiptsLoaded?.Invoke(receipts);
        }

        #endregion Private Methods

        #region Public Constructors

        public FilterViewModel(IReceiptApi api)
        {
            _api = api;
            LoadCommand = new DelegateCommand(OnLoad);
        }

        #endregion Public Constructors

        #region Public Events

        public event Action<IEnumerable<Receipt>> ReceiptsLoaded;

        #endregion Public Events

        #region Public Properties

        public DelegateCommand LoadCommand { get; }

        #endregion Public Properties
    }
}