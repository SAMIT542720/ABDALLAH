﻿using ABDALLAH.Data.Base;
using ABDALLAH.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABDALLAH.Models
{
    public class PRODUCT:IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public string? CostumerFullName { get; set; }
        public string? CotumerCity { get; set; }
        public int? CostumerPhoneNumber { get; set; }
        public int? PNumber { get; set; }
        public string? NameFR { get; set; }
        public string? NameAR { get; set; }
        public int? Benefit { get; set; }
        public int? Price { get; set; }
        public string? Description { get; set; }
        public string? Destination { get; set; }
        public DateTime? Date { get; set; }
        public int? Payment { get; set; }
        public int? ShippingPayment { get; set; }
        public int? PRODUCTID { get; set; }
        [ForeignKey("PRODUCTID")]
        public Order? Orders { get; set; }
        public string? Statu { get; set; }
    }
}
