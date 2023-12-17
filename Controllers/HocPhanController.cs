using AutoMapper;
using BE_QuanLiDiem.Constans;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.HocPhan;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BE_QuanLiDiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRole.USER1)]
    public class HocPhanController : ControllerBase
    {
        private IHocPhanRP hocPhanRP;
        private IMapper mapper;

        public HocPhanController(IHocPhanRP hocPhanRP, IMapper mapper) 
        {
            this.hocPhanRP=hocPhanRP;
            this.mapper=mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHocPhan()
        {
            var HocPhans= await hocPhanRP.GetAllHocPhanAsync();
            return Ok(mapper.Map<List<HocPhanDTO>>(HocPhans));
        }

        [HttpGet]
        [Route("{MaHocPhan:Guid}")]
        public async Task<IActionResult> GetHocPhanById([FromRoute] Guid MaHocPhan)
        {
            var exist= await hocPhanRP.GetHocPhanByIdAsync(MaHocPhan);
            if (exist==null) return NotFound();
            return Ok(mapper.Map<HocPhanDTO>(exist));
        }

        [HttpPost]
        public async Task<IActionResult> CreateHocPhan(AddHocPhanDTO addHocPhanDTO)
        {
            var newHocPhan = await hocPhanRP.CreateHocPhanAsync(addHocPhanDTO);
            return Ok(newHocPhan);
        }

        [HttpPut]
        [Route("{MaHocPhan:Guid}")]
        public async Task<IActionResult> UpdateHocPhan([FromRoute] Guid MaHocPhan, UpdateHocPhanDTO updateHocPhanDTO)
        {
            var exist = await hocPhanRP.UpdateHocPhanAsync(updateHocPhanDTO, MaHocPhan);
            if (exist==null) return NotFound();
            return Ok(mapper.Map<HocPhanDTO>(exist));
        }
        
        [HttpDelete]
        [Route("{MaHocPhan:Guid}")]
        public async Task<IActionResult> DeleteHocPhan([FromRoute] Guid MaHocPhan)
        {
            var exist = await hocPhanRP.DeleteHocPhanAsync( MaHocPhan);
            if (exist == null) return NotFound();
            return Ok(mapper.Map<HocPhanDTO>(exist));
        }
    }
}
