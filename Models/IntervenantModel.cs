namespace Interventions.Models
{
    public class IntervenantModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public char Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Department { get; set; }
        public string CityCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Country { get; set; }
        public int AverageScore { get; set; }
        public bool Archive { get; set; }
    }
}
