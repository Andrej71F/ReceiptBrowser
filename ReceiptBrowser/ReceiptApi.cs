using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptBrowser
{
    public interface IReceiptApi
    {
        #region Public Methods

        IEnumerable<Receipt> LoadReceipts();

        #endregion Public Methods
    }

    public class ReceiptApiStub : IReceiptApi
    {
        #region Public Methods

        public IEnumerable<Receipt> LoadReceipts()
        {
            return new List<Receipt>
            {
                new Receipt { ReferenceId = "1001", TotalAmount = 10, CardType = "VISA" },
                new Receipt { ReferenceId = "1002", TotalAmount = 20, CardType = "MC" }
            };
        }

        #endregion Public Methods
    }
}