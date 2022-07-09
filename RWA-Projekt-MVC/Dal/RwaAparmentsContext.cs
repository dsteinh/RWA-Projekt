using RWA_Projekt_MVC.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace RWA_Projekt_MVC.Dal
{
    public partial class RwaAparmentsContext : DbContext
    {
        public RwaAparmentsContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<ApartmentOwner> ApartmentOwners { get; set; }
        public virtual DbSet<ApartmentPicture> ApartmentPictures { get; set; }
        public virtual DbSet<ApartmentReservation> ApartmentReservations { get; set; }
        public virtual DbSet<ApartmentReview> ApartmentReviews { get; set; }
        public virtual DbSet<ApartmentStatus> ApartmentStatus { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TaggedApartment> TaggedApartments { get; set; }
        public virtual DbSet<TagType> TagTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.ApartmentReservations)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.ApartmentReviews)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.TaggedApartments)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApartmentOwner>()
                .HasMany(e => e.Apartments)
                .WithRequired(e => e.ApartmentOwner)
                .HasForeignKey(e => e.OwnerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApartmentPicture>()
                .Property(e => e.Base64Content)
                .IsUnicode(false);

            modelBuilder.Entity<ApartmentReservation>()
                .Property(e => e.UserPhone)
                .IsFixedLength();

            modelBuilder.Entity<ApartmentStatus>()
                .HasMany(e => e.Apartments)
                .WithRequired(e => e.ApartmentStatus)
                .HasForeignKey(e => e.StatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.ApartmentReservations)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.ApartmentReviews)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.TaggedApartments)
                .WithRequired(e => e.Tag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TagType>()
                .HasMany(e => e.Tags)
                .WithRequired(e => e.TagType)
                .HasForeignKey(e => e.TypeId)
                .WillCascadeOnDelete(false);
        }
    }
}
