using System;
namespace ApplicationLogic.Interfaces
{
    public interface IStockItemView
    {
        int CurrentStock { get; }
        string ItemName { get; }
        int RequiredStock { get; }
        string StockCode { get; }
        string SupplierName { get; }
        double UnitCost { get; }
    }
}
