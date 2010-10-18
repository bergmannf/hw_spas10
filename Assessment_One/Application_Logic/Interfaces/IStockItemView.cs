using System;
namespace ApplicationLogic.Interfaces
{
    /// <summary>
    /// Utilized by the presenter to get the necessary values from a view.
    /// </summary>
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
