/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Base.Audit;

public abstract class Auditable
{
    [Column("created_at_utc")]
    [Required]
    public DateTime CreatedAtUtc { get; protected init; }

    [Column("created_by")] 
    [Required]
    public string CreatedBy { get; protected init; }

    [Column("modified_at_utc")] 
    public DateTime? ModifiedAtUtc { get; protected set; }

    [Column("modified_by")] 
    public string? ModifiedBy { get; protected set; }
}
