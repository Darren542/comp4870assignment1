using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ClassLibrary.Models;

public class Member : IdentityUser
{
    public Member() : base() { }
    
    [Display(Name = "First Name")]
    [Required (ErrorMessage = "First Name is required")]
    [StringLength(50, ErrorMessage = "First Name must be less than 50 characters")]
    public string? FirstName { get; set; }
    [Display(Name = "Last Name")]
    [Required (ErrorMessage = "Last Name is required")]
    [StringLength(50, ErrorMessage = "Last Name must be less than 50 characters")]
    public string? LastName { get; set; }
    [Display(Name = "Mobile Number")]
    [Phone(ErrorMessage = "Invalid Mobile Number")]
    public string? Mobile { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    [Display(Name = "Postal Code")]
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
}