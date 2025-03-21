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

.ML.NET is a Machine Learning framework, support for classification, regression and clustering, also integrated with python ML ecosystem.

.WPF and WinForms are used to build desktop applications. For WPF(windows presentation foundation) is a modern UI framework uses XAML to separate UI from code, and WinForms(windows forms) is an older UI framework.

...
### Run-time downloads for windows
[https://dotnet.microsoft.com/en-us/download/dotnet]

### SQLite browser
[https://sqlitebrowser.org/blog/version-3-13-1-released/]


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
var user = new User {Id="xxx", Name = "张三", Email = "zhangsan@example.com" };
context.Users.Add(user);
context.SaveChanges();
```

## C# important features
### attributes get/set
.get is used to get the value of a property, .set is used to set the value of a property.
.{ get; set; } public get and set accessors.
.{ get; private set; } public get and internal write.
.{ get; protected set; } can only be set in children classes.
```
public class Person
{
    public string Name { get; set; }

    private int _age;
    public int Age
    {
        get { return _age; }
        set { 
                if (value >= 0 && value <= 120)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentException("Age must be between 0 and 120");
                }
            }
    }

    public bool IsAdult
    {
        get { return Age >= 18; }
    }
    public DateTime BirthDate { get; set; }

    public double Salary { get; private set; }

    public int BirthYear 
    {
        get 
        {
            return DateTime.Now.Year - Age;
        }
    }

}
//usage
class Program
{
    static void Main()
    {
        Person person = new Person();
        person.Name = "zhangsan";
        person.Age = 25; 
        Console.WriteLine($"Name: {person.Name}, age: {person.Age}");
        Console.WriteLine($"IsAdult: {person.IsAdult}");
    }
}
```

### Generics
.Generics allows us code reuseable class, methods or custom classes. It can reduce code duplication and improve type safety.
We can use generics to declare class, methods, interfaces, Delegate, Struct.
.class example:
```
public class Box<T>
{
    private T value;

    public void Store(T input)
    {
        value = input;
    }

    public T Retrieve()
    {
        return value;
    }
}

// usage
class Program
{
    static void Main()
    {
        //store int value
        Box<int> intBox = new Box<int>();
        intBox.Store(123);
        int number = intBox.Retrieve();

        //store string value
        Box<string> stringBox = new Box<string>();
        stringBox.Store("Hello, World!");
        string message = stringBox.Retrieve();
    }
}
```
.method example:
```
public static void Swap<T>(ref T a, ref T b)
{
    T temp = a;
    a = b;
    b = temp;
}
//usage
int x = 5, y = 10;
Swap(ref x, ref y);

string first = "Hello", second = "World";
Swap(ref first, ref second);
```

### Reflection

Reflection(<span style="font-weight:bold">System.Reflection</span>) allows Program to inspect and manipulate the metadata of types at runtime. Shortly, it can be used to get type, method and property information at runtime.
1. dynamic type inspection(ensure the type of object at program run time).
2. dynamic invoke method.
3. read and write property attribute.
4. create new instance of class.
   
meanwhile, reflection is a heavy operation and should be used carefully. Due to this reason, reflection is not suitable for performance-critical code.

```
using System;
using System.Reflection;

//basic reflection example
public class BasicReflectionExample
{
    public void ShowBasicTypeInfo()
    {
        Type type = typeof(string);

        Console.WriteLine($"Type Name: {type.Name}");
        Console.WriteLine($"Full Typename: {type.FullName}");
        Console.WriteLine($"Namespace: {type.Namespace}");
    }
}

//inspect member type info
public class MemberInspectionDemo
{
    public void InspectTypeMembers()
    {
        Type type = typeof(Person);

        //get all public properties
        foreach(var method in type.GetMethods())
        {
            Console.WriteLine($"Method Name: {method.Name}");
        }
        //get all public properties
        foreach(var property in type.GetProperties())
        {
            Console.WriteLine($"Property Name: {property.PropertyType}");
        }

    }
}
```

### Delegate
.Delegate is a type safety object, it defines a reference type that encapsulates a method with a particular parameter list and return type. Which means delegate can store any method or params that have same return value. In some cases, it can be understand as a function pointer.
.simple example:
```
public class DelegateExample
{
    //define a delegate type
    public delegate int Calculate(int x, int y);

    //some method that matches the delegate signature
    public int Add(int a, int b)
    {
        return a + b;
    }
    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public void Demo()
    {
        Calculate calc = new Calculate(Add);
        int result = calc(5, 3);

        //change the method
        calc = multiply;
        result = calc(5, 3);
    }

}
```
.multicast delegate example:
```
public class MulticastDemo
{
    public delegate void Logger(string message);

    public void WriteToConsole(string msg)
    {
        console.WriteLine(msg);
    }

    public void WriteToFile(string msg)
    {
        System.IO.File.WriteAllText("log.txt", msg+"\n");
    }

    public void demo()
    {
        Logger logger = new Logger(WriteToConsole);
        logger += WriteToFile; //multicast delegate
        logger("Hello, World!");
    }
}
```
.NET inside delegate example:
```
public class BuildInDelegateDemo
{
    //Func: has return value
    public void DemoFunc()
    {
        Func<int, int, int> calculate = (a, b) => a + b;
        int result = calculate(5, 3);
    }
    //Action: no return value
    public void DemoAction()
    {
        Action<string> print = msg => console.WriteLine(msg);
        print("Hello, World!");
    }
}

```

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
5. multitask coding, use Task.WhenAll or await Task.WhenAll to run multiple tasks in parallel and wait for all of them to complete.
```
public async Task ExampleMethod()
{
    var task1 = DoSomethingAsync();
    var task2 = DoSomethingElseAsync();
    
    await Task.WhenAll(task1, task2);
}
```
#### summary
<span style="font-weight:bold">Since a thread can have multiple tasks, and without async will not stop other web api request</span>. Due to this reason, async and await means not distribute other threads, but improve the efficiency of the thread. With async and await, currently thread will be collected back to thread pool.
For a instance, it's like two pipeline workers, one is responsible for the packing, and another is responsible for the moving package. if the guy is packing something, the other one is no need to wait the package and move it one by one, instead of it, he can go other position and do other works. Once the packing finish, he just need move the total package one time. This can draft describe the async and await operation.

### IActionResult/ActionResult
1. <span style="font-weight:bold">IActionResult</span> is an interface in ASP.NET Core MVC that represents a result of an action method, which can be used to return different types of responses from the controller actions.
it suits for different types of responses, such as NotFound(), Ok(), StatusCode(), File(), View(), RedirectToAction() etc.
```
 [HttpGet("flexible/{id}")]
        public IActionResult GetProductFlexible(int id)
        {
            var product = _products.Find(p => p.Id == id);

            if (product == null)
                return NotFound(new { Message = "Product not found" }); // 404
            
            if (product.Price > 900)
                return StatusCode(403, new { Message = "Premium product access restricted" }); // 403

            return Ok(product); // 200
        }
```
2. <span style="font-weight:bold">ActionResult</span> is a class that implements the IActionResult interface and represents a result of an action method. It is used when you want to return a specific type of response from your controller actions.
```
 [HttpGet("specific/{id}")]
        public ActionResult<Product> GetProductSpecific(int id)
        {
            var product = _products.Find(p => p.Id == id);

            if (product == null)
                return NotFound(); // NotFoundResult

            return product; // 自动转换为 OkObjectResult
        }
```







