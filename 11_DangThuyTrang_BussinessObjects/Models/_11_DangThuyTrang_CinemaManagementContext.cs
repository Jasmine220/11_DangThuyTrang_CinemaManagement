using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _11_DangThuyTrang_BussinessObjects.Models
{
    public partial class _11_DangThuyTrang_CinemaManagementContext : DbContext
    {
        public _11_DangThuyTrang_CinemaManagementContext()
        {
        }

        public _11_DangThuyTrang_CinemaManagementContext(DbContextOptions<_11_DangThuyTrang_CinemaManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Cast> Casts { get; set; } = null!;
        public virtual DbSet<Feature> Features { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<MovieCast> MovieCasts { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleFeature> RoleFeatures { get; set; } = null!;
        public virtual DbSet<Seat> Seats { get; set; } = null!;
        public virtual DbSet<ShowRoom> ShowRooms { get; set; } = null!;
        public virtual DbSet<ShowRoomSeat> ShowRoomSeats { get; set; } = null!;
        public virtual DbSet<ShowTime> ShowTimes { get; set; } = null!;
        public virtual DbSet<Theater> Theaters { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-QN9RQ0F;database=11_DangThuyTrang_CinemaManagement;uid=sa;pwd=123456;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(150)
                    .HasColumnName("username");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Account)
                    .HasForeignKey<Account>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_User");
            });

            modelBuilder.Entity<Cast>(entity =>
            {
                entity.ToTable("Cast");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.ToTable("Feature");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.Property(e => e.Url)
                    .HasMaxLength(150)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.Director)
                    .HasMaxLength(150)
                    .HasColumnName("director");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Language)
                    .HasMaxLength(150)
                    .HasColumnName("language");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.PriceTicket).HasColumnName("price_ticket");

                entity.Property(e => e.PurchaseTime)
                    .HasColumnType("datetime")
                    .HasColumnName("purchase_time");

                entity.Property(e => e.Rated)
                    .HasMaxLength(150)
                    .HasColumnName("rated");

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .HasColumnName("title");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_Movie_Genre");
            });

            modelBuilder.Entity<MovieCast>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MovieCast");

                entity.Property(e => e.CastId).HasColumnName("cast_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Cast)
                    .WithMany()
                    .HasForeignKey(d => d.CastId)
                    .HasConstraintName("FK_MovieCast_Cast");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_MovieCast_Movie");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("PaymentMethod");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<RoleFeature>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RoleFeature");

                entity.Property(e => e.FeatureId).HasColumnName("feature_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Feature)
                    .WithMany()
                    .HasForeignKey(d => d.FeatureId)
                    .HasConstraintName("FK_RoleFeature_Feature");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RoleFeature_Role");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.ToTable("Seat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ShowRoom>(entity =>
            {
                entity.ToTable("ShowRoom");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.Property(e => e.NumberSeat).HasColumnName("number_seat");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TheaterId).HasColumnName("theater_id");

                entity.Property(e => e.Type)
                    .HasMaxLength(150)
                    .HasColumnName("type");

                entity.HasOne(d => d.Theater)
                    .WithMany(p => p.ShowRooms)
                    .HasForeignKey(d => d.TheaterId)
                    .HasConstraintName("FK_ShowRoom_Theater");
            });

            modelBuilder.Entity<ShowRoomSeat>(entity =>
            {
                entity.ToTable("ShowRoomSeat");

                entity.Property(e => e.ShowroomseatId).HasColumnName("showroomseat_id");

                entity.Property(e => e.SeatId).HasColumnName("seat_id");

                entity.Property(e => e.ShowroomId).HasColumnName("showroom_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Type)
                    .HasMaxLength(150)
                    .HasColumnName("type");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.ShowRoomSeats)
                    .HasForeignKey(d => d.SeatId)
                    .HasConstraintName("FK_ShowRoomSeat_Seat");

                entity.HasOne(d => d.Showroom)
                    .WithMany(p => p.ShowRoomSeats)
                    .HasForeignKey(d => d.ShowroomId)
                    .HasConstraintName("FK_ShowRoomSeat_ShowRoom");
            });

            modelBuilder.Entity<ShowTime>(entity =>
            {
                entity.ToTable("ShowTime");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.ShowroomId).HasColumnName("showroom_id");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(150)
                    .HasColumnName("start_time");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.ShowTimes)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShowTime_Movie");

                entity.HasOne(d => d.Showroom)
                    .WithMany(p => p.ShowTimes)
                    .HasForeignKey(d => d.ShowroomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShowTime_ShowRoom");
            });

            modelBuilder.Entity<Theater>(entity =>
            {
                entity.ToTable("Theater");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .HasColumnName("address");

                entity.Property(e => e.Hotline)
                    .HasMaxLength(150)
                    .HasColumnName("hotline");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.ShowroomseatId).HasColumnName("showroomseat_id");

                entity.Property(e => e.ShowtimeId).HasColumnName("showtime_id");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Ticket_User");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK_Ticket_PaymentMethod");

                entity.HasOne(d => d.Showroomseat)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ShowroomseatId)
                    .HasConstraintName("FK_Ticket_ShowRoomSeat");

                entity.HasOne(d => d.Showtime)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ShowtimeId)
                    .HasConstraintName("FK_Ticket_ShowTime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email");

                entity.Property(e => e.Phone)
                    .HasMaxLength(150)
                    .HasColumnName("phone");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.Property(e => e.UserroleId).HasColumnName("userrole_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRole_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
