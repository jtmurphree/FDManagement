namespace FDManagement.Models.DTO
{
    public class ItemsDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public decimal? Value { get; set; }
        public int? Category {  get; set; }
    }
}
