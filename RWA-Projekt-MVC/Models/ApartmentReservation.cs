namespace RWA_Projekt_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ApartmentReservation")]
    public partial class ApartmentReservation
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }

        public int ApartmentId { get; set; }

        [StringLength(1000)]
        [Required]
        public string Details { get; set; }

        public int? UserId { get; set; }

        [StringLength(250)]
        public string UserName { get; set; }

        [StringLength(250)]
        public string UserEmail { get; set; }

        [StringLength(20)]
        public string UserPhone { get; set; }

        [StringLength(1000)]
        public string UserAddress { get; set; }

        public virtual Apartment Apartment { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
