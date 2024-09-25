using System.ComponentModel.DataAnnotations;

namespace crud.entity
{
    public class SanPham
    {
        [Key]
        public Guid sanPhamId { get; set; }
        public string tenSanPham { get; set; }

        public decimal gia { get; set; }
        public int soLuong { get; set; }

        public ICollection<GHCT> gHCTs { get; set; }

    }
}
