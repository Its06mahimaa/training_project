using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace trainingproject.Models
{
    public partial class BooksContext : DbContext
    {
        public BooksContext()
        {
        }

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthorTb> AuthorTbs { get; set; } = null!;
        public virtual DbSet<BookTb> BookTbs { get; set; } = null!;
        public virtual DbSet<CategoryTb> CategoryTbs { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<SubcategoryTb> SubcategoryTbs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Q3JP00103;Initial Catalog=Books;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorTb>(entity =>
            {
                entity.HasKey(e => e.AuthorId)
                    .HasName("PK__Author_t__55BEFA97656F4B8F");

                entity.ToTable("Author_tb");

                entity.Property(e => e.AuthorId)
                    .ValueGeneratedNever()
                    .HasColumnName("Author_id");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Author_Name");

                entity.Property(e => e.BookId).HasColumnName("Book_id");

                entity.Property(e => e.ExperienceInYears).HasColumnName("Experience_in_years");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.AuthorTbs)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__Author_tb__Book___398D8EEE");
            });

            modelBuilder.Entity<BookTb>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__Book_tb__C220CF9C8980EA57");

                entity.ToTable("Book_tb");

                entity.Property(e => e.BookId)
                    .ValueGeneratedNever()
                    .HasColumnName("Book_id");

                entity.Property(e => e.BookReferenceno)
                    .HasMaxLength(10)
                    .HasColumnName("Book_Referenceno")
                    .IsFixedLength();

                entity.Property(e => e.NoOfPages).HasColumnName("No_of_Pages");

                entity.Property(e => e.NoOfVolume)
                    .HasMaxLength(10)
                    .HasColumnName("No_of_volume")
                    .IsFixedLength();

                entity.Property(e => e.PublishDate)
                    .HasColumnType("date")
                    .HasColumnName("publish_date");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryTb>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Category__6DB28136F35A52E0");

                entity.ToTable("Category_tb");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("Category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Category_Name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("Role_Id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Role_Name");
            });

            modelBuilder.Entity<SubcategoryTb>(entity =>
            {
                entity.HasKey(e => e.SubCatId)
                    .HasName("PK__subcateg__31C737D70D0122EB");

                entity.ToTable("subcategory_tb");

                entity.Property(e => e.SubCatId)
                    .ValueGeneratedNever()
                    .HasColumnName("Sub_Cat_id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_id");

                entity.Property(e => e.SubCatName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Sub_Cat_Name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubcategoryTbs)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__subcatego__Categ__4F7CD00D");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("User_Id");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Hobbies)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.ProfilePic)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Profile_pic");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__Role_Id__71D1E811");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
