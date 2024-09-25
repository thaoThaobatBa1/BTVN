using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace crud.entity
{
    public class GHCT
    {
        [Key]
        public Guid GhctId { get; set; }


        [ForeignKey("gioHangId")]
        public Guid gioHangId { get; set; }
        public GioHang GioHang { get; set; }


        [ForeignKey("sanPhamId")]
        public Guid sanPhamId { get; set; }
        public SanPham SanPham { get; set; }

        public int MyProperty { get; set; }
        public decimal giaDonVi { get; set; }
        public decimal totalPrice { get; set; }
        public int soLuong { get; set; }

    }
}
