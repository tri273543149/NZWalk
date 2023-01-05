using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.DTOs;
using NZWalks.API.Interfaces;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetAllRegionsAsync();
            var viewRegions = _mapper.Map<List<RegionDto>>(regions);

            return Ok(viewRegions);
        }
    }
}
