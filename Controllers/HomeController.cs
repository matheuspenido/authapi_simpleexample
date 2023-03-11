using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
	[ApiController]
	public class HomeController : ControllerBase
	{
		[HttpGet]
		[Route("api/anonymous")]
		[AllowAnonymous]
		public string Anonymous() => "Anonymous";

		[HttpGet]
		[Route("api/authenticated")]
		[Authorize]
		public string Authenticated() => $"Authenticated - {User?.Identity?.Name}";

		[HttpGet]
		[Route("api/ceo")]
		[Authorize(Roles = "ceo")]
		public string Ceo() => "You created the company!";

		[HttpGet]
		[Route("api/developer")]
		[Authorize(Roles = "developer")]
		public string Developer() => "You rule the company!";

		[HttpGet]
		[Route("api/any/authenticated")]
		[Authorize(Roles = "ceo,developer")]
		public string Any() => "Welcome!";
	}
}
