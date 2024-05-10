// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

string jsonStr = await File.ReadAllTextAsync("data.json");
var model = JsonConvert.DeserializeObject<MainDto>(jsonStr)!;
//Console.WriteLine(jsonStr);

foreach (var q in model.questions)
{
    Console.Write(q.questionNo);
}

static void ToNumber(string num)
{
    num.Replace("၃", "3");
    num.Replace("၁၀", "10");
}

// JSON to C# ??? package
// C# to JSON

Console.ReadKey();


public class MainDto
{
    public Question[] questions { get; set; }
    public Answer[] answers { get; set; }
    public string[] numberList { get; set; }
}

public class Question
{
    public int questionNo { get; set; }
    public string questionName { get; set; }
}

public class Answer
{
    public int questionNo { get; set; }
    public int answerNo { get; set; }
    public string answerResult { get; set; }
}

