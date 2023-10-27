using AutoMapper;
using BE_QuanLiDiem.Models.DTO.PhieuDiem;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_QuanLiDiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuDiemController : ControllerBase
    {
        private IPhieuDiemRP phieuDiemRP;
        private IMapper mapper;

        public PhieuDiemController(IPhieuDiemRP phieuDiemRP, IMapper mapper)
        {
            this.phieuDiemRP = phieuDiemRP;
            this.mapper=mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPhieuDiem()
        {
            var PhieuDiems=await phieuDiemRP.GetAllPhieuDiemAsync();
            return Ok(mapper.Map<List<PhieuDiemDTO>>(PhieuDiems));
        }

        [HttpGet]
        [Route("{MaPhieuDiem:Guid}")]
        public async Task<IActionResult> GetPhieuDiemById([FromRoute] Guid MaPhieuDiem)
        {
            var phieuDiem=await phieuDiemRP.GetPhieuDiemByIdAsync(MaPhieuDiem);
            if(phieuDiem == null)   return NotFound();
            return Ok(mapper.Map<PhieuDiemDTO> (phieuDiem));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhieuDiem(AddPhieuDiemDTO addPhieuDiemDTO)
        {
            var newPhieuDiem=await phieuDiemRP.CreatePhieuDiemAsync(addPhieuDiemDTO);
            return Ok(newPhieuDiem);
        }

        [HttpPut]
        [Route("{MaPhieuDiem:Guid}")]
        public async Task<IActionResult> UpdatePhieuDiem(UpdatePhieuDiemDTO updatePhieuDiemDTO, [FromRoute] Guid MaPhieuDiem)
        {
            var exist = await phieuDiemRP.UpdatePhieuDiemAsync(updatePhieuDiemDTO, MaPhieuDiem);
            if(exist == null) return NotFound();
            return Ok(mapper.Map<PhieuDiemDTO>(exist));
        }

        [HttpDelete]
        [Route("{MaPhieuDiem:Guid}")]
        public async Task<IActionResult> DeletePhieuDiem([FromRoute] Guid MaPhieuDiem)
        {
            var exist = await phieuDiemRP.DeletePhieuDiemAsync(MaPhieuDiem);
            if (exist == null) return NotFound();
            return Ok(mapper.Map<PhieuDiemDTO>(exist));
        }
    }
}
