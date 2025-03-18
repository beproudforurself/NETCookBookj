<style>
body {
  font-family: "times new roman";
}
</style>
## .NET Introduction
.NET is first released in 2002, original name is .NET Framework. And is a <span style="color:red; font-weight:bold">Windows-only software framework</span>. Final version is .NET 4.8, it continues to receive maintenance but no new features.

.NET Core is a <span style="color:red; font-weight:bold" > cross-platform</span> version of .NET Framework, it can run on Windows, Linux and macOS.And is first released in 2016.

.starts with .NET 5, Microsoft merged the two frameworks into a single framework. And .NET 5 is the first version of unified .NET. Currently, .NET 9 is the latest version.

## Major components of .NET
.ASP.NET Core is a High-performance web framework. It is used to build web applications and services.

.NET Framework Core is a modern ORM framework. And support for multiple database providers,
LINQ queries and code first development.

.Blazor is a framework for building interactive web UIs using C# instead of JavaScript.

.ML.NET is a Machine Learning framework, support for classification, regression and clustering, also intergreated with python ML ecosystem.

.WPF and WinForms are used to build desktop applications. For WPF(windows presentation foundation) is a modern UI framework uses XAML to separate UI from code, and WinForms(windows forms) is an older UI framework.

...
### Run-time downloads for windows
[https://dotnet.microsoft.com/en-us/download/dotnet]

## Type ORM in .NET
Entity Framework Core (EF Core) is a popular ORM framework for .NET. It provides an object-relational mapping layer that allows developers to work with database entities as C# objects. without writing SQL queries directly. Instead of it, EF Core allows developers to write LINQ queries in C# and automatically translates them into SQL statements for the underlying database.
### Create model class
```
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
```
### Create DbContext class
```
public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }
}
```
### multiple database providers
```
using var context = new AppDbContext();
var user = new User { Name = "张三", Email = "zhangsan@example.com" };
context.Users.Add(user);
context.SaveChanges();
```

## C# important features
### async and await
1. normally in C# we use async and await to handle <span style="font-weight:bold">asynchronous</span> operations. <span style="font-weight:bold">async</span> used to declare a method as asynchronous, and it can contain await expressions, will return a Task or Task<T> even return a void (usually we don't allow do it).
2. <span style="font-weight:bold">await</span> used to pause the execution of an async method at a certain point, and resume it when the awaited task completes. It can only be used inside async methods. identically means it will not stuck the thread.
.for example:
```
public async Task ExampleMethod()
{
    // DoSomethingAsync is an asynchronous method that returns a Task.
    await DoSomethingAsync();
    // code will stop here until DoSomethingAsync completes.
}

```
3. Task and Task<T> are used to represent an asynchronous operation. Task represents a non-generic task, and Task<T> represents a generic task that returns a value of type T when completed.
4. avoid dead clocks, stop using .Result or .Wait() to get the result of a Task, instead use await.
```
public void MethodThatCanCauseDeadlock()
{
    var result = DoSomethingAsync().Result; // here will stuck the thread and result in deadlock.
}
```
5. mutitask coding, use Task.WhenAll or await Task.WhenAll to run multiple tasks in parallel and wait for all of them to complete.
```
public async Task ExampleMethod()
{
    var task1 = DoSomethingAsync();
    var task2 = DoSomethingElseAsync();
    
    await Task.WhenAll(task1, task2);
}
```





