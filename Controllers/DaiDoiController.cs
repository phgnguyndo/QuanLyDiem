﻿using AutoMapper;
using BE_QuanLiDiem.Constans;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.DaiDoi;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BE_QuanLiDiem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaiDoiController : ControllerBase
    {
        private IDaiDoiRP daiDoiRP;
        private IMapper mapper;

        public DaiDoiController(IDaiDoiRP daiDoiRP, IMapper mapper)
        {
            this.daiDoiRP = daiDoiRP;
            this.mapper = mapper;
        }
        
        [HttpGet]
        [Authorize(Roles = UserRole.ADMIN)]
        public async Task<IActionResult> GetAllDaiDoi()
        {
            var DaiDois=await daiDoiRP.GetAllDaiDoiAsync();
            return Ok(mapper.Map<List<DaiDoiDTO>>(DaiDois));
        }

        [HttpGet]
        [Route("{MaDaiDoi:Guid}")]
        [Authorize(Roles = UserRole.ADMIN)]
        public async Task<IActionResult> GetDaiDoiById([FromRoute] Guid MaDaiDoi)
        {
            var daiDoi= await daiDoiRP.GetDaiDoiByIdAsync(MaDaiDoi);
            if(daiDoi==null) return NotFound();
            return Ok(mapper.Map<DaiDoiDTO>(daiDoi));
        }

        [HttpPost]
        [Authorize(Roles = UserRole.ADMIN)]
        public async Task<IActionResult> CreateDaiDoi([FromForm] AUdaiDoiDTO aUdaiDoiDTO)
        {
            var newDD=await daiDoiRP.CreateDaiDoiAsync(aUdaiDoiDTO);
            return Ok(newDD);
        }

        [HttpPut]
        [Route("{MaDaiDoi:Guid}")]
        [Authorize(Roles = UserRole.ADMIN)]
        public async Task<IActionResult> UpdateDaiDoi([FromForm] AUdaiDoiDTO aUdaiDoiDTO,[FromRoute] Guid MaDaiDoi)
        {
            var exist = await daiDoiRP.UpdateDaiDoiAsync(aUdaiDoiDTO, MaDaiDoi);
            if(exist==null) return NotFound();
            return Ok(mapper.Map<DaiDoiDTO>(exist));
        }

        [HttpDelete]
        [Route("{MaDaiDoi:Guid}")]
        [Authorize(Roles = UserRole.ADMIN)]
        public async Task<IActionResult> DeleteDaiDoi([FromRoute] Guid MaDaiDoi)
        {
            var exist = await daiDoiRP.DeleteDaiDoiAsync(MaDaiDoi);
            if (exist == null) return NotFound();
            return Ok(mapper.Map<DaiDoiDTO>(exist));
        }
    }
}
