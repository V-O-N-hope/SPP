using ReverseClock;

CountDownTimer timer = new CountDownTimer(10);

timer.TimerElapsed += TimerElapsedHandler1; 
timer.TimerElapsed += TimerElapsedHandler2; 
timer.Start();

timer.TimerElapsed -= TimerElapsedHandler1;
timer.TimerElapsed += TimerElapsedHandler3;

Console.WriteLine("Таймер запущен. Ожидание...");

Console.ReadKey();


static void TimerElapsedHandler1(string message)
{
    Console.WriteLine("Таймер завершен (Обработчик 1)! Сообщение: " + message);
}

static void TimerElapsedHandler2(string message)
{
    Console.WriteLine("Таймер завершен (Обработчик 2)! Сообщение: " + message);
}

static void TimerElapsedHandler3(string message)
{
    Console.WriteLine("Таймер завершен (Обработчик 3)! Сообщение: " + message);
}
