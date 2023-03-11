using AuthApi.Models;

namespace AuthApi.Repositories;

public static class UserRepository
{
	public static User? Get(string username, string password)
	{
		var users = new List<User>()
		{
			new() { Id = 1, Username = "ceo@123", Password = "supersecret", Role = "ceo" },
			new() { Id = 2, Username = "developer@123", Password = "ultrasecret", Role = "developer" }
		};

		return users
			.FirstOrDefault(x => 
				x.Username == username
				&& x.Password == password);
	}
}
