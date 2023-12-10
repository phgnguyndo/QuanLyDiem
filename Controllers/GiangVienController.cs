using AutoMapper;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.GiangVIen;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangVienController : ControllerBase
    {
        private IGiangVienRP giangVienRP;
        private IMapper mapper;

        public GiangVienController(IGiangVienRP giangVienRP, IMapper mapper)
        {
            this.giangVienRP=giangVienRP;
            this.mapper=mapper; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGiangVien()
        {
            var GiangViens=await giangVienRP.GetAllGiangVienAsync();
            return Ok(mapper.Map<List<GiangVienDTO>>(GiangViens));
        }
    
        [HttpGet]
        [Route("{MaGV:Guid}")]
        public async Task<IActionResult> GetGiangVienById([FromRoute] Guid MaGV)
        {
            var exist = await giangVienRP.GetGiangVienByIdAsync(MaGV);
            if (exist == null) return NotFound();
            return Ok(mapper.Map<GiangVienDTO>(exist));
        }
        
        [HttpGet]
        [Route("bymabm/{MaBM:Guid}")]
        public async Task<IActionResult> GetGiangVienByIdBM([FromRoute] Guid MaBM)
        {
            var exist = await giangVienRP.GetGiangVienBoMonAsync(MaBM);
            if (exist == null) return NotFound();
            return Ok(mapper.Map<List<GiangVienDTO>>(exist));
        }

        [HttpPost]
        public async Task<IActionResult> CreateGiangVien(AddGiangVienDTO addGiangVienDTO)
        {
            var newGV=await giangVienRP.CreateGiangVienAsync(addGiangVienDTO);
            return Ok(newGV);
        }
        [HttpPut]
        [Route("{MaGV:Guid}")]
        public async Task<IActionResult> UpdateGiangVien([FromRoute] Guid MaGV, UpdateGiangVienDTO updateGiangVienDTO)
        {
            var exist = await giangVienRP.UpdateGiangVienAsync(updateGiangVienDTO, MaGV);
            if (exist == null) { return NotFound(); }
            return Ok(mapper.Map<GiangVienDTO>(exist));
        }
        [HttpDelete]
        [Route("{MaGV:Guid}")]
        public async Task<IActionResult> DeleteGiangVien([FromRoute] Guid MaGV)
        {
            var exist = await giangVienRP.DeleteGiangVienAsync(MaGV);
            if (exist == null) { return NotFound(); }
            return Ok(mapper.Map<GiangVienDTO>(exist));
        }
    }
}
