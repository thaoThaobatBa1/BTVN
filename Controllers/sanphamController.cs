using crud.appdatacontext;
using crud.entity;
using crud.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sanphamController : ControllerBase
    {
        private readonly crudcontext _context;

        public sanphamController(crudcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _context.sanpham.ToList();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var sanPham = _context.sanpham.Find(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            return Ok(sanPham);
        }

        [HttpPost]
        public IActionResult Create(sanphamModel sanPhamMD)
        {
            Guid id = new Guid();

            var sanpham = new SanPham()
            {
                sanPhamId = id, 
                gia = sanPhamMD.gia,    
                soLuong = sanPhamMD.soLuong,
                tenSanPham = sanPhamMD.tenSanPham   
            };


            _context.sanpham.Add(sanpham);
            _context.SaveChanges();
            return Ok(sanpham);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, sanphamModel sanPhamMD)
        {
            var existingSanPham = _context.sanpham.Find(id);
            if (existingSanPham == null)
            {
                return NotFound();
            }

            existingSanPham.tenSanPham = sanPhamMD.tenSanPham;
            existingSanPham.gia = sanPhamMD.gia;
            existingSanPham.soLuong = sanPhamMD.soLuong;

            _context.SaveChanges();
            return Ok(existingSanPham);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var sanPham = _context.sanpham.Find(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            _context.sanpham.Remove(sanPham);
            _context.SaveChanges();
            return Ok();


        }
    }
}
