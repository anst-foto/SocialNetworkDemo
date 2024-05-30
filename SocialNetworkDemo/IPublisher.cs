namespace SocialNetworkDemo;

public interface IPublisher
{
    public void Notify();
    public void Post(IPost post);
}