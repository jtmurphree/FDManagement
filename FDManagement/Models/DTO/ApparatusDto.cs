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
        public int? ApparatusTypeID { get; set; }
        public string ApparatusType { get; set; }
        public int? FuelTypeID { get; set; }
        public string FuelType { get; set; }
        public int? DriveTypeID { get; set; }
        public string DriveType { get; set;}
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
