namespace Evanto.DAL.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models.DBModels;

    public partial class EvantoContext : DbContext
    {
        public EvantoContext()
            : base("name=EvantoContext")
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<BookingStatus> BookingStatus { get; set; }
        public virtual DbSet<Claim> Claim { get; set; }
        public virtual DbSet<ContentType> ContentType { get; set; }
        public virtual DbSet<CouponType> CouponType { get; set; }
        public virtual DbSet<DiscountCoupon> DiscountCoupon { get; set; }
        public virtual DbSet<DiscountCouponStatus> DiscountCouponStatus { get; set; }
        public virtual DbSet<DiscountType> DiscountType { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventService> EventService { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<FeedbackStatus> FeedbackStatus { get; set; }
        public virtual DbSet<FeedbackType> FeedbackType { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<FileType> FileType { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatus { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServicePacketPeriod> ServicePacketPeriod { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserActivation> UserActivation { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }
        public virtual DbSet<UserEvent> UserEvent { get; set; }
        public virtual DbSet<UserService> UserService { get; set; }
        public virtual DbSet<UserStatus> UserStatus { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<VendorService> VendorService { get; set; }
        public virtual DbSet<VendorServiceExceptionalEvent> VendorServiceExceptionalEvent { get; set; }
        public virtual DbSet<VendorServicePacket> VendorServicePacket { get; set; }
        public virtual DbSet<VendorServicePacketStatus> VendorServicePacketStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<BookingStatus>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<BookingStatus>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<BookingStatus>()
                .HasMany(e => e.Booking)
                .WithRequired(e => e.BookingStatus)
                .HasForeignKey(e => e.StatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Claim>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Claim>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Claim>()
                .HasMany(e => e.UserClaim)
                .WithRequired(e => e.Claim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContentType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ContentType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ContentType>()
                .HasMany(e => e.File)
                .WithRequired(e => e.ContentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CouponType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<CouponType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CouponType>()
                .HasMany(e => e.DiscountCoupon)
                .WithRequired(e => e.CouponType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DiscountCoupon>()
                .Property(e => e.CouponNumber)
                .IsUnicode(false);

            modelBuilder.Entity<DiscountCoupon>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<DiscountCouponStatus>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DiscountCouponStatus>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<DiscountCouponStatus>()
                .HasMany(e => e.DiscountCoupon)
                .WithRequired(e => e.DiscountCouponStatus)
                .HasForeignKey(e => e.StatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DiscountType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DiscountType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<DiscountType>()
                .HasMany(e => e.DiscountCoupon)
                .WithRequired(e => e.DiscountType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.EventService)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.UserEvent)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.VendorServiceExceptionalEvent)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EventService>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<FeedbackStatus>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FeedbackStatus>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<FeedbackStatus>()
                .HasMany(e => e.Feedback)
                .WithRequired(e => e.FeedbackStatus)
                .HasForeignKey(e => e.StatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FeedbackType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FeedbackType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<FeedbackType>()
                .HasMany(e => e.Feedback)
                .WithRequired(e => e.FeedbackType)
                .HasForeignKey(e => e.TypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<File>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<File>()
                .Property(e => e.Extension)
                .IsUnicode(false);

            modelBuilder.Entity<File>()
                .Property(e => e.Path)
                .IsUnicode(false);

            modelBuilder.Entity<File>()
                .Property(e => e.MediaType)
                .IsUnicode(false);

            modelBuilder.Entity<File>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<FileType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FileType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<FileType>()
                .HasMany(e => e.File)
                .WithRequired(e => e.FileType)
                .HasForeignKey(e => e.TypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Amount)
                .HasPrecision(7, 0);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .HasMany(e => e.VendorServicePacket)
                .WithRequired(e => e.Payment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PaymentStatus>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<PaymentStatus>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<PaymentStatus>()
                .HasMany(e => e.Payment)
                .WithRequired(e => e.PaymentStatus)
                .HasForeignKey(e => e.StatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PaymentType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<PaymentType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<PaymentType>()
                .HasMany(e => e.Payment)
                .WithRequired(e => e.PaymentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Service>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.EventService)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.UserService)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.VendorService)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServicePacketPeriod>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ServicePacketPeriod>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ServicePacketPeriod>()
                .HasMany(e => e.VendorServicePacket)
                .WithRequired(e => e.ServicePacketPeriod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Salt)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Booking)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserActivation)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserClaim)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserEvent)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserService)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Vendor)
                .WithRequired(e => e.User);

            modelBuilder.Entity<UserActivation>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<UserActivation>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<UserClaim>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<UserEvent>()
                .Property(e => e.Budget)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserEvent>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<UserEvent>()
                .HasMany(e => e.UserService)
                .WithRequired(e => e.UserEvent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserService>()
                .Property(e => e.Budget)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserService>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<UserStatus>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserStatus>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<UserStatus>()
                .HasMany(e => e.User)
                .WithRequired(e => e.UserStatus)
                .HasForeignKey(e => e.StatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<UserType>()
                .HasMany(e => e.User)
                .WithRequired(e => e.UserType)
                .HasForeignKey(e => e.TypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .HasMany(e => e.Booking)
                .WithRequired(e => e.Vendor)
                .HasForeignKey(e => e.VendorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vendor>()
                .HasMany(e => e.Payment)
                .WithRequired(e => e.Vendor)
                .HasForeignKey(e => e.VendorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vendor>()
                .HasMany(e => e.VendorServicePacket)
                .WithRequired(e => e.Vendor)
                .HasForeignKey(e => e.VendorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VendorService>()
                .Property(e => e.PriceMin)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VendorService>()
                .Property(e => e.PriceMax)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VendorService>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<VendorService>()
                .HasMany(e => e.VendorServiceExceptionalEvent)
                .WithRequired(e => e.VendorService)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VendorServiceExceptionalEvent>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<VendorServicePacket>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<VendorServicePacket>()
                .HasMany(e => e.VendorService)
                .WithRequired(e => e.VendorServicePacket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VendorServicePacketStatus>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<VendorServicePacketStatus>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<VendorServicePacketStatus>()
                .HasMany(e => e.VendorServicePacket)
                .WithRequired(e => e.VendorServicePacketStatus)
                .HasForeignKey(e => e.StatusId)
                .WillCascadeOnDelete(false);
        }
    }
}
