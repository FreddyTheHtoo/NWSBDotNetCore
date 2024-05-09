using Newtonsoft.Json;

Console.WriteLine("Hello, World!");
string str = await File.ReadAllTextAsync("data.json");
var model = JsonConvert.DeserializeObject<MainDto>(str);


foreach(var header in model.BlogHeader)
{
    Console.WriteLine(header.BlogTitle);
}
Console.WriteLine(str);



Console.ReadLine();

public class MainDto
{
    public Blogheader[] BlogHeader { get; set; }
    public Blogdetail[] BlogDetail { get; set; }
}

public class Blogheader
{
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
}

public class Blogdetail
{
    public int BlogDetailId { get; set; }
    public int BlogId { get; set; }
    public string BlogContent { get; set; }
}

