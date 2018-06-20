using System.Collections.Generic;

namespace FSMTest
{
    class MessageDispatcher
    {
        public const float SEND_MSG_IMMEDIATELY = 0.0f;
        public const int NO_ADDITIONAL_INFO = 0;

        private SortedSet<Telegram> SortedQ = new SortedSet<Telegram>();
        private double delay;
        private int sender;
        private int reciever;
        private int msg;
        public static MessageDispatcher Instance { get; }
        static MessageDispatcher()
        {
            Instance = new MessageDispatcher();
        }
        private void Discharge() { }

        public void DispatchMessage()
        {

        }
        public void DispatchDelayedMessage() { }            
    }
}
