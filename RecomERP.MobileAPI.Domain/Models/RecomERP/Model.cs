using System.ComponentModel.DataAnnotations.Schema;

namespace RecomERP.MobileAPI.Domain.Models.RecomERP
{
    [Table("Model")]
    public class Model : BaseEntity
    {
        public int ModelID { get; set; }
        public int? BrandID { get; set; }
        public string? BrandCode { get; set; }
        public int? OrgID { get; set; }
        public int? DisplayOrder { get; set; }

        public string? ModelName { get; set; }
        public string? ModelCode { get; set; }
        public string? ModelImage { get; set; }
        public string? CategoryType { get; set; }
        public string? ModelPrefix { get; set; }

    }
}
