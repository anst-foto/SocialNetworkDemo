using SocialNetworkDemo;

var person1 = new Person() { FirstName = "John", LastName = "Doe" };
person1.SetShowNotify(ShowPost);

var person2 = new Person()  { FirstName  = "Jane", LastName  = "Doe" };
person2.SetShowNotify(ShowPost);

var person3  = new Person()  { FirstName  = "Mary", LastName  = "Doe" };
person3.SetShowNotify(ShowPost);

person1.AddFriend(person2);
person1.AddFriend(person3);

person2.AddFriend(person1);
person2.AddFriend(person3);

person1.Post(new Post() { Title = "My first post", Content = "This is my first post" });

return;

void ShowPost(IPost post)
{
    Console.WriteLine($"{post.Title}");
    Console.WriteLine($"{post.Content}");
    Console.WriteLine();
}