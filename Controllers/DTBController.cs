using AutoMapper;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Models.DTO.DTB;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_QuanLiDiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DTBController : ControllerBase
    {
        private readonly IDtbRp dtb;
        private readonly IMapper mapper;
        public DTBController(IDtbRp dtb, IMapper mapper)
        {
            this.dtb = dtb;
            this.mapper = mapper;
        }
        //[AllowAnonymous]
        //[Authorize(Roles = UserRole.ADMIN)]
        [HttpGet]
        public async Task<IActionResult> GetAllDTB()
        {
            var exist = await dtb.GetAllDTBAsync();
            return Ok(mapper.Map<List<DiemTrungBinhDTO>>(exist));
        }

        [HttpGet]
        [Route("{HocKy:int}")]
        public async Task<IActionResult> GetDTBbyHocKy([FromRoute] int HocKy)
        {
            var exist = await dtb.GetDTBByHocKyAsync(HocKy);    
            return Ok(mapper.Map<List<DiemTrungBinhDTO>>(exist));
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateDTB(UpdateDTBdto updateDTBdto, [FromQuery] int hocky, [FromQuery] string MaHV)
        {
            var exist = await dtb.UpdateDTBAsync(updateDTBdto, hocky, MaHV);
            return Ok(mapper.Map<DiemTrungBinhDTO>(exist));
        }
    }
}
