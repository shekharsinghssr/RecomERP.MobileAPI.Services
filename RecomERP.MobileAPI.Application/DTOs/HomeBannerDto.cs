namespace RecomERP.MobileAPI.Application.DTOs
{
    public class HomeBannerDto
    {
        public int ID { get; set; }
        public int? PageID { get; set; }
        public string? BannerImage { get; set; }
        public string? Link { get; set; }
        public int? BannerType { get; set; }
        public string? BannerText { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTill { get; set; }
        public string? StateName { get; set; }
        public int? StateCode { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
    }
}