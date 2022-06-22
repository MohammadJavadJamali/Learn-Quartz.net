using Quartz;

namespace WorkerService;

public class HelloWorldJob : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine("Hello world!{0}");
        return Task.CompletedTask;
    }
}
