using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.DTOs;
using NZWalks.API.Interfaces;
using NZWalks.API.Models.Domain;

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
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetAllRegionsAsync();
            var viewRegions = _mapper.Map<List<RegionDto>>(regions);

            return Ok(viewRegions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await _regionRepository.GetAsync(id);
            
            if(region == null)
            {
                return NotFound();
            }

            var viewRegion = _mapper.Map<RegionDto>(region);

            return Ok(viewRegion);
        }

        [HttpPost]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> AddRegionAsync(RegionRequestDto regionRequestDto)
        {
            var region = new Region
            {
                Code = regionRequestDto.Code,
                Area = regionRequestDto.Area,
                Lat = regionRequestDto.Lat,
                Long = regionRequestDto.Long,
                Name = regionRequestDto.Name,
                Population = regionRequestDto.Population,
            };

            var newRegion = await _regionRepository.AddAsync(region);
            var viewRegion = _mapper.Map<RegionDto>(newRegion);

            return CreatedAtAction(nameof(GetRegionAsync), new { id = viewRegion.Id}, viewRegion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await _regionRepository.GetAsync(id);

            if(region == null)
            { 
                return NotFound(); 
            }
            await _regionRepository.DeleteAsync(id);
            var viewRegion = _mapper.Map<RegionDto>(region);
            return Ok(viewRegion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute]Guid id, [FromBody]UpdateRegionRequestDto updateRegionRequestDto)
        {
            var region = new Region
            {
                Code = updateRegionRequestDto.Code,
                Area = updateRegionRequestDto.Area,
                Lat = updateRegionRequestDto.Lat,
                Long = updateRegionRequestDto.Long,
                Name = updateRegionRequestDto.Name,
                Population = updateRegionRequestDto.Population,
            };

            var regionUpdated = await _regionRepository.UpdateAsync(id, region);
            
            if(regionUpdated == null)
            {
                return NotFound();
            }
            var viewRegion = _mapper.Map<RegionDto>(regionUpdated);

            return Ok(viewRegion);
        }
    }
}
