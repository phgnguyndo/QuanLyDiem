using AutoMapper;
using BE_QuanLiDiem.Models.DTO.HocVien;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_QuanLiDiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocVienController : ControllerBase
    {
        private IHocVienRP hocVienRP;
        private IMapper mapper;

        public HocVienController(IHocVienRP hocVienRP, IMapper mapper)
        {
            this.hocVienRP = hocVienRP;
            this.mapper=mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHocVien()
        {
            var hocViens= await hocVienRP.GetAllHocVienAsync();
            return Ok(mapper.Map<List<HocVienDTO>>(hocViens));
        }

        [HttpGet]
        [Route("{MaHV}")]
        public async Task<IActionResult> GetHocVienById([FromRoute] string MaHV)
        {
            var hv=await hocVienRP.GetHocVienByIdAsync(MaHV);
            if(hv==null) return NotFound();
            return Ok(mapper.Map<HocVienDTO>(hv));
        }

        [HttpPost]
        public async Task<IActionResult> CreateHocVien([FromForm] AddHocVienDTO addHocVienDTO)
        {
            var newHV=await hocVienRP.CreateHocVienAsync(addHocVienDTO);
            return Ok(newHV);
        }

        [HttpPut]
        [Route("{MaHV}")]
        public async Task<IActionResult> UpdateHocVien([FromForm] UpdateHocVienDTO updateHocVienDTO, [FromRoute] string MaHV)
        {
            var exist = await hocVienRP.UpdateHocVienAsync(updateHocVienDTO, MaHV);
            if(exist==null) return NotFound();
            return Ok(mapper.Map<HocVienDTO>(exist));
        }

        [HttpDelete]
        [Route("{MaHV}")]
        public async Task<IActionResult> DeleteHocVien([FromRoute] string MaHV)
        {
            var exist = await hocVienRP.DeleteHocVienAsync(MaHV);
            if (exist == null) return NotFound();
            return Ok(mapper.Map<HocVienDTO>(exist));
        }
    }
}
