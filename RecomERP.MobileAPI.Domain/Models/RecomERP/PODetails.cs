namespace RecomERP.MobileAPI.Domain.Models.RecomERP
{
    public class PODetails
    {
        public int PODetailID { get; set; }
        public int POMasterID { get; set; }

        public string? ReferenceNo { get; set; }
        public string? POType { get; set; }

        public int? BrandID { get; set; }
        public int? ModelID { get; set; }
        public string? ItemName { get; set; }
        public int? ReceivedQuantity { get; set; }
        public int? InvoicedQty { get; set; }

        public double? UnitPrice { get; set; }
        public double? Tax { get; set; }
        public double? SubTotal { get; set; }

        public string? PID { get; set; }
        public double? Amount { get; set; }

        public double? CGSTRate { get; set; }
        public double? CGSTAmount { get; set; }

        public double? SGSTRate { get; set; }
        public double? SGSTAmount { get; set; }

        public double? IGSTRate { get; set; }
        public double? IGSTAmount { get; set; }

        public double? ExemptedAmount { get; set; }
        public double? TCSAmount { get; set; }

        public string? Grade { get; set; }

        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? DeleteRemarks { get; set; }

    }
}
