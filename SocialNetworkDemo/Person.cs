using System.Net;

namespace SocialNetworkDemo;

public class Person : IPerson, IUser, IPublisher, ISubscriber
{
    private Action<IPost>? _action;
    
    private readonly List<Person> _friends = [];
    public IEnumerable<Person> Friends
    {
        get
        {
            return _friends.Select(friend => new Person()
            {
                FirstName = friend.FirstName,
                LastName = friend.LastName
            });
        }
    }

    private readonly List<IPost> _posts = [];
    public IEnumerable<IPost> Posts
    {
        get
        {
            return _posts.Select(post => new Post()
            {
                Title  = post.Title,
                Content  = post.Content
            });
        }
    }

    private readonly string _firstName;
    public string FirstName
    {
        get => _firstName;
        init =>
            _firstName = string.IsNullOrWhiteSpace(value) 
                ? throw new ArgumentNullException(nameof(FirstName)) 
                : value;
    }
    
    private readonly string _lastName;
    public string LastName
    {
        get =>  _lastName;
        init =>  _lastName  = string.IsNullOrWhiteSpace(value) 
            ? throw new ArgumentNullException(nameof(LastName))
            : value;
    }
    
    public void AddFriend(IUser user)
    {
        var friend  =  user as Person ?? throw new ArgumentException(null, nameof(user));
        _friends.Add(friend);
    }

    public void DeleteFriend(IUser user)
    {
        var friend = user as Person ?? throw new ArgumentException(null, nameof(user));
        _friends.Remove(friend);
    }

    public void Notify()
    {
        foreach (var friend in _friends)
        {
            friend.ShowNotify(Posts.Last());
        }
    }

    public void Post(IPost post)
    {
        _posts.Add(post);
        Notify();
    }

    public void ShowNotify(IPost post)
    {
        _action?.Invoke(post);
    }

    public void SetShowNotify(Action<IPost> action)
    {
        _action = action;
    }
}