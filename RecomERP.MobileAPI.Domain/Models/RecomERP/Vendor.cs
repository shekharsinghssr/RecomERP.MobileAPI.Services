using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecomERP.MobileAPI.Domain.Models.RecomERP
{
    [Table("VendorDetails")]
    public class Vendor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VendorID { get; set; }

        public string VendorGUID { get; set; } = string.Empty;

        public string? VendorType { get; set; }

        public string? VendorCode { get; set; }

        public string? VendorName { get; set; }

        public string? BusinessName { get; set; }

        public string? ContactNo { get; set; }

        public string? RegdAddress { get; set; }

        public string? VendorCity { get; set; }

        public string? VendorState { get; set; }

        public int? ZipCode { get; set; }

        public string? DealsIn { get; set; }

        public string? Remarks { get; set; }

        public string GSTINNo { get; set; } = string.Empty;

        public string? DocumentNo { get; set; }

        public string? KAM { get; set; }

        public DateTime? CreatedOn { get; set; } = DateTime.Now;

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsVerified { get; set; } = false;

        public bool? IsActive { get; set; } = true;
    }
}
