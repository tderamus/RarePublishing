namespace RarePublishing.Models;

public class Comments
  {
    public int Id { get; set; }
    public int Author_Id { get; set; }
    public int Post_Id { get; set; }
    public required string Content { get; set; }
  
  }
