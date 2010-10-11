using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationLogic.Interfaces
{
    public interface IStockItemView
    {
        String StockCode { get; set; }
        String Name { get; }
        String SupplierName { get; set; }
        double UnitCost { get; set; }
        int CurrentStock { get; set; }
        int Price { get; set; }
        
        bool IsChanged();

        bool ConfirmChanges();
    }
}
