using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ReceiptBrowser.ViewModels
{
    public interface IReceiptBrowserCoordinator
    {
        #region Public Methods

        void RouteFromChild(string from, object payload);

        #endregion Public Methods
    }

    public class ReceiptBrowserViewModel : BindableBase, IReceiptBrowserCoordinator, IDisposable
    {
        #region Private Fields

        private FilterViewModel _filterVM;

        private TableViewModel _tableVM;

        private DetailsViewModel _detailsVM;

        #endregion Private Fields

        #region Private Methods

        private void OnReceiptsLoaded(IEnumerable<Receipt> receipts)
        {
            TableVM.Receipts = new ObservableCollection<Receipt>(receipts);
        }

        private void OnReceiptSelected(Receipt receipt)
        {
            DetailsVM.Receipt = receipt;
        }

        #endregion Private Methods

        #region Public Constructors

        public ReceiptBrowserViewModel(IReceiptApi receiptApi)
        {
            _filterVM = new FilterViewModel(receiptApi);
            _tableVM = new TableViewModel();
            _detailsVM = new DetailsViewModel();

            _filterVM.ReceiptsLoaded += OnReceiptsLoaded;
            _tableVM.ReceiptSelected += OnReceiptSelected;
        }

        #endregion Public Constructors

        #region Public Properties

        // публичные свойства для привязки в View
        public FilterViewModel FilterVM => _filterVM;

        public TableViewModel TableVM => _tableVM;

        public DetailsViewModel DetailsVM => _detailsVM;

        #endregion Public Properties

        #region Public Methods

        public void RouteFromChild(string from, object payload)
        {
            if (from == nameof(FilterViewModel))
            {
                if (payload is IEnumerable<Receipt> receipts)
                    TableVM.Receipts = new ObservableCollection<Receipt>(receipts);
            }
        }

        // очистка подписок и ресурсов
        public void Dispose()
        {
            if (_filterVM != null)
                _filterVM.ReceiptsLoaded -= OnReceiptsLoaded;
            if (_tableVM != null)
                _tableVM.ReceiptSelected -= OnReceiptSelected;

            // если у детей есть Dispose — вызываем
            (_filterVM as IDisposable)?.Dispose();
            (_tableVM as IDisposable)?.Dispose();
            (_detailsVM as IDisposable)?.Dispose();
        }

        #endregion Public Methods
    }
}