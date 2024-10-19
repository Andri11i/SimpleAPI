using Microsoft.AspNetCore.Mvc;
using SimpleAPI;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private static List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "John Doe", Email = "johndoe@gmail.com", Phone = "123-456-7890" },
        new User { Id = 2, Name = "Tyler Derden🤠", Email = "janedoe@gmail.com", Phone = "098-765-4321" }
    };

    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(Users);
    }

    [HttpPost]
    public IActionResult AddUser(User user)
    {
        user.Id = Users.Max(u => u.Id) + 1;
        Users.Add(user);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();
        Users.Remove(user);
        return Ok(user);
    }
}
