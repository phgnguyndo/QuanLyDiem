using AutoMapper;
using BE_QuanLiDiem.Models.DTO.LopHocPhan;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_QuanLiDiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopHocPhanController : ControllerBase
    {
        private ILopHocPhanRP lhpRP;
        private IMapper mapper;

        public LopHocPhanController(ILopHocPhanRP lhpRP, IMapper mapper)
        {
            this.lhpRP=lhpRP;
            this.mapper=mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLHP()
        {
            var lhps = await lhpRP.GetAllLHPAsync();
            return Ok(mapper.Map<List<LopHocPhanDTO>>(lhps));
        }

        [HttpGet]
        [Route("{MaLHP:Guid}")]
        public async Task<IActionResult> GetLHPbyId([FromRoute] Guid MaLHP)
        {
            var exist= await lhpRP.GetLHPByIdAsync(MaLHP);
            if(exist==null) return NotFound();
            return Ok(mapper.Map<LopHocPhanDTO>(exist));
        }

        [HttpPost]
        public async Task<IActionResult> CreateLHP(AddLopHocPhanDTO addLopHocPhanDTO)
        {
            var newLHP = await lhpRP.CreateLHPAsync(addLopHocPhanDTO);
            return Ok(mapper.Map<LopHocPhanDTO>(newLHP));
        }

        [HttpPut]
        [Route("{MaLHP:Guid}")]
        public async Task<IActionResult> UpdateLHP([FromRoute] Guid MaLHP, UpdateLopHocPhanDTO updateLopHocPhanDTO)
        {
            var exist=await lhpRP.UpdateLHPAsync(updateLopHocPhanDTO, MaLHP);
            if(exist==null) return NotFound();
            return Ok(mapper.Map<LopHocPhanDTO>(exist));
        }

        [HttpDelete]
        [Route("{MaLHP:Guid}")]
        public async Task<IActionResult> DeleteLHP([FromRoute] Guid MaLHP)
        {
            var exist=await lhpRP.DeleteLHPAsync(MaLHP);
            if(exist==null) return NotFound();
            return Ok(mapper.Map<LopHocPhanDTO>(exist));
        }
    }
}
