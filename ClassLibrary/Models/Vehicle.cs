using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLibrary.Models;

public class Vehicle
{
    [Key]
    public int VehicleId { get; set; }
    [Required (ErrorMessage = "Model is required")]
    [StringLength(50)]
    public string? Model { get; set; }
    [Required(ErrorMessage = "Make is required")]
    [StringLength(50)]
    public string? Make { get; set; }
    [Range(1900, 2024, ErrorMessage = "Year must be between 1900 and 2024")]
    public int? Year { get; set; }
    [Display(Name = "Number of Seats")]
    [Range(1, 50, ErrorMessage = "Number of seats must be between 1 and 50")]
    public int? NumberOfSeats { get; set; }
    [Display(Name = "Vehicle Type")]
    [StringLength(50)]
    public string? VehicleType { get; set; }
    [Required]
    [Display(Name = "Owner")]
    public string? MemberId { get; set; }
    [ForeignKey("MemberId")]
    public Member? Member { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
}
