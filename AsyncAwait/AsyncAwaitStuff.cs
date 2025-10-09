using System.Diagnostics;

namespace AsyncAwait;

public class AsyncAwaitStuff
{
    private readonly Stopwatch _stopwatch = new Stopwatch();
    private string ProccesData(string dataName)
    {
        Thread.Sleep(3000);
        return $"Обработка '{dataName}' завершена за 3 секунды";
    }

    private async Task ProccesDataAsync(string dataName)
    {
        await Task.Delay(3000);
        Console.WriteLine($"Обработка '{dataName}' завершена за 3 секунды");
    }

    public void RunSync()
    {
        _stopwatch.Start();
        Console.WriteLine(ProccesData("Файл1"));
        Console.WriteLine(ProccesData("Файл2"));
        Console.WriteLine(ProccesData("Файл3"));

        _stopwatch.Stop();
        Console.WriteLine(_stopwatch.Elapsed);
        _stopwatch.Reset();
    }

    public async Task RunAsync()
    {
        List<Task> tasks =
        [
            ProccesDataAsync("File1"),
            ProccesDataAsync("File2"),
            ProccesDataAsync("File3")
        ];

        _stopwatch.Start();
        await Task.WhenAll(tasks);
        _stopwatch.Stop();
        Console.WriteLine(_stopwatch.Elapsed);
    }
}