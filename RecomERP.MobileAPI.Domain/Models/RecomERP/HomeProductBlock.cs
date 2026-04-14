using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecomERP.MobileAPI.Domain.Models.RecomERP
{
    [Table("HomeProductBlocks")]
    public class HomeProductBlock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductBlockId { get; set; }
        public string? Title { get; set; }
        public string? PageHeading { get; set; }
        public string? Description { get; set; }
        public string? Remarks { get; set; }
        public int? DisplayOrder { get; set; }
        public int? HomeProductBlockId { get; set; }
        public string? BannerType { get; set; }
        public string? BannerImage { get; set; }
        public string? PageCategory { get; set; }
        public DateTime? ValidFrom { get; set; }
        public string? ValidFromTime { get; set; }
        public DateTime? ValidTill { get; set; }
        public string? ValidTillTime { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; }
    }
}