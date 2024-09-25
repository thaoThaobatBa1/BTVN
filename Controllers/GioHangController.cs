using crud.appdatacontext;
using crud.entity;
using crud.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        private readonly crudcontext _context;

        public GioHangController(crudcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _context.gioHangs.ToList();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var gioHang = _context.gioHangs.Find(id);
            if (gioHang == null)
            {
                return NotFound();
            }
            return Ok(gioHang);
        }

        [HttpPost]
        public IActionResult Create( )
        {
            Guid id = Guid.NewGuid();   

            GioHang gioHang = new GioHang()
            {
                gioHangId = id, 
            };

            _context.gioHangs.Add(gioHang);
            _context.SaveChanges();
            return Ok(gioHang); 
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, GioHangModel gioHangMD)
        {
            var existingGioHang = _context.gioHangs.Find(id);
            if (existingGioHang == null)
            {
                return NotFound();
            }

            existingGioHang.tongSoLuongSanPham = gioHangMD.tongSoLuongSanPham;
            existingGioHang.tongTien = gioHangMD.tongTien;


            _context.SaveChanges();
            return Ok(existingGioHang);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var gioHang = _context.gioHangs.Find(id);
            if (gioHang == null)
            {
                return NotFound();
            }

            _context.gioHangs.Remove(gioHang);
            _context.SaveChanges();
            return Ok( new { Message = "ok iem" } );
        }
    }
}
