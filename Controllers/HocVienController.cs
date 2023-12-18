using AutoMapper;
using BE_QuanLiDiem.Models.DTO.HocVien;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_QuanLiDiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
        public async Task<IActionResult> GetAllHocVien([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var hocViens= await hocVienRP.GetAllHocVienAsync(pageNumber, pageSize);
            return Ok(mapper.Map<List<HocVienDTO>>(hocViens));
        }

        [HttpGet]
        [Route("{MaHV}")]
        public async Task<IActionResult> GetHocVienById([FromRoute] string MaHV)
        {
            var hv=await hocVienRP.GetHocVienByIdAsync(MaHV);
            if(hv==null) return NotFound();
            return Ok(mapper.Map<List<HocVienDTO>>(hv));
        }
        
        [HttpGet]
        [Route("{MaLCN:Guid}")]
        public async Task<IActionResult> GetHocVienByIdLop([FromRoute] Guid MaLCN)
        {
            var hv=await hocVienRP.GetHocVienByIdLopAsync(MaLCN);
            if(hv==null) return NotFound();
            return Ok(mapper.Map<List<HocVienDTO>>(hv));
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
