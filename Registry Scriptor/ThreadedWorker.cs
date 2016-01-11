using System;
using System.Threading;

namespace Registry_Scriptor
{
    class ThreadedWorker
    {
        Thread thread;
        Action run;
        Action<ThreadedWorkerOutcome> oncomp;

        public bool IsBusy { get; internal set; }

        public ThreadedWorker(Action Run, Action<ThreadedWorkerOutcome> OnCompleted)
        {
            run = Run;
            oncomp = OnCompleted;
        }

        internal void RunWorkerAsync()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                thread = new Thread((ThreadStart)delegate { run(); IsBusy = false; oncomp(ThreadedWorkerOutcome.Done); });
                thread.Start();
            }
        }

        internal void CancelAsync()
        {
            if (IsBusy)
            {
                thread.Abort();
                IsBusy = false;
                oncomp(ThreadedWorkerOutcome.Cancelled);
            }
        }
    }
    public enum ThreadedWorkerOutcome
    {
        Done, Cancelled
    }
}
