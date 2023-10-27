using AutoMapper;
using BE_QuanLiDiem.Models.DTO.LCN;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_QuanLiDiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> GetAllLCN()
        {
            var LCNs=await lopCnRP.GetAllLcnAsync();
            return Ok(mapper.Map<LopCnDTO>(LCNs));
        }

        [HttpGet]
        [Route("{MaLCN:Guid}")]
        public async Task<IActionResult> GetLCNById([FromRoute] Guid MaLCN)
        {
            var lcn= await lopCnRP.GetLcnByIdAsync(MaLCN);
            if(lcn==null) return NotFound();
            return Ok(mapper.Map<LopCnDTO>(lcn));
        }

        [HttpPost]
        public async Task<IActionResult> CreateLCN(AddLopCnDTO addLopCnDTO)
        {
            var newLCN= await lopCnRP.CreateLcnAsync(addLopCnDTO);
            return Ok(newLCN);
        }

        [HttpPut]
        [Route("{MaLCN:Guid}")]
        public async Task<IActionResult> UpdateLCN(UpdateLopCnDTO updateLopCnDTO, [FromRoute] Guid MaLCN)
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
