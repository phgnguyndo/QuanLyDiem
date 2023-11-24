﻿using AutoMapper;
using BE_QuanLiDiem.Constans;
using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_QuanLiDiem.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BoMonController : ControllerBase
    {
        private readonly IBoMonRP boMonRP;
        private readonly IMapper mapper;
        public BoMonController(IBoMonRP boMonRP, IMapper mapper)
        {
            this.boMonRP = boMonRP;
            this.mapper = mapper;
        }
        //[AllowAnonymous]
        [Authorize(Roles =UserRole.ADMIN)]
        [HttpGet]
        public async Task<IActionResult> GetAllBoMon()
        {
            var exist=await boMonRP.GetAllBoMonAsync();
            return Ok(mapper.Map<List<BoMonDTO>>(exist));
        }
        
        [HttpGet]
        [Route("{MaBM:Guid}")]
        public async Task<IActionResult> GetBoMonbyId([FromRoute] Guid MaBM)
        {
            var exist=await boMonRP.GetAllBoMonAsync();
            if (exist == null) return NotFound();
            return Ok(mapper.Map<List<BoMonDTO>>(exist));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateBoMon(AddBoMonDTO addBoMonDTO)
        {
            var newBM= await boMonRP.CreateBoMonAsync(addBoMonDTO);
            return Ok(newBM);
        }
        
        [HttpPut]
        [Route("{MaBM:Guid}")]
        public async Task<IActionResult> UpdateBoMon([FromRoute] Guid MaBM, UpdateBoMonDTO updateBoMonDTO)
        {
            var exist=await boMonRP.UpdateBoMonAsync(updateBoMonDTO, MaBM);
            if(exist == null) return NotFound();
            return Ok(mapper.Map<BoMonDTO>(exist));
        }
        
        [HttpDelete]
        [Route("{MaBM:Guid}")]
        public async Task<IActionResult> DeleteBoMon([FromRoute] Guid MaBM)
        {
            var exist=await boMonRP.DeleteBoMonAsync(MaBM);
            if(exist == null) return NotFound();
            return Ok(mapper.Map<BoMonDTO>(exist));
        }

    }
}
