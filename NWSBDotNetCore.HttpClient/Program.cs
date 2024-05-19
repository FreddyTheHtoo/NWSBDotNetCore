using Newtonsoft.Json;

Console.WriteLine("Hello, World!");
string str = await File.ReadAllTextAsync("data.json");
var model = JsonConvert.DeserializeObject<MainDto>(str);


foreach (var header in model.BlogDetail)
{
    Console.WriteLine(header.BlogContent);
}
Console.WriteLine(str);

Console.ReadLine();



public class Rootobject
{
    public Class1[] Property1 { get; set; }
}

public class Class1
{
    public string Guid { get; set; }
    public string Name { get; set; }
    public string Ingredients { get; set; }
    public string CookingInstructions { get; set; }
    public string UserType { get; set; }
}

public class MainDto
{
    public Blogheader[]? BlogHeader { get; set; }
    public Blogdetail[]? BlogDetail { get; set; }
}

public class Blogheader
{
    public int BlogId { get; set; }
    public string? BlogTitle { get; set; }
}

public class Blogdetail
{
    public int BlogDetailId { get; set; }
    public int BlogId { get; set; }
    public string? BlogContent { get; set; }
}

