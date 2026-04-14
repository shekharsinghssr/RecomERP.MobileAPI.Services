using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecomERP.MobileAPI.Domain.Models.RecomERP
{
    [Table("ThumbBanners")]
    public class ThumbBanner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? PageID { get; set; }
        public string? BannerImage { get; set; }
        public string? Link { get; set; }
        public string? BannerText { get; set; }
        public int? DisplayOrder { get; set; }
        public int ShowForAd { get; set; }
        public int? CategoryGroup { get; set; }
        public bool? IsPriceAutoMapping { get; set; }
        public float? MinPriceRange { get; set; }
        public float? MaxPriceRange { get; set; }
        public string? StateName { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? AddedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
    }
}