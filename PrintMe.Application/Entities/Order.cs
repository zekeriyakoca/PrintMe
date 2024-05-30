using System.ComponentModel.DataAnnotations;
using PrintMe.Application.Enums;

namespace PrintMe.Application.Entities;

public class Order
{
    protected Order()
    {
        OrderItems = new List<OrderItem>();
        _isDraft = false;
    }
    
    private bool _isDraft;
    
    public DateTime OrderDate { get; private set; }

    // Address is a Value Object pattern example persisted as EF Core 2.0 owned entity
    [Required]
    public Address Address { get; private set; }

    public int? BuyerId { get; private set; }

    public OrderStatus OrderStatus { get; private set; }
    
    public string Description { get; private set; }

    public IReadOnlyList<OrderItem> OrderItems { get; }
    
    public int? PaymentId { get; private set; }
    
    public static Order NewDraft()
    {
        var order = new Order
        {
            _isDraft = true
        };
        return order;
    }
    
    public Order(Address address, int buyerId, int paymentMethodId) : this()
    {
        BuyerId = buyerId;
        PaymentId = paymentMethodId;
        OrderStatus = OrderStatus.Started;
        OrderDate = DateTime.UtcNow;
        Address = address;
    }
 
    public void AddOrderItem(int productId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units = 1)
    {
        var existingOrderForProduct = OrderItems.SingleOrDefault(o => o.ProductId == productId);

        if (existingOrderForProduct != null)
        {
            //if previous line exist modify it with higher discount  and units..
            if (discount > existingOrderForProduct.Discount)
            {
                existingOrderForProduct.SetNewDiscount(discount);
            }

            existingOrderForProduct.AddUnits(units);
        }
        else
        {
            //add validated new order item
            var orderItem = new OrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
            _orderItems.Add(orderItem);
        }
    }
    

    public void SetPaidStatus()
    {
        if (OrderStatus == OrderStatus.Started)
        {
            OrderStatus = OrderStatus.Shipped;
            Description = "Order has been shipped";
        }
    }

    public void SetCancelledStatus()
    {
        if (OrderStatus == OrderStatus.Shipped)
        {
            throw new Exception("Order cannot be cancelled, it's already shipped");
        }

        OrderStatus = OrderStatus.Cancelled;
        Description = $"The order was cancelled.";
    }
    
    public void SetDeliveredStatus()
    {
        OrderStatus = OrderStatus.Delivered;
        Description = $"The order has been delivered.";
    }
    
    public void SetReturnedStatus()
    {
        OrderStatus = OrderStatus.Returned;
        Description = $"The order has been returned.";
    }
    
    public void SetCompletedStatus()
    {
        OrderStatus = OrderStatus.Completed;
        Description = $"The order has been complted.";
    }
}