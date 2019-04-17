﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarSellingSystem.ApiResources;
using CarSellingSystem.Core.Models;
using CarSellingSystem.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSellingSystem.Controllers
{
    [Route("/api/makes")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly CarDbContext _context;
        private readonly IMapper _mapper;

        public MakesController(CarDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await _context.Makes.Include(m => m.Models).ToListAsync();
            var makesDtos = _mapper.Map<List<Make>, List<MakeResource>>(makes);
            return makesDtos;
        }
    }
}
