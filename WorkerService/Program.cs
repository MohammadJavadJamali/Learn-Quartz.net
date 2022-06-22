using DataAccess;
using Microsoft.EntityFrameworkCore;
using Quartz;
using WorkerService;
using WorkerService.Jobs;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostBuilderContext, services) =>
    {
        services.AddDbContext<DataContext>(options => options
            .UseSqlServer(hostBuilderContext.Configuration.GetConnectionString("DefualtConnection")));

        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionJobFactory();

            q.AddJobAndTrigger<HelloWorldJob>(hostBuilderContext.Configuration);
            q.AddJobAndTrigger<DeleteExpiredCart>(hostBuilderContext.Configuration);
        });

        services.AddQuartzHostedService(
            q => q.WaitForJobsToComplete = true);
    })
    .Build();

await host.RunAsync();
