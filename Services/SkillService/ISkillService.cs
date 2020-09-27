using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Skill;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.SkillService
{
    public interface ISkillService
    {
        Task<ServiceResponse<List<GetSkillDto>>> AddSkill(AddSkillDto newSkill);
    }
}