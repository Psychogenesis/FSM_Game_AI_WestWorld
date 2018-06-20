using System;
using System.Collections.Generic;

namespace FSMTest
{
    class MessageDispatcher
    {
        public const float SEND_MSG_IMMEDIATELY = 0.0f;
        public const int NO_ADDITIONAL_INFO = 0;

        public static MessageDispatcher Instance { get; }
        static MessageDispatcher()
        {
            Instance = new MessageDispatcher();
        }

        private SortedSet<Telegram> PriorityQ = new SortedSet<Telegram>();

//         private double Delay;
//         private int Sender;
//         private int Reciever;
//         private int Msg;
//         private object ExtraInfo;

        EntityManager EntityMgr = EntityManager.Instance;



        private void Discharge(BaseEntity pReciever, Telegram msg)
        {

        }

        public void DispatchMessage(double delay, int sender, int reciever, int msg, object ExtraInfo)
        {
            BaseEntity pSender = EntityMgr.GetEntityFromID(sender);
            BaseEntity pReciever = EntityMgr.GetEntityFromID(reciever);

            if (pReciever == null)
                Console.WriteLine("Warning! No Reciever with ID " + reciever + " is found!");

            Telegram telega = new Telegram(0, sender, reciever, msg, ExtraInfo);

            if (delay <= 0.0f)
            {
                Console.WriteLine("Instant telegram dispatched at time: " + string.Format("{0:HH:mm:ss tt}", DateTime.Now) + " by " + EntityType.GetEntityName(pSender.ID)
                    + " for " + EntityType.GetEntityName(pReciever.ID) + ". Message is: " + MsgType.GetMsgName(msg));

                Discharge(pReciever, telega);
            }
            else
            {
                double currenttime = CrudeTimer.Instance.GetCurrentTime();
                telega.DispatchTime = currenttime + delay;
                PriorityQ.Add(telega);
                Console.WriteLine("Delayed telegram from " + EntityType.GetEntityName(pSender.ID) + " recorded at time " + CrudeTimer.Instance.GetCurrentTime() + " for " + EntityType.GetEntityName(pReciever.ID)
                    + ". Message is: " + MsgType.GetMsgName(msg));
            }
        }
        public void DispatchDelayedMessage()
        {
            double CurrentTime = CrudeTimer.Instance.GetCurrentTime();
            double _DispatchTime = PriorityQ.GetEnumerator().Current.DispatchTime;
            while (!(PriorityQ.Count <= 0) &&
                  (_DispatchTime < CurrentTime) &&
                  (_DispatchTime > 0))
            {
                Telegram telegram = PriorityQ.GetEnumerator().Current;
                BaseEntity pReciever = EntityMgr.GetEntityFromID(telegram.Reciever);

                Console.WriteLine("Queued telegram ready for dispatch: Sent to " + EntityType.GetEntityName(pReciever.ID) + ". Msg is " + MsgType.GetMsgName(telegram.Msg));

                Discharge(pReciever, telegram);

                PriorityQ.Remove(PriorityQ.GetEnumerator().Current);
            }

        }            
    }
}
