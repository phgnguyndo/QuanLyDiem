using AutoMapper;
using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.DTO.DayHoc;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_QuanLiDiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayHocController : ControllerBase
    {
        private IDayHocRP dayHocRP;
        private IMapper mapper;

        public DayHocController(IDayHocRP dayHocRP, IMapper mapper)
        {
            this.dayHocRP=dayHocRP;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDayHoc()
        {
            var dayHocs= await dayHocRP.GetAllDayHocAsync();
            return Ok(mapper.Map<List<DayHocDTO>>(dayHocs));
        }

        [HttpGet]
        [Route("{MaDayHoc:Guid}")]
        public async Task<IActionResult> GetDayHocById([FromRoute] Guid MaDayHoc)
        {
            var dayHoc = await dayHocRP.GetDayHocByIdAsync(MaDayHoc);
            if (dayHoc == null) { return NotFound(); }
            return Ok(mapper.Map<DayHocDTO>(dayHoc));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDayHoc(DayHocDTO dayHocDTO)
        {
            var newDayHoc= await dayHocRP.CreateDayHocAsync(dayHocDTO);
            return Ok(newDayHoc);
        }

        [HttpPut]
        [Route("{MaDayHoc:Guid}")]
        public async Task<IActionResult> UpdateDayHoc([FromRoute] Guid MaDayHoc, DayHocDTO dayHocDTO)
        {
            var exist = await dayHocRP.UpdateDayHocAsync(dayHocDTO, MaDayHoc);
            if (exist == null) return NotFound();
            return Ok(mapper.Map<DayHocDTO>(exist));
        }

        [HttpDelete]
        [Route("{MaDayHoc:Guid}")]
        public async Task<IActionResult> DeleteDayHoc([FromRoute] Guid MaDayHoc)
        {
            var exist = await dayHocRP.DeleteDayHocAsync(MaDayHoc);
            if (exist == null) { return NotFound(); }
            return Ok(mapper.Map<DayHocDTO>(exist));
        }
    }
}
