namespace RarePublishing.Models;

public class Users
  {
    public int Id { get; set; }
    public required string First_Name { get; set; }
    public required string Last_Name { get; set; }
    public required string Email { get; set; }
    public required string Bio { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public DateTime Created_On { get; set; }
    public bool Active { get; set; }
  
  }
