using crud.entity;
using Microsoft.EntityFrameworkCore;

namespace crud.appdatacontext
{
    public class crudcontext : DbContext
    {

      

        public crudcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SanPham> sanpham { get; set; }
        public DbSet<GHCT> gHCTs { get; set; }
        public DbSet<GioHang> gioHangs { get; set; }
    }
}
