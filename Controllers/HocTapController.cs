using AutoMapper;
using BE_QuanLiDiem.Models.DTO.HocTap;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_QuanLiDiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocTapController : ControllerBase
    {
        private IHocTapRP hocTapRP;
        private IMapper mapper;
        public HocTapController(IHocTapRP hocTapRP, IMapper mapper)
        {
            this.hocTapRP = hocTapRP;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHocTap() {
            var hocTaps= await hocTapRP.GetAllHocTapAsync();
            if(hocTaps==null) { return NotFound(); }
            return Ok(mapper.Map<List<HocTapDTO>>(hocTaps));
        }

        [HttpGet]
        [Route("{MaLCN:Guid}")]
        public async Task<IActionResult> GetHocTapByIdLCN([FromRoute] Guid MaLCN)
        {
            var hocTap = await hocTapRP.GetHocTapByIdHVAsync(MaLCN);
            if (hocTap == null) { return NotFound(); }
            return Ok(mapper.Map<List<HocTapDTO>>(hocTap));
        }

        [HttpPost]
        public async Task<IActionResult> CreateHocTap(AUHocTapDTO aUHocTapDTO)
        {
            var newHT= await hocTapRP.CreateHocTapAsync(aUHocTapDTO);
            return Ok(newHT);
        }

        [HttpPut]
        [Route("{MaHocTap:Guid}")]
        public async Task<IActionResult> UpdateHocTap(AUHocTapDTO aUHocTapDTO,[FromRoute] Guid MaHocTap)
        {
            var hocTap = await hocTapRP.UpdateHocTapAsync(aUHocTapDTO, MaHocTap);
            if (hocTap == null) { return NotFound(); }
            return Ok(mapper.Map<HocTapDTO>(hocTap));
        }

        [HttpDelete]
        [Route("{MaHocTap:Guid}")]
        public async Task<IActionResult> DeleteHocTap([FromRoute] Guid MaHocTap)
        {
            var hocTap = await hocTapRP.DeleteHocTapAsync(MaHocTap);
            if (hocTap == null) { return NotFound(); }
            return Ok(mapper.Map<HocTapDTO>(hocTap));
        }

    }
}
