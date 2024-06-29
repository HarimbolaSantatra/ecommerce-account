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

    [HttpGet("accounts")]
    public ActionResult GetAllAccounts()
    {
	var res = new Dictionary<String, object>();
	var users = _context.Users.ToList<User>();
	if (users == null )
	{
	    res.Add("status", "null");
	}
	else
	{
	    res.Add("status", "ok");
	    res.Add("users", users);
	}
	return new JsonResult(res);
    }

    // Get user account
    [HttpGet("account/{userId:int}")]
    public ActionResult GetAccount(int userId)
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
    public ActionResult AddAccount(User user)
    {
	var res = new Dictionary<String, object>();
	// Check if user exists
	if (_context.Users.Any(u => u == user))
	{
	    res.Add("status", "userExist");
	    res.Add("description", "Error: user already exist!");
	    return new JsonResult(res);
	}
	_context.Add(user);
	_context.SaveChanges();
	res.Add("status", "added");
	res.Add("user", user);
	return new JsonResult(res);
    }

    // Delete user
    [HttpGet("account/delete")]
    public JsonResult DeleteAccount(int userId)
    {
	var res = new Dictionary<String, object>();
	// Check if user exist
	var user = _context.Users.SingleOrDefault(u => u.Id == userId);
	if (user == null)
	{
	    res.Add("status", "userNotExist");
	    res.Add("description", $"Error! The user with id {userId} does not exist!");
	    return new JsonResult(res);
	}
	_context.Remove(user);
	_context.SaveChanges();
	res.Add("status", "deleted");
	res.Add("user", user);
	return new JsonResult(res);
    }


}
