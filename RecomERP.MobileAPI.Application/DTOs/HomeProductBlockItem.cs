namespace RecomERP.MobileAPI.Application.DTOs
{
    public class HomeProductBlockItemDto
    {
        public int HomeProductID { get; set; }
        public int? ProductBlockId { get; set; }
        public int? CatId { get; set; }
        public int? ProductID { get; set; }
        public string? SKU { get; set; }
        public string? ItemName { get; set; }
        public float? ListPrice { get; set; }
        public float? DealPrice { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}