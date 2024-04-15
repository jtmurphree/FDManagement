namespace FDManagement.Models.DTO
{
    public class ApparatusRequestDto
    {
        public string UnitNum { get; set; }
        public string Make {  get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public int? Mileage { get; set; }
        public DateTime? MileageDate { get; set; }
        public int? ApparatusTypeID { get; set; }
        public string ApparatusType { get; set; }
        public string FuelType { get; set; }
        public string driveType { get; set; }
        public int? FuelTypeID { get; set; }
        public int? DriveTypeID { get; set; }
        public DateTime DateAdded {  get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
