namespace reasearchweb.Domain.Entities;

public class Post : BaseEntity
{
  public string Title { get; private set; }
    
  public string Content { get; private set; }
    
  public string ImageUrl { get; private set; }
    
  public string VideoUrl { get; private set; }
    
  public Guid UserId { get; private set; }
  public virtual User User { get; private set; }
    
  public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
  public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

  public  Post()
  {
    Likes = new List<Like>();
    Comments = new List<Comment>();
  }
  
}
