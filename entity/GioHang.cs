using System.ComponentModel.DataAnnotations;

namespace crud.entity
{
    public class GioHang
    {
        [Key]
        public Guid gioHangId { get; set; }
        public decimal tongTien { get; set; }
        public int  tongSoLuongSanPham { get; set; }

        public ICollection<GHCT> gHCTs { get; set; }
    }
}
