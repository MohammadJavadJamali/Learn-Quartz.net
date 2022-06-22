using DataAccess;
using Quartz;

namespace WorkerService.Jobs;

public class DeleteExpiredCart : IJob
{
    private readonly DataContext _dataContext;

    public DeleteExpiredCart(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine("DeleteExpiredCart is working");

        var carts = _dataContext.Carts;

        foreach(var cart in carts)
        {
            if(DateTime.Now.Day - cart.DateOfRegistration.Day > 7)
            {
                _dataContext.Carts.Remove(cart);
            }
        }
        _dataContext.SaveChanges();

        return Task.CompletedTask;
    }
}
