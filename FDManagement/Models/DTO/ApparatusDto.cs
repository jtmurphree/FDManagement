namespace FDManagement.Models.DTO
{
    public class ApparatusDto
    {
        public int ID { get; set; }
        public string UnitNum { get; set; }
        public string Make {  get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public long? Mileage { get; set; }
        public DateTime? MileageDate { get; set; }
        public int? ApparatusType { get; set; }
        public int? FuelType { get; set; }
        public int? DriveType { get; set; }
    }
}
