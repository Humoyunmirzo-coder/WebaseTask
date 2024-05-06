﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AutoGenerated;

[Table("task")]
public partial class Task
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("project_id")]
    public int? ProjectId { get; set; }

    [Column("employee_id")]
    public int? EmployeeId { get; set; }

    [Column("taskstatus")]
    public int? Taskstatus { get; set; }

    [Column("starttime", TypeName = "timestamp without time zone")]
    public DateTime? Starttime { get; set; }

    [Column("endtime", TypeName = "timestamp without time zone")]
    public DateTime? Endtime { get; set; }

    [Column("tasklevel")]
    public int? Tasklevel { get; set; }

    [Column("importantlevel")]
    public int? Importantlevel { get; set; }

    [InverseProperty("Task")]
    public virtual ICollection<AssigneeEt> AssigneeEts { get; set; } = new List<AssigneeEt>();

    [ForeignKey("EmployeeId")]
    [InverseProperty("Tasks")]
    public virtual Employee? Employee { get; set; }

    [ForeignKey("ProjectId")]
    [InverseProperty("Tasks")]
    public virtual Project? Project { get; set; }
}
