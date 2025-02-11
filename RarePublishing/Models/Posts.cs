namespace RarePublishing.Models;

public class Posts
  {
    public int Id { get; set; }
    public int User_Id { get; set; }
    public int Category_Id { get; set; }
    public required string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public required string Content { get; set; }
    public bool? Approved { get; set; }
  
  }
