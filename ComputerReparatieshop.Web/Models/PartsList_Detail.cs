namespace ComputerReparatieshop.Web.Models
{
    public class PartsList_Detail
    {
        public int OrderId { get; set; }
        public int PartId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}