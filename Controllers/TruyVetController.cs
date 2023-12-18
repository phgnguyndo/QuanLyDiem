using AutoMapper;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Models.DTO.TruyVet;
using BE_QuanLiDiem.Repository.Abstract;
using BE_QuanLiDiem.Repository.Implement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_QuanLiDiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruyVetController : ControllerBase
    {
        private readonly ITruyVetRP truyVetRP;
        private readonly IMapper mapper;
        public TruyVetController(ITruyVetRP truyVetRP, IMapper mapper)
        {
            this.truyVetRP = truyVetRP;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTruyVet()
        {
            var exist = await truyVetRP.GetAllTruyVetAsync();
            return Ok(mapper.Map<List<TruyVetDTO>>(exist));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTruyVet(AddTruyVetDTO addTruyVetDTO)
        {
            var newTruyVet = await truyVetRP.CreateTruyVetAsync(addTruyVetDTO);
            return Ok(newTruyVet);
        }
    }
}
