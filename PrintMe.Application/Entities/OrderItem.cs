using System.ComponentModel.DataAnnotations;

namespace PrintMe.Application.Entities;

public class OrderItem
{
    [Required]
    public string ProductName { get;}
    
    public string PictureUrl { get;}
    
    public decimal UnitPrice { get;}
    
    public decimal Discount { get; private set; }
    
    public int Units { get; private set; }

    public int ProductId { get;}

    protected OrderItem() { }

    public OrderItem(int productId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units = 1)
    {
        if (units <= 0)
        {
            throw new Exception("Invalid number of units");
        }

        if ((unitPrice * units) < discount)
        {
            throw new Exception("The total of order item is lower than applied discount");
        }

        ProductId = productId;
        ProductName = productName;
        UnitPrice = unitPrice;
        Discount = discount;
        Units = units;
        PictureUrl = pictureUrl;
    }
    
    public void SetNewDiscount(decimal discount)
    {
        if (discount < 0)
        {
            throw new Exception("Discount is not valid");
        }

        Discount = discount;
    }

    public void AddUnits(int units)
    {
        if (units < 0)
        {
            throw new Exception("Invalid units");
        }

        Units += units;
    }
    
    public void SetUnits(int units)
    {
        if (units < 0)
        {
            throw new Exception("Invalid units");
        }

        Units = units;
    }
}