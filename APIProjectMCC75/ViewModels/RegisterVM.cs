using APIProjectMCC75.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProjectMCC75.ViewModels
{
    public class RegisterVM
    {
        public string Id { get; set; }
        [Display(Name = "Office code")]
        public int OfficeCode { get; set; }
        [Display(Name = "report to")]
        public string? ReportsTo { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Display (Name = "Job Title")]
        public string JobTitle { get; set; }
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
