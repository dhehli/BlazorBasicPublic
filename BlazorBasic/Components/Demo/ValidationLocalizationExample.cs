using System.ComponentModel.DataAnnotations;

public class ValidationLocalizationExample

{
    [Required]
    [Display(Name = "PhoneCountryCode")]
    public string PhoneCountryCode { get; set; }

    [Required]
    [Display(Name = "LastName")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Email")]
    [EmailAddress]
    public string Email { get; set; }
}