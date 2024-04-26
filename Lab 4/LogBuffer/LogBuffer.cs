public class LogBuffer
{
    public int MsgLimit { get; }
    private int isSendind = 0;
    private long mscInterval = 0;

    Queue<string> messages;

    public LogBuffer(int messagesCapasity, long msc)
    {
        //some constants
        MsgLimit = messagesCapasity;
        mscInterval = msc;

        //messages keeper
        messages = new Queue<string>();

        TimerCallback timeCB = new TimerCallback(this.AutoSend);
        Timer time = new Timer(timeCB, null, mscInterval, mscInterval); 
    }

    public void add(string message)
    {
        String time = DateTime.Now.ToString();
        string res = $"[{time}] [{message}]";

        while (isSendind == 1) ;

        messages.Enqueue(res);
        if (messages.Count >= MsgLimit)
        {
            send();
        }
    }

    public async void send()
    {
        if (Interlocked.CompareExchange(ref isSendind, 1, 0) == 0)
        {
            String time = DateTime.Now.ToString();
            string res = $"[{time}] [dump сообщений]";

            var msgList = new List<String>();
            
            msgList.Add(res);
            
            msgList.AddRange(messages);

            messages.Clear();

            using (StreamWriter sw = new StreamWriter("log.txt", true))
            {
                foreach (string str in msgList)
                {
                    await sw.WriteLineAsync(str);
                }
            }
            isSendind = 0;
        }
    }

    private void AutoSend(object? state){
        messages.Enqueue("Timer\n");
        send();
    }
}
