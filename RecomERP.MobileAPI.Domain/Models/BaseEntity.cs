namespace RecomERP.MobileAPI.Domain.Models
{
    public abstract class BaseEntity
    {
        public int? Id { get; set; }
        public string? GUId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
