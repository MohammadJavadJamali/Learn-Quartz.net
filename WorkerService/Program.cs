using Quartz;
using WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostBuilderContext, services) =>
    {
        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionJobFactory();

            var jobKey = new JobKey("HelloWorldJob");

            q.AddJob<HelloWorldJob>(j => j.WithIdentity(jobKey));

            q.AddTrigger(options => options
                .ForJob(jobKey)
                .WithIdentity("HelloWorldJob-trigger")
                .WithCronSchedule("0/5 * * * * ?"));
        });

        services.AddQuartzHostedService(
            q => q.WaitForJobsToComplete = true);
    })
    .Build();

await host.RunAsync();
