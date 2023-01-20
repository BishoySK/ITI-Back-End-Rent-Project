using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Realstate_BL;
using Realstate_DAL;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project_realestate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly UserManager<UserClass> userManager;
        private readonly IConfiguration configuration;

        public SecurityController(UserManager<UserClass> _userManager,IConfiguration _configuration )
        {
            userManager = _userManager;
            configuration = _configuration;
        }


        #region Register
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(Register register)
        {
      
            var DAL_User = new UserClass
            {
                UserName = register.UserName,
                Email = register.Email,
            };

            //for hashing Password
            var Result = await userManager.CreateAsync(DAL_User,register.Password);

            if (!Result.Succeeded) return BadRequest(Result.Errors);

            //Saving claims
            var UserClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,DAL_User.Id.ToString())
            };

            //Adding the claims to user
            await userManager.AddClaimsAsync(DAL_User,UserClaims);

            return NoContent();
        }
        #endregion

        #region Login
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDTO>> Login(LoginDTO loginDTO)
        {
            //Find User by his Name
            var DbUser = await userManager.FindByNameAsync(loginDTO.UserName);

            
            if (DbUser is null) return BadRequest(new {Message ="Can not find User"});

            
            //Check if the user is locked
            var IsLocked = await userManager.IsLockedOutAsync(DbUser);

            if(IsLocked) return BadRequest(new {Message ="You are locked"});

            //Comparing user password to his saved password though hashing 
            bool CheckPassword = await userManager.CheckPasswordAsync(DbUser, loginDTO.Password);    


            //Increasing failed attempet if he enters wrong password
            if(!CheckPassword)
            {
                await userManager.AccessFailedAsync(DbUser);
                return Unauthorized();
            }

            //Get user claims
            var UserClaim = await userManager.GetClaimsAsync(DbUser);

            //Get secret key and transform it into bytes 
            var GetSecretKey = configuration.GetValue<string>("SecretKey");
            var KeyOutByte = Encoding.ASCII.GetBytes(GetSecretKey);
            var SecuritySecretKey = new SymmetricSecurityKey(KeyOutByte);

            
            var SigningCredential = new SigningCredentials(SecuritySecretKey, SecurityAlgorithms.HmacSha256Signature);


            //Create the token
            var JsonWebToken = new JwtSecurityToken
                (
                claims:UserClaim,
                expires: DateTime.Now.AddHours(8),
                notBefore:DateTime.Now,
                signingCredentials:SigningCredential
                );

            

            var JsonWebTokenHandler = new JwtSecurityTokenHandler();

            return new TokenDTO { Token = JsonWebTokenHandler.WriteToken(JsonWebToken) };
        }


        #endregion


    }
}
