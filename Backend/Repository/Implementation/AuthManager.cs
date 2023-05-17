using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Backend.Contracts;
using Backend.Data;
using Backend.Dtos.User;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Repositories
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userMapper;
        private readonly IConfiguration _configuration;

        public AuthManager(IMapper mapper, UserManager<ApiUser> userMapper, IConfiguration configuration)
        {
            this._mapper = mapper;
            this._userMapper = userMapper;
            this._configuration = configuration;
        }

        public async Task<AuthResponseDto> Login([FromBody] LoginUserDto loginApiDto)
        {

            var user = await _userMapper.FindByEmailAsync(loginApiDto.Email);
            bool IsValidate = await _userMapper.CheckPasswordAsync(user, loginApiDto.Password);
            if (user == null || IsValidate == false)
            {
                return null;
            }

            var token = await GenerateTokens(user);
            return new AuthResponseDto
            {
                UserId = user.Id,
                Token = token
            };

        }

        public async Task<IEnumerable<IdentityError>> Register([FromBody] ApiUserDto apiUserDto)
        {
            var user = _mapper.Map<ApiUser>(apiUserDto);
            user.UserName = apiUserDto.Email;
            var result = await _userMapper.CreateAsync(user, apiUserDto.Password);
            if (result.Succeeded)
            {
                await _userMapper.AddToRoleAsync(user, "User");
            }
            return result.Errors;
        }

        private async Task<string> GenerateTokens(ApiUser apiUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credendials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await _userMapper.GetRolesAsync(apiUser);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userMapper.GetClaimsAsync(apiUser);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,apiUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,apiUser.Email),
                new Claim("uid",apiUser.Id),
            }
            .Union(userClaims).Union(roleClaims);
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credendials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
