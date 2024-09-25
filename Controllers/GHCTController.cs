using crud.appdatacontext;
using crud.entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GHCTController : ControllerBase
    {
        private readonly crudcontext _context;

        public GHCTController(crudcontext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult GetAll() { 
            var list = _context.gHCTs.ToList();

            return Ok(list);

        }



        [HttpPost]
        public IActionResult AddOrUpdateProductInCart(Guid gioHangId, Guid sanPhamId, int soLuong)
        {
            var ghct = _context.gHCTs
                .FirstOrDefault(x => x.gioHangId == gioHangId && x.sanPhamId == sanPhamId);
            var sanpham = _context.sanpham.Find(sanPhamId);

            if (ghct != null)
            {

                if (sanpham.soLuong < soLuong)
                {
                    return BadRequest(new { mess = "số lượng không đủ" });
                }
                else
                {
                    ghct.soLuong += soLuong;
                    ghct.totalPrice = ghct.soLuong * ghct.giaDonVi;

                    _context.SaveChanges();

                    return Ok(new {mes = $"đã thêm {soLuong} vào giỏ hàng"});




                }

            }
            else
            {
                var sanPham = _context.sanpham.Find(sanPhamId);
                if (sanPham == null)
                {
                    return NotFound("Sản phẩm không tồn tại.");
                }

                ghct = new GHCT
                {
                    GhctId = Guid.NewGuid(),
                    gioHangId = gioHangId,
                    sanPhamId = sanPhamId,
                    soLuong = soLuong,
                    giaDonVi = sanPham.gia,
                    totalPrice = sanPham.gia * soLuong
                };
                _context.gHCTs.Add(ghct);
                _context.SaveChanges();

                return Ok(new { mes = $"đã thêm {soLuong} vào giỏ hàng", mes1 = $"đã thêm mới {soLuong} sản phẩm vào giỏ hàng" });

            }

        }


        [HttpPut("{id}")]
        public IActionResult UpdateQuantity(Guid id, int newSoLuong)
        {
            var ghct = _context.gHCTs.Find(id);
            if (ghct == null)
            {
                return NotFound("Giỏ hàng chi tiết không tồn tại.");
            }

            ghct.soLuong = newSoLuong;

            if (ghct.soLuong <= 0)
            {
                _context.gHCTs.Remove(ghct);
                _context.SaveChanges();
                return Ok("Sản phẩm đã bị xóa do số lượng bằng 0.");
            }

            ghct.totalPrice = ghct.soLuong * ghct.giaDonVi;
            _context.SaveChanges();

            return Ok(ghct);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductFromCart(Guid id)
        {
            var ghct = _context.gHCTs.Find(id);
            if (ghct == null)
            {
                return NotFound("Giỏ hàng chi tiết không tồn tại.");
            }

            _context.gHCTs.Remove(ghct);
            _context.SaveChanges();
            return Ok("Sản phẩm đã được xóa khỏi giỏ hàng.");
        }

    }

}

