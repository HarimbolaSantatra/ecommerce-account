namespace Account.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Linq;

[ApiController]
[Route("")]
public class MainController : ControllerBase
{

    private readonly AppDbContext _context;

    public MainController(AppDbContext context)
    {
	_context = context;
    }


    [HttpGet("")]
    public ActionResult Get()
    {
	var res = new Dictionary<String, String>();
	res.Add("status", "Account microservice is working!");
	return new JsonResult(res);
    }

    // Get user account
    [HttpGet("account/{userId:int}")]
    public ActionResult Get(int userId)
    {
	var res = new Dictionary<String, object>();
	var user = _context.Users.ToList<User>().SingleOrDefault(u => u.Id == userId);
	if (user == null )
	{
	    res.Add("status", "null");
	}
	else
	{
	    res.Add("status", "ok");
	    res.Add("user", user);
	}
	return new JsonResult(res);
    }

    // Add user account
    [HttpPost("account/add")]
    public ActionResult Add(User user)
    {
	var res = new Dictionary<String, object>();
	_context.Add(new User(user.Username));
	_context.SaveChanges();
	res.Add("status", "added");
	res.Add("user", user);
	return new JsonResult(res);
    }

}
