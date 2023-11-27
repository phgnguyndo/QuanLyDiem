using AutoMapper;
using BE_QuanLiDiem.Models.DTO.ChuongTrinh;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_QuanLiDiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ChuongTrinhController : ControllerBase
    {
        private IChuongTrinhRP chuongTrinhRP;
        private IMapper mapper;

        public ChuongTrinhController(IChuongTrinhRP chuongTrinhRP, IMapper mapper)
        {
            this.chuongTrinhRP = chuongTrinhRP;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllChuongTrinh()
        {
            var chuongTrinhs = await chuongTrinhRP.GetAllChuongTringAsync();
            if (chuongTrinhs == null) return NotFound();

            return Ok(mapper.Map<List<ChuongTrinhDTO>>(chuongTrinhs));
        }


        [HttpGet]
        [Route("{MaLCN:Guid}")]
        public async Task<IActionResult> GetChuongTrinhByIdLCN([FromRoute] Guid MaLCN)
        {
            var chuongTrinh= await chuongTrinhRP.GetChuongTrinhnByIdLCNAsync(MaLCN);
            if(chuongTrinh==null) return NotFound();

            return Ok(mapper.Map<List<ChuongTrinhDTO>>(chuongTrinh));
        }

        [HttpPost]
        public async Task<IActionResult> CreateChuongTrinh(AUChuongTrinhDTO aUChuongTrinhDTO)
        {
            var newChuongTrinh = await chuongTrinhRP.CreateChuongTrinhAsync(aUChuongTrinhDTO);
            return Ok(newChuongTrinh);
        }

        [HttpDelete]
        [Route("{MaCT:Guid}")]
        public async Task<IActionResult> DeleteChuongTrinh([FromRoute] Guid MaCT)
        {
            var chuongTrinh = await chuongTrinhRP.DeleteCHuongTrinhAsync(MaCT);
            if (chuongTrinh == null) return NotFound();
            return Ok(mapper.Map<ChuongTrinhDTO>(chuongTrinh));
        }

        [HttpPut]
        [Route("{MaCT:Guid}")]
        public async Task<IActionResult> GetChuongTrinhByIdLCN(AUChuongTrinhDTO aUChuongTrinhDTO,[FromRoute] Guid MaCT)
        {
            var chuongTrinh = await chuongTrinhRP.UpdateChuongTrinhAsync(aUChuongTrinhDTO, MaCT);
            if (chuongTrinh == null) return NotFound();
            return Ok(mapper.Map<ChuongTrinhDTO>(chuongTrinh));
        }

    }
}
