using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptBrowser
{
    public class Receipt
    {
        #region Public Properties

        public string ReferenceId { get; set; }
        public decimal TotalAmount { get; set; }
        public string CardType { get; set; }

        #endregion Public Properties
    }
}