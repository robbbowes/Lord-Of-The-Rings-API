using AutoMapper;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Dtos.Skill;
using dotnet_rpg.Dtos.Weapon;
using dotnet_rpg.Models;

namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<AddWeaponDto, Weapon>();
            CreateMap<Skill, GetSkillDto>();
            CreateMap<AddSkillDto, Skill>();
        }
    }
}