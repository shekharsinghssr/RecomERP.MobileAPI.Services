using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecomERP.MobileAPI.Domain.Models.RecomERP
{
    [Table("HomeProductBlockItems")]
    public class HomeProductBlockItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HomeProductID { get; set; }
        public int? ProductBlockId { get; set; }
        public int? CatId { get; set; }
        public int? ProductID { get; set; }
        public string? SKU { get; set; }
        public string? ItemName { get; set; }
        public float? ListPrice { get; set; }
        public float? DealPrice { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}