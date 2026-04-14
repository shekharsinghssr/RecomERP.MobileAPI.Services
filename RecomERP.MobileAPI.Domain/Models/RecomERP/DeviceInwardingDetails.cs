namespace RecomERP.MobileAPI.Domain.Models.RecomERP
{
    public class DeviceInwardingDetails : BaseEntity
    {
        public int DeviceInwardingID { get; set; }
        public string? ProductType { get; set; }
        public string? EntryDetails { get; set; }
        public string? UniqueID { get; set; }
        public string? IMEI { get; set; }
        public string? POReference { get; set; }
        public string? Lot { get; set; }
        public double PurchasePrice { get; set; }
        public string? PurchaseFrom { get; set; }
        public string? PId { get; set; }
        public int BrandID { get; set; }
        public string? Brand { get; set; }
        public int ModelID { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
        public string? RAM { get; set; }
        public string? ROM { get; set; }
        public string? Processor { get; set; }
        public string? SourceGrade { get; set; }
        public string? Remarks { get; set; }
        public bool IsMarginal { get; set; }
        public bool DataProcessed { get; set; }
        public string? VRP { get; set; }
        public string? WSN { get; set; }
        public string? FSN { get; set; }
        public string? COO { get; set; }

    }
}
