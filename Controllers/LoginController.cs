using AuthApi.Models;
using AuthApi.Repositories;
using AuthApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers;

[ApiController]
public class LoginController : ControllerBase
{
	[HttpPost]
	[Route("api/log")]
	public ActionResult<dynamic> Authenticate([FromBody] User model)
	{
		//Retrieve the user on our simulated repository.
		var user = UserRepository.Get(model.Username, model.Password);

		//Verify the user.
		if (user == null)
		{
			return NotFound(new { message = "Invalid User or Password!"});
		}

		//Get the token if the user is found on our fake generator token service.
		var token = TokenService.GenerateToken(user);

		return new
		{
			user = user.Username,
			token
		};
	}
}
