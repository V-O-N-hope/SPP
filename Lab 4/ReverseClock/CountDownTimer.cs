namespace ReverseClock
{
    public class CountDownTimer
    {
        private int secondsToWait;
        private Timer? timer;
        private List<Action<string>> eventHandlers;

        public CountDownTimer(int seconds)
        {
            secondsToWait = seconds;
            eventHandlers = new List<Action<string>>();
        }

        public event Action<string> TimerElapsed
        {
            add { eventHandlers.Add(value); }
            remove { eventHandlers.Remove(value); }
        }

        public void Start()
        {
            timer = new Timer(TimerCallback, null, secondsToWait * 1000, 0);
        }

        private void TimerCallback(object? state)
        {
            OnTimerElapsed("Таймер завершен!");
        }

        protected virtual void OnTimerElapsed(string message)
        {
            foreach (var handler in eventHandlers)
            {
                handler.Invoke(message);
            }
        }
    }
}