namespace DragonBallWiki.Models;

public class UserModel
{
    public string UserName { get; set; } = "unbekannt";
    public string Password { get; set; } = "passwort";


    public UserModel()
    {
        
    }


    public override string ToString()
    {
        return $"{UserName}^{Password}";
    }
}