﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domen.AutoGenerated;

[Table("assignee")]
public partial class Assignee
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("project_id")]
    public int ProjectId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Assignees")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("ProjectId")]
    [InverseProperty("Assignees")]
    public virtual Project Project { get; set; } = null!;
}
