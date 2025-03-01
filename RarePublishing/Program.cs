using RarePublishing.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


List<Users> users = new List<Users>
    {
        new Users { Id = 1, First_Name = "John", Last_Name = "Doe", Email = "john.doe@example.com", Bio = "Writer and blogger", Username = "johndoe", Password = "password123", Created_On = new
        DateTime(2025, 2, 1), Active = true },
        new Users { Id = 2, First_Name = "Jane", Last_Name = "Smith", Email = "jane.smith@example.com", Bio = "Tech enthusiast", Username = "janesmith", Password = "securepass", Created_On = new DateTime(2025, 1, 29), Active = true }
    };

List<Categories> categories = new List<Categories>
    {
        new Categories { Id = 1, Label = "Technology" },
        new Categories { Id = 2, Label = "Health" }
    };

List<Posts> posts = new List<Posts>
    {
        new Posts { Id = 1, User_Id = 2, Category_Id = 1, Title = "The Future of AI", PublicationDate = new DateTime(2025, 2, 5), Content = "AI is evolving rapidly...", Approved = true },
        new Posts { Id = 2, User_Id = 1, Category_Id = 2, Title = "Healthy Eating Tips", PublicationDate = new DateTime(2025, 2, 10), Content = "Eating healthy is essential...", Approved = true }
    };

List<Comments> comments = new List<Comments>
    {
        new Comments { Id = 1, Author_Id = 2, Post_Id = 1, Content = "Great insights on AI!" },
        new Comments { Id = 2, Author_Id = 1, Post_Id = 2, Content = "Very helpful tips!" }
    };

List<Reactions> reactions = new List<Reactions>
    {
        new Reactions { Id = 1, Emoji = 128077 }, // 👍
        new Reactions { Id = 2, Emoji = 128078 }  // 👎
    };

List<PostReactions> postReactions = new List<PostReactions>
    {
        new PostReactions { Id = 1, Reaction_Id = 1, Post_Id = 1, User_Id = 2 },
        new PostReactions { Id = 2, Reaction_Id = 2, Post_Id = 2, User_Id = 1 }
    };

List<Tags> tags = new List<Tags>
    {
        new Tags { Id = 1, Label = "AI" },
        new Tags { Id = 2, Label = "Nutrition" }
    };

List<PostTags> postTags = new List<PostTags>
    {
        new PostTags { Id = 1, Post_Id = 1, Tag_Id = 1 },
        new PostTags { Id = 2, Post_Id = 2, Tag_Id = 2 }
    };

List<Subscriptions> subscriptions = new List<Subscriptions>
    {
        new Subscriptions { Id = 1, Follower_Id = 1, Author_Id = 2, Created_On = new DateTime(2025, 2, 4) },
        new Subscriptions { Id = 2, Follower_Id = 2, Author_Id = 1, Created_On = new DateTime(2025, 2, 3) }
    };


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//CALLS BEGIN AROUND HERE
app.MapPost("/posts", (Posts post) =>
{
 post.Id = posts.Max(st => st.Id) + 1;
 posts.Add(post);

 return Results.Ok(post);
});

app.MapPut("/posts/{id}", (int id, Posts post) =>
{
Posts postToUpdate = posts.FirstOrDefault(st => st.Id == id);
int postIndex = posts.IndexOf(postToUpdate);

if (postToUpdate == null)
    {
        return Results.NotFound();
    }
    if (id != post.Id)
    {
        return Results.BadRequest();
    }
    posts[postIndex] = post;
    return Results.Ok(postToUpdate);
});

app.MapPost("/comments", (Comments comment) =>
{
 comment.Id = comments.Max(st => st.Id) + 1;
 comments.Add(comment);

 return Results.Ok(comment);
});

app.MapGet("/posts/{id}", (int id) =>
{
    Posts post = posts.FirstOrDefault(p => p.User_Id == id);
    if (post == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(post);
});

app.MapGet("/posts", () =>
{
    return Results.Ok(posts);
});

app.MapPost("/tags", (Tags tag) =>
{
 tag.Id = tags.Max(st => st.Id) + 1;
 tags.Add(tag);

 return Results.Ok(tag);
});

app.MapPost("/categories", (Categories Category) =>
{
 Category.Id = categories.Max(st => st.Id) + 1;
 categories.Add(Category);

 return Results.Ok(Category);
});

app.MapPost("/users", (Users user) =>
{
 user.Id = users.Max(st => st.Id) + 1;
 users.Add(user);

 return Results.Ok(user);
});

app.MapDelete("/posts/{id}", (int id) =>
{
    Posts post = posts.FirstOrDefault(st => st.Id == id);

    posts.Remove(post);

    return Results.Ok(post);
});





app.Run();
