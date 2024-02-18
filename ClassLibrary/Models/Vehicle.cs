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
    public string? Model { get; set; }
    public string? Make { get; set; }
    public int? Year { get; set; }
    public int? NumberOfSeats { get; set; }
    public string? VehicleType { get; set; }
    [Required]
    public string? MemberId { get; set; }
    [ForeignKey("Id")]
    public Member? Member { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
}
