using System.ComponentModel.DataAnnotations;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using ComputerReparatieshop.Web.Exceptions;

namespace ComputerReparatieshop.Web.Models
{
    public class OrderPart_Detail
    {

        public int OrderId { get; set; }
        public int PartId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Amount { get; set; }
        [RegularExpression(@"^[0-9]{1,16}([,][0-9]{1,3})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal Price { get; set; }

        public OrderPart_Detail(IPartData partData, OrderPart OrderPart)
        {
            Constructor(partData, OrderPart);
        }
        public OrderPart_Detail(IOrderPartData OrderPartData, IPartData partData, int orderId, int OrderPartId)
        {
            OrderPart OrderPart = OrderPartData.Get(orderId, OrderPartId);
            if (OrderPart == null)
            {
                throw new NotFoundInDatabaseException();
            }
            Constructor(partData, OrderPart);
        }

        public OrderPart_Detail(IPartData partData, IOrderPartData OrderPartData, int orderId, int partId)
        {
            OrderPart OrderPart = OrderPartData.Get(orderId, partId);
            Part part = partData.Get(OrderPart.PartId);
            OrderId = OrderPart.OrderId;
            PartId = OrderPart.PartId;
            Name = part.Name;
            Amount = OrderPart.Amount;
            Price = part.Price;
        }

        private void Constructor(IPartData partData, OrderPart OrderPart)
        {
            Part part = partData.Get(OrderPart.PartId);

            OrderId = OrderPart.OrderId;
            PartId = OrderPart.PartId;
            Name = part.Name;
            Amount = OrderPart.Amount;
            Price = part.Price;
        }
    }
}