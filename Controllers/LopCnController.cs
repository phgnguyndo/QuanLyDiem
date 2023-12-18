using AutoMapper;
using BE_QuanLiDiem.Constans;
using BE_QuanLiDiem.Models.DTO.LCN;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BE_QuanLiDiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = UserRole.USER1)]
    public class LopCnController : ControllerBase
    {
        private ILopCnRP lopCnRP;
        private IMapper mapper;

        public LopCnController(ILopCnRP lopCnRP, IMapper mapper)
        {
            this.lopCnRP = lopCnRP;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = UserRole.ADMIN + "," + UserRole.USER1)]
        public async Task<IActionResult> GetAllLCN()
        {
            var LCNs=await lopCnRP.GetAllLcnAsync();
            return Ok(mapper.Map<List<LopCnDTO>>(LCNs));
        }

        //[HttpGet]
        //[Route("{MaLCN:Guid}")]
        //public async Task<IActionResult> GetLCNById([FromRoute] Guid MaLCN)
        //{
        //    var lcn= await lopCnRP.GetLcnByIdAsync(MaLCN);
        //    if(lcn==null) return NotFound();
        //    return Ok(mapper.Map<LopCnDTO>(lcn));
        //}
        
        [HttpGet]
        [Route("{MaDaiDoi:Guid}")]
        public async Task<IActionResult> GetLCNByIdDD([FromRoute] Guid MaDaiDoi)
        {
            var lcn= await lopCnRP.GetLcnByIdDaiDoiAsync(MaDaiDoi);
            if(lcn==null) return NotFound();
            return Ok(mapper.Map<List<LopCnDTO>>(lcn));
        }

        [HttpPost]
        public async Task<IActionResult> CreateLCN([FromForm] AddLopCnDTO addLopCnDTO)
        {
            var newLCN= await lopCnRP.CreateLcnAsync(addLopCnDTO);
            return Ok(newLCN);
        }

        [HttpPut]
        [Route("{MaLCN:Guid}")]
        public async Task<IActionResult> UpdateLCN([FromForm] UpdateLopCnDTO updateLopCnDTO, [FromRoute] Guid MaLCN)
        {
            var exist = await lopCnRP.UpdateLcnAsync(updateLopCnDTO, MaLCN);
            if(exist==null) return NotFound();
            return Ok(mapper.Map<LopCnDTO>(exist));
        }

        [HttpDelete]
        [Route("{MaLCN:Guid}")]
        public async Task<IActionResult> DeleteLCN([FromRoute] Guid MaLCN)
        {
            var exist=await lopCnRP.DeleteLcnAsync(MaLCN);
            if(exist==null) return NotFound();
            return Ok(mapper.Map<LopCnDTO?>(exist));    
        }
    }
}
