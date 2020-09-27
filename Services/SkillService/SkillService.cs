using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.Skill;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Services.SkillService
{
    public class SkillService : ISkillService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _context;
        public SkillService(IMapper mapper, IHttpContextAccessor httpContextAccessor, DataContext context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetSkillDto>>> AddSkill(AddSkillDto newSkill)
        {
            ServiceResponse<List<GetSkillDto>> serviceResponse = new ServiceResponse<List<GetSkillDto>>();

            int userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null && user.UserRole == UserRole.Admin)
            {
                Skill skill = _mapper.Map<Skill>(newSkill);
                await _context.Skills.AddAsync(skill);
                await _context.SaveChangesAsync();

                serviceResponse.Data = (_context.Skills.Select(s => _mapper.Map<GetSkillDto>(s))).ToList();
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "You do not have adequate rights to add a skill.";
            }
            return serviceResponse;
        }
    }
}