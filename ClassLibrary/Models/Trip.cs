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

    [Required]
    public DateOnly? Date { get; set; }

    [Required]
    public TimeOnly? Time { get; set; }

    [Display(Name = "Destination Address")]
    public string? DestinationAddress { get; set; }

    [Display(Name = "Meeting Address")]
    public string? MeetingAddress { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    public string? CreatedBy { get; set; }
    
    public string? ModifiedBy { get; set; }

    [ForeignKey("VehicleId")]
    public Vehicle? Vehicle { get; set; }
}
