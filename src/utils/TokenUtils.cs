namespace FusionTech.src.Utils
{
    public class TokenUtils
    {
        private readonly IConfiguration _config;

        public TokenUtils(IConfiguration config)
        {
            _config = config;
        }

        public string generateToken(Person person)
        {
            var role = PersonTypeUtils.GetPersonType(person).ToString();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, person.PersonEmail!),
                new Claim(ClaimTypes.NameIdentifier, person.PersonId.ToString()),
                new Claim(ClaimTypes.Role, role),
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value!)
            );
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var issuer = _config.GetSection("Jwt:Issuer").Value;
            var audience = _config.GetSection("Jwt:Audience").Value;

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                Expires = DateTime.Now.AddMinutes(120),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = signingCredentials,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
