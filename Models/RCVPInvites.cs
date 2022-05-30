using System;
using System.ComponentModel.DataAnnotations;


namespace RSVPinvites.Models
{
    public class RSVPinvite
    {
        [Key]
        public int Id { get;set; }
        [Required(ErrorMessage = "Please put your name!")]
        [Display(Name = "Your-Name")]
        [MaxLength(200)]
        [MinLength(2)]
        public string? Name { get;set; }
        [Required(ErrorMessage = "Please put your email")]
        [Display(Name = "Your-Email-Address")]
        public string? Email { get;set; }
        [Required(ErrorMessage = "Please put your city")]
        [Display(Name = "Your-City")]
        [MaxLength(200)]
        public string? City { get;set; }
        [Required]
        public bool? AreYouAttending { get;set; }
        [Required]
        [Display(Name = "Your-donation-Amout")]
        [DataType(DataType.Currency)]
        public string? Donations{ get;set; }
    }
}