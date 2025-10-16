namespace Domain.Entities;

public class Like : BaseEntity
{
    
  public bool IsLike { get; set; } // true for like, false for dislike
    
  public int UserId { get; set; }
  public virtual User User { get; set; }
    
  public int PostId { get; set; }
  public virtual Post Post { get; set; }
    
  public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
  
  public Like(){}

  public Like(bool isLike, int userId, int postId)
  {
    this.IsLike = isLike;
    this.UserId = userId;
    this.PostId = postId;
  }
}
