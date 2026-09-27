using Microsoft.EntityFrameworkCore;
using QuanLyThuVien_UNETI03_TI17A1ND.Models;

namespace QuanLyThuVien_UNETI03_TI17A1ND.Data
{
    public class ThuVienDbContext : DbContext
    {
        public ThuVienDbContext(DbContextOptions<ThuVienDbContext> options) : base(options)
        {
        }

        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<TheLoai> TheLoais { get; set; }
        public DbSet<Sach> Sachs { get; set; }
        public DbSet<DocGia> DocGias { get; set; }
        public DbSet<PhieuMuon> PhieuMuons { get; set; }
        public DbSet<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; }
        public DbSet<GiaoDichThanhToan> GiaoDichThanhToans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaiKhoan>()
                .HasIndex(tk => tk.TenDangNhap)
                .IsUnique();

            modelBuilder.Entity<TheLoai>()
                .HasIndex(tl => tl.TenTheLoai)
                .IsUnique();

            modelBuilder.Entity<DocGia>()
                .HasIndex(dg => dg.MaTaiKhoan)
                .IsUnique();

            modelBuilder.Entity<TaiKhoan>()
                .HasOne(tk => tk.DocGia)
                .WithOne(dg => dg.TaiKhoan)
                .HasForeignKey<DocGia>(dg => dg.MaTaiKhoan)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TheLoai>()
                .HasMany(tl => tl.Sachs)
                .WithOne(s => s.TheLoai)
                .HasForeignKey(s => s.MaTheLoai)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DocGia>()
                .HasMany(dg => dg.PhieuMuons)
                .WithOne(pm => pm.DocGia)
                .HasForeignKey(pm => pm.MaDocGia)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChiTietPhieuMuon>()
                .HasKey(ct => new { ct.MaPhieuMuon, ct.MaSach });

            modelBuilder.Entity<ChiTietPhieuMuon>()
                .HasOne(ct => ct.PhieuMuon)
                .WithMany(pm => pm.ChiTietPhieuMuons)
                .HasForeignKey(ct => ct.MaPhieuMuon)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChiTietPhieuMuon>()
                .HasOne(ct => ct.Sach)
                .WithMany(s => s.ChiTietPhieuMuons)
                .HasForeignKey(ct => ct.MaSach)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GiaoDichThanhToan>()
                .HasOne(gd => gd.PhieuMuon)
                .WithMany(pm => pm.GiaoDichThanhToans)
                .HasForeignKey(gd => gd.MaPhieuMuon)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<GiaoDichThanhToan>()
                .HasOne(gd => gd.DocGia)
                .WithMany(dg => dg.GiaoDichThanhToans)
                .HasForeignKey(gd => gd.MaDocGia)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<GiaoDichThanhToan>()
                .HasIndex(gd => gd.MaGiaoDichCode)
                .IsUnique();
        }
    }
}
