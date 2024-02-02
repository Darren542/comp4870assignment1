using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Comp484Project.Models;

namespace comp4870assignment1.Models;

public class Manifest
{
    [Key]
    public int ManifestId { get; set; }
    [Required]
    public int MemberId { get; set; }
    [ForeignKey("MemberId")]
    public Member? Member { get; set; }
    public int? TripId { get; set; }
    public string? Notes { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
}
