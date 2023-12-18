using AutoMapper;
using BE_QuanLiDiem.Constans;
using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.DTO.Khoa;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BE_QuanLiDiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class KhoaController : ControllerBase
    {
        private readonly QL_DiemDbContext dbContext;
        private readonly IKhoaRP khoaRP;
        private readonly IMapper mapper;
        public KhoaController(QL_DiemDbContext dbContext, IKhoaRP khoaRP, IMapper mapper) 
        {         
            this.dbContext= dbContext;
            this.khoaRP= khoaRP;    
            this.mapper= mapper;
        }
        [HttpGet]
        //[Authorize(Roles = UserRole.USER1)]
        public async Task<IActionResult> GetAllKhoa([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var Khoas=await khoaRP.GetAllKhoaAsync(pageNumber, pageSize);
            var KhoaDto= mapper.Map<List<KhoaDTO>>(Khoas);
            return Ok(KhoaDto);
        }

        [HttpGet]
        [Route("{MaKhoa:Guid}")]
        //[Authorize(Roles = UserRole.USER1)]
        public async Task<IActionResult> GetKhoaById([FromRoute] Guid MaKhoa) 
        {
            var Khoa= await khoaRP.GetKhoaByIdAsync(MaKhoa);
            if(Khoa == null)
            {
                return NotFound();
            }
            var KhoaDto=mapper.Map<KhoaDTO>(Khoa); 
            return Ok(KhoaDto);
        }

        [HttpPost]
        [Authorize(Roles = UserRole.ADMIN)]
        public async Task<IActionResult> CreateKhoa([FromForm]AddKhoaDTO addKhoaDTO)
        {
            var newKhoa= await khoaRP.CreateKhoaAsync(addKhoaDTO);
            return Ok(mapper.Map<KhoaDTO>(newKhoa));
        }

        [HttpDelete]
        [Route("{MaKhoa:Guid}")]
        [Authorize(Roles = UserRole.ADMIN)]
        public async Task<IActionResult> DeleteKhoa([FromRoute] Guid MaKhoa)
        {
            var exist = await khoaRP.DeleteKhoaAsync(MaKhoa);
            if(exist == null) { return NotFound(); }
            return Ok(mapper.Map<KhoaDTO>(exist));
        }

        [HttpPut]
        [Route("{MaKhoa:Guid}")]
        [Authorize(Roles = UserRole.ADMIN)]
        public async Task<IActionResult> UpdateKhoa([FromRoute] Guid MaKhoa, UpdateKhoaDTO updateKhoaDTO)
        {
            var exist = await khoaRP.UpdateKhoaAsync(updateKhoaDTO, MaKhoa);
            if (exist == null) { return null; }
            return Ok(mapper.Map<KhoaDTO>(exist));
        }
    }
}
