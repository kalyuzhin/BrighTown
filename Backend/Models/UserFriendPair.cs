namespace Backend.Models;

//[Keyless]
public class UserFriendPair
{
    public int Id { get; set; }
    public int UserId { get; set; } = 0;
    public int FriendId { get; set; } = 0;
}


