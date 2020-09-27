using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Skill;
using dotnet_rpg.Models;
using dotnet_rpg.Services.SkillService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpPost]
        public async Task<IActionResult> AddSkill(AddSkillDto newSkill)
        {
            return Ok(await _skillService.AddSkill(newSkill));

        }
    }
}