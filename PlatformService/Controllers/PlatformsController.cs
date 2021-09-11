using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepository _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepository platformRepo, IMapper mapper)
        {
            _repository = platformRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            var platformIems = _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformIems));
        }
        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {

            var platformItem = _repository.GetPlatformById(id);
            if (platformItem != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<PlatformCreateDto> AddPlatform(PlatformCreateDto platformCreateDto)
        {
            var addPlatformItem = _repository.AddPlatform(new Platform()
            {
                Name = platformCreateDto.Name,
                Publisher = platformCreateDto.Publisher,
                Cost = platformCreateDto.Cost
            });
            return Ok(addPlatformItem);
        }
        [HttpDelete]
        public ActionResult<int> DeletePlatform(Platform platform)
        {
            var deletedItem = _repository.DeletePlatform(platform);
            return deletedItem;
        }
    }
}