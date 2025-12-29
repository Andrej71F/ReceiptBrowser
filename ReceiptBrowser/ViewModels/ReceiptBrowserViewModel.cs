using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ReceiptBrowser.ViewModels
{
    public class ReceiptBrowserViewModel : BindableBase
    {
        #region Private Fields

        private readonly IContainerProvider _container;

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

        public ReceiptBrowserViewModel(IContainerProvider container)
        {
            _container = container;
        }

        #endregion Public Constructors

        #region Public Properties

        public FilterViewModel FilterVM
        {
            get
            {
                if (_filterVM == null)
                {
                    _filterVM = _container.Resolve<FilterViewModel>();
                    _filterVM.ReceiptsLoaded += OnReceiptsLoaded;
                }
                return _filterVM;
            }
        }

        public TableViewModel TableVM
        {
            get
            {
                if (_tableVM == null)
                {
                    _tableVM = _container.Resolve<TableViewModel>();
                    _tableVM.ReceiptSelected += OnReceiptSelected;
                }
                return _tableVM;
            }
        }

        public DetailsViewModel DetailsVM
        {
            get
            {
                if (_detailsVM == null)
                {
                    _detailsVM = _container.Resolve<DetailsViewModel>();
                }
                return _detailsVM;
            }
        }

        #endregion Public Properties
    }
}