namespace SocialNetworkDemo;

public interface IUser
{
    public void AddFriend(IUser user);
    public void DeleteFriend(IUser user);
}