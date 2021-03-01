using System.ComponentModel.DataAnnotations;
using ComputerReparatieshop.Domain.Models;
using ComputerReparatieshop.Domain.Services;
using ComputerReparatieshop.Web.Exceptions;

namespace ComputerReparatieshop.Web.Models
{
    public class PartsList_Detail
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

        public PartsList_Detail(IPartData partData, PartsList partsList)
        {
            Constructor(partData, partsList);
        }
        public PartsList_Detail(IPartsListData partsListData, IPartData partData, int orderId, int partsListId)
        {
            PartsList partsList = partsListData.Get(orderId, partsListId);
            if (partsList == null)
            {
                throw new NotFoundInDatabaseException();
            }
            Constructor(partData, partsList);
        }

        public PartsList_Detail(IPartData partData, IPartsListData partsListData, int orderId, int partId)
        {
            PartsList partsList = partsListData.Get(orderId, partId);
            Part part = partData.Get(partsList.PartId);
            OrderId = partsList.OrderId;
            PartId = partsList.PartId;
            Name = part.Name;
            Amount = partsList.Amount;
            Price = part.Price;
        }

        private void Constructor(IPartData partData, PartsList partsList)
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