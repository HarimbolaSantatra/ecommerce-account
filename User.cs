namespace Account;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("User")]
public class User
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }

    public User(string username)
    {
	this.Username = username;
    }

    public Dictionary<string, string> Serialize()
    {
	Dictionary<String, string> res = new Dictionary<String, string>();
	res.Add("id", Id.ToString());
	res.Add("username", Username);
	return res;

    }
}
