using System.ComponentModel.DataAnnotations;

namespace PrintMe.Application.Model;

public class BasketItem
{
    public string Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal OldUnitPrice { get; set; }
    [Range(1,100)]
    public int Quantity { get; set; }
    public string PictureUrl { get; set; }

    public void Update(BasketItem item)
    {
        this.UnitPrice = item.UnitPrice;
        this.OldUnitPrice = item.OldUnitPrice;
        this.Quantity = item.Quantity;
        this.UnitPrice = item.UnitPrice;
    }
}