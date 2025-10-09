using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();
Console.WriteLine(ProccesData("Файл1"));
Console.WriteLine(ProccesData("Файл2"));
Console.WriteLine(ProccesData("Файл3"));

stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed);
stopwatch.Reset();

List<Task> tasks =
[
    ProccesDataAsync("File1"),
    ProccesDataAsync("File2"),
    ProccesDataAsync("File3")
];

stopwatch.Start();
await Task.WhenAll(tasks);
stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed);

string ProccesData(string dataName)
{
    Thread.Sleep(3000);
    return $"Обработка '{dataName}' завершена за 3 секунды";
}

async Task ProccesDataAsync(string dataName)
{
    await Task.Delay(3000);
    Console.WriteLine($"Обработка '{dataName}' завершена за 3 секунды");
}