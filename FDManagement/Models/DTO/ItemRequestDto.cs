namespace FDManagement.Models.DTO
{
    public class ItemRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public decimal? Value { get; set; }
        public int? CategoryID { get; set; }
    }
}
