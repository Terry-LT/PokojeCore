using PokojeCore.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PokojeCore.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public List<Reservation> Reservations { get; set; } = new();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email {  get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; } 
        public string BirthCity { get; set; } = string.Empty;
        public string BirthCountry { get; set; } = string.Empty;
        public string IdDocument { get; set; } = string.Empty; 
        public string VisaNumber { get; set; } = string.Empty;
        public DocumentType? DocumentType {  get; set; }
        public string VisaPlaceOfIssue {  get; set; } = string.Empty;
        public VisaType? VisaType { get; set; }
        public string CountryOfResidence { get; set; } = string.Empty; //For the demo will be string. In future will be a Adress model
        public string Street { get; set; } = string.Empty; //For the demo will be string. In future will be a Adress model
        public string HouseNumber { get; set; } = string.Empty; //For the demo will be string. In future will be a Adress model
        public string ZipCode { get; set; } = string.Empty; //For the demo will be string. In future will be a Adress model
        public string Notes {  get; set; } = string.Empty; //for the demo will be string. In future will be a model

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


    }
}
