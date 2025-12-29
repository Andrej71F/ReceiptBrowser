using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace ReceiptBrowser.ViewModels
{
    public class TableViewModel : BindableBase
    {
        #region Private Fields

        private Receipt _selectedReceipt;

        private ObservableCollection<Receipt> _receipts = new();

        #endregion Private Fields

        #region Public Events

        public event Action<Receipt> ReceiptSelected;

        #endregion Public Events

        #region Public Properties

        public ObservableCollection<Receipt> Receipts
        {
            get => _receipts;
            set => SetProperty(ref _receipts, value);
        }

        public Receipt SelectedReceipt
        {
            get => _selectedReceipt;

            set
            {
                if (SetProperty(ref _selectedReceipt, value))
                {
                    ReceiptSelected?.Invoke(value);
                }
            }
        }

        #endregion Public Properties
    }
}