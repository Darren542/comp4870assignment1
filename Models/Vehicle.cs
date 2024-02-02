using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Comp484Project.Models;

namespace comp4870assignment1.Models;

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
    public string? MemberName { get; set; }
    [ForeignKey("Member")]
    public Member? Member { get; set; }
}
