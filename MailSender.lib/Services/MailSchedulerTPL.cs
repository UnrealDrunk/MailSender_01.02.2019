using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MailSender.lib.Entities;
using MailSender.lib.Services.Iterfaces2;

namespace MailSender.lib.Services
{
    public class MailSchedulerTPL
    {
        private readonly ISchedulerTaskStore _TaskStore;
        private volatile CancellationTokenSource _ProcessTaskCancelation = new CancellationTokenSource();

        public MailSchedulerTPL(ISchedulerTaskStore TasksStore)
        {
            _TaskStore = TasksStore;
        }

        public async Task StartAsync()
        {
            var cancellation = new CancellationTokenSource();
            Interlocked.Exchange(ref _ProcessTaskCancelation, cancellation)?.Cancel();

           var first_task = _TaskStore.GetAll()
                .Where(task => task.Time > DateTime.Now)
                .OrderBy(task => task.Time)
                .FirstOrDefault();
            if (first_task is null) return;

            WaitTaskAsync(first_task, cancellation.Token);
        }

        private async void WaitTaskAsync(SchedulerTask task, CancellationToken Cancel)
        {
            var task_time = task.Time;
            var delta = task_time.Subtract(DateTime.Now);
            await Task.Delay(delta, Cancel).ConfigureAwait(false);

            await ExecuteTask(task, Cancel);

            _TaskStore.Remove(task.Id);
            await StartAsync();
        }

        private async Task ExecuteTask(SchedulerTask task, CancellationToken Cancel)
        {

        }


    }
}
