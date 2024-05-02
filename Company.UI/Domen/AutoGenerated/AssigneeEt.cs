﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domen.AutoGenerated;
[Table("assignee_et")]
public partial class AssigneeEt
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }
        
    [Column("task_id")]
    public int TaskId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("AssigneeEts")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("TaskId")]
    [InverseProperty("AssigneeEts")]
    public virtual Task Task { get; set; } = null!;
}
