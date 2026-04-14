using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecomERP.MobileAPI.Domain.Models.RecomERP
{
    [Table("Brand")]
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandID { get; set; }

        public int? OrgID { get; set; }

        public string BrandName { get; set; } = string.Empty;

        public string? BrandCode { get; set; }

        public string DeviceType { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? BrandLogo { get; set; }

        public int? DisplayOrder { get; set; }

        public string? OriginCountry { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
    }
}
