using System.ComponentModel.DataAnnotations;
using BCrypt.Net;

namespace POC.Webcam.js.Models.Person;

public class PersonViewModel
{
    [Display(Name = "Id", Prompt = "Enter the id")]
    [Required(ErrorMessage = "The Id field is required")]
    [Range(0, long.MaxValue, ErrorMessage = "The Id field must be greater than or equal to 0 and less than 9223372036854775807.")]
    public long Id { get; set; }

    [Display(Name = "Name", Prompt = "Enter the name")]
    [Required(ErrorMessage = "The Name field is required")]
    [StringLength(50, ErrorMessage = "The Name field cannot exceed 50 characters.")]
    public string Name { get; set; }

    [Display(Name = "Birth", Prompt = "Enter the birth")]
    [Required(ErrorMessage = "The Birth field is required")]
    [DataType(DataType.Date, ErrorMessage = "The Date of Birth field is not a valid date.")]
    public DateTime Birth { get; set; }

    [Display(Name = "Email", Prompt = "Enter the email")]
    [Required(ErrorMessage = "The Email field is required")]
    [EmailAddress(ErrorMessage = "Invalid format for the email entered.")]
    [StringLength(50, ErrorMessage = "The Email field cannot exceed 50 characters.")]
    public string Email { get; set; }

    [Display(Name = "Password", Prompt = "Enter the password")]
    [Required(ErrorMessage = "The Password field is required")]
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "The Password field cannot exceed 100 characters.")]
    public string Password { get; set; }

    [Display(Name = "Image", Prompt = "Enter the image")]
    [Required(ErrorMessage = "The Image field is required")]
    public string Image { get; set; }

    public void CypherPassword() => Password = GenerateHash(Password);

    public static string GenerateHash(string text, int workFactor = 11)
    {
        if (text == null)
            return null;

        return BCrypt.Net.BCrypt.EnhancedHashPassword(text, workFactor, HashType.SHA384);
    }

    public static bool ValidateHash(string text, string hash)
    {
        if (text == null || hash == null)
            return false;

        return BCrypt.Net.BCrypt.EnhancedVerify(text, hash, HashType.SHA384);
    }
}