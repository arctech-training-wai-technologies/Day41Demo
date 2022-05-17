﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Day41Demo.DataAccess.Models
{
    [Table("orders", Schema = "sales")]
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("customer_id")]
        public int? CustomerId { get; set; }
        [Column("order_status")]
        public byte OrderStatus { get; set; }
        [Column("order_date", TypeName = "date")]
        public DateTime OrderDate { get; set; }
        [Column("required_date", TypeName = "date")]
        public DateTime RequiredDate { get; set; }
        [Column("shipped_date", TypeName = "date")]
        public DateTime? ShippedDate { get; set; }
        [Column("store_id")]
        public int StoreId { get; set; }
        [Column("staff_id")]
        public int StaffId { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("StaffId")]
        [InverseProperty("Orders")]
        public virtual Staff Staff { get; set; }
        [ForeignKey("StoreId")]
        [InverseProperty("Orders")]
        public virtual Store Store { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}