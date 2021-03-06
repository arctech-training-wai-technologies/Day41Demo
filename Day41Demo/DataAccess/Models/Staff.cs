// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Day41Demo.DataAccess.Models
{
    [Table("staffs", Schema = "sales")]
    [Index("Email", Name = "UQ__staffs__AB6E616413585421", IsUnique = true)]
    public partial class Staff
    {
        public Staff()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("staff_id")]
        public int StaffId { get; set; }
        [Required]
        [Column("first_name")]
        [StringLength(50)]
        [Unicode(false)]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        [StringLength(50)]
        [Unicode(false)]
        public string LastName { get; set; }
        [Required]
        [Column("email")]
        [StringLength(255)]
        [Unicode(false)]
        public string Email { get; set; }
        [Column("phone")]
        [StringLength(25)]
        [Unicode(false)]
        public string Phone { get; set; }
        [Column("active")]
        public byte Active { get; set; }
        [Column("store_id")]
        public int StoreId { get; set; }
        [Column("manager_id")]
        public int? ManagerId { get; set; }

        [ForeignKey("StoreId")]
        [InverseProperty("Staff")]
        public virtual Store Store { get; set; }
        [InverseProperty("Staff")]
        public virtual Commission Commission { get; set; }
        [InverseProperty("Staff")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}