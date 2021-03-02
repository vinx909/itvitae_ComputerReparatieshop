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

        public OrderPart_Detail(IPartData partData, OrderPart partsList)
        {
            Constructor(partData, partsList);
        }
        public OrderPart_Detail(IOrderPartData partsListData, IPartData partData, int orderId, int partsListId)
        {
            OrderPart partsList = partsListData.Get(orderId, partsListId);
            if (partsList == null)
            {
                throw new NotFoundInDatabaseException();
            }
            Constructor(partData, partsList);
        }

        public OrderPart_Detail(IPartData partData, IOrderPartData partsListData, int orderId, int partId)
        {
            OrderPart partsList = partsListData.Get(orderId, partId);
            Part part = partData.Get(partsList.PartId);
            OrderId = partsList.OrderId;
            PartId = partsList.PartId;
            Name = part.Name;
            Amount = partsList.Amount;
            Price = part.Price;
        }

        private void Constructor(IPartData partData, OrderPart partsList)
        {
            Part part = partData.Get(partsList.PartId);

            OrderId = partsList.OrderId;
            PartId = partsList.PartId;
            Name = part.Name;
            Amount = partsList.Amount;
            Price = part.Price;
        }
    }
}