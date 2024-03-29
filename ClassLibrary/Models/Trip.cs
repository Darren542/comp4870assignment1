using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLibrary.Models;
public class Trip
{
    [Key]
    public int TripId { get; set; }

    [Required]
    public int VehicleId { get; set; }

    [Required (ErrorMessage = "Date is required.")]
    public DateOnly? Date { get; set; }

    [Required (ErrorMessage = "Time is required.")]
    public TimeOnly? Time { get; set; }

    [Display(Name = "Destination Address")]
    [Required (ErrorMessage = "Destination Address is required.")]
    [StringLength(100, ErrorMessage = "Destination Address must be less than 100 characters.")]
    public string? DestinationAddress { get; set; }

    [Display(Name = "Meeting Address")]
    [Required (ErrorMessage = "Meeting Address is required.")]
    [StringLength(100, ErrorMessage = "Meeting Address must be less than 100 characters.")]
    public string? MeetingAddress { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public string? CreatedBy { get; set; }
    
    public string? ModifiedBy { get; set; }

    [ForeignKey("VehicleId")]
    public Vehicle? Vehicle { get; set; }
}
