using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Infrastructure;

[Table("projects")]
[Index("IdDept", Name = "projects_id_dept_key", IsUnique = true)]
[Index("IdLocation", Name = "projects_id_location_key", IsUnique = true)]
public partial class Projects
{
    [Key]
    [Column("id_proj")]
    public int IdProj { get; set; }

    [Column("nameproj")]
    [StringLength(100)]
    public string Nameproj { get; set; } = null!;

    [Column("id_dept")]
    public int? IdDept { get; set; }

    [Column("id_location")]
    public int? IdLocation { get; set; }

    [ForeignKey("IdDept")]
    [InverseProperty("Projects")]
    public virtual Departments? IdDeptNavigation { get; set; }

    [ForeignKey("IdLocation")]
    [InverseProperty("Projects")]
    public virtual Locations? IdLocationNavigation { get; set; }

    [InverseProperty("IdProjNavigation")]
    public virtual ICollection<Projemp> Projemp { get; set; } = new List<Projemp>();
}
