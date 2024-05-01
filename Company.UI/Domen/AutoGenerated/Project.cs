﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domen.AutoGenerated;

[Table("project")]
public partial class Project
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("ownerid")]
    public int? Ownerid { get; set; }

    [Column("project_type_id")]
    public int? ProjectTypeId { get; set; }

    [Column("project_level_id")]
    public int? ProjectLevelId { get; set; }

    [Column("importance_level_id")]
    public int? ImportanceLevelId { get; set; }

    [Column("appointedday")]
    public DateOnly? Appointedday { get; set; }

    [Column("organizationid")]
    public int? Organizationid { get; set; }

    [Column("assignee_id")]
    public int? AssigneeId { get; set; }

    [ForeignKey("AssigneeId")]
    [InverseProperty("Projects")]
    public virtual Employee? Assignee { get; set; }

    [InverseProperty("Project")]
    public virtual ICollection<Assignee> Assignees { get; set; } = new List<Assignee>();

    [ForeignKey("Organizationid")]
    [InverseProperty("Projects")]
    public virtual Organization? Organization { get; set; }

    [ForeignKey("Ownerid")]
    [InverseProperty("Projects")]
    public virtual User? Owner { get; set; }

    [ForeignKey("ProjectTypeId")]
    [InverseProperty("Projects")]
    public virtual EnumProjectType? ProjectType { get; set; }

    [InverseProperty("Project")]
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
