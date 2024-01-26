using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace ContactManager.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage = "Please enter a first name.")]
        public string Firstname { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a last name.")]
        public string Lastname { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a phone number.")]
        public string Phone { get; set; } = null!;
        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = null!;

        public string Slug => Firstname?.Replace(' ', '-').ToLower() + '_' + Lastname?.Replace(' ', '-').ToLower();

        [Required(ErrorMessage = "Please select a category.")]
        public string CategoryId { get; set; } = string.Empty;

        [ValidateNever]
        public Category Category { get; set; } = null!;
    }
}
