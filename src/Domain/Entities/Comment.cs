namespace Domain.Entities;

public class Comment : BaseEntity
{
  public string Content { get; set; }
    
  public Guid UserId { get; set; }
  public virtual User User { get; set; }
    
  public Guid PostId { get; set; }
  public virtual Post Post { get; set; }
    
  public int? ParentCommentId { get; set; }
  public virtual Comment ParentComment { get; set; }
    
  public virtual ICollection<Comment> Replies { get; set; } = new List<Comment>();
    
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

  public Comment()
  {
    Replies = new List<Comment>();
  }
  
}
