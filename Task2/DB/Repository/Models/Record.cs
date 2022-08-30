using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DB.Repository.Models
{
    [Keyless]
    [Table("Record")]

    // EntityFramework, DB-first approach + scaffolding
    // I've created a simple model, but later understood that it should be more complex. 
    //E.g. Geography related properties would be better in a separate table
    //Temperature also should be a nested object to hold different types of temperatures
    public partial class Record
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string? Country { get; set; }
        [StringLength(50)]
        public string? City { get; set; }
        public double? Temperature { get; set; }
        public double? Clouds { get; set; }
        public double? WindSpeed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Datetime { get; set; }
    }
}
