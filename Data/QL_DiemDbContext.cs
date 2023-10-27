using BE_QuanLiDiem.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Data
{
    public class QL_DiemDbContext: DbContext
    {
        public QL_DiemDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<BoMon> BoMons { get; set; }
        public DbSet<GiangVien> GiangViens { get; set; }
        public DbSet<DayHoc> DayHocs { get; set; }
        public DbSet<LopHocPhan> LopHocPhans { get; set; }
        public DbSet<PhieuDiem> PhieuDiems { get; set; }
        public DbSet<HocVien> HocViens { get; set; }
        public DbSet<LopChuyenNganh> LopChuyenNganhs { get; set; }
        public DbSet<DaiDoi> DaiDois { get; set; }
        public DbSet<HocPhan> HocPhans { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<DayHoc>()
        //        .HasKey(d => new { d.MaLopHocPhan, d.MaGiangVien });
        //    modelBuilder.Entity<PhieuDiem>()
        //        .HasKey(e => new { e.MaLopHocPhan, e.MaHocVien });
        //}

    }
}
