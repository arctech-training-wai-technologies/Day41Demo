// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Day41Demo.DataAccess.Models
{
    [Table("commissions", Schema = "sales")]
    public partial class Commission
    {
        [Key]
        [Column("staff_id")]
        public int StaffId { get; set; }
        [Column("target_id")]
        public int? TargetId { get; set; }
        [Column("base_amount", TypeName = "decimal(10, 2)")]
        public decimal BaseAmount { get; set; }
        [Column("commission", TypeName = "decimal(10, 2)")]
        public decimal Commission1 { get; set; }

        [ForeignKey("StaffId")]
        [InverseProperty("Commission")]
        public virtual Staff Staff { get; set; }
        [ForeignKey("TargetId")]
        [InverseProperty("Commissions")]
        public virtual Target Target { get; set; }
    }
}