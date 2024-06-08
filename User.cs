namespace Account;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("User")]
[Index(nameof(Username), IsUnique = true)]
public class User
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }

    public User()
    {
    }

    public Dictionary<string, string> Serialize()
    {
	Dictionary<String, string> res = new Dictionary<String, string>();
	res.Add("id", Id.ToString());
	res.Add("username", Username);
	return res;

    }
}
