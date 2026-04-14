namespace RecomERP.MobileAPI.Domain.Models.RecomERP
{
    public class POMaster
    {
        public int? POMasterID { get; set; } = 0;

        public string? VendorGUID { get; set; }
        public string? VendorName { get; set; }
        public string? ReferenceNo { get; set; }
        public string? ProductType { get; set; }
        public DateTime? PODate { get; set; }

        public int? LotID { get; set; }
        public int? OrgID { get; set; }
        public int? SubscriptionID { get; set; }

        public int? Quantity { get; set; }
        public int? OfficeId { get; set; }

        public string? TaxType { get; set; }
        public string? VendorInvoiceNo { get; set; }

        public string? POStatus { get; set; }
        public int? IsMarginable { get; set; }
        public int? State { get; set; }
        public string? Remarks { get; set; }

        public DateTime? CancelledOn { get; set; }
        public int? CancelledBy { get; set; }

        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }


        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

    }


}
