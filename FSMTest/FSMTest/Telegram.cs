using System;
using System.ComponentModel.DataAnnotations;

namespace FSMTest
{
    public enum msg_type
    {
        [Display(Name = "Hi Honey, I'm home!")]
        Msg_HiHoneyImHome,
        [Display(Name = "Stew is ready!")]
        Msg_StewReady
    }
    public class MsgType
    {
        public static string GetMsgName(int msg)
        {
            switch ((msg_type)msg)
            {
                case msg_type.Msg_HiHoneyImHome:
                    return "Hi Honey, I'm home!";
                case msg_type.Msg_StewReady:
                    return "Stew is ready!";
                default:
                    return "UNKNOWN!";
            }
        }
    }
    public class Telegram
    {
        public int Sender;
        public int Reciever;
        public int Msg;
        public double DispatchTime;
        public object ExtraInfo;

        public Telegram()
        {
            Sender = -1;
            Reciever = -1;
            DispatchTime = -1;
            Msg = -1;
        }

        public Telegram (double time, int sender, int reciever, int msg, object info)
        {
            DispatchTime = time;
            Sender = sender;
            Reciever = reciever;
            Msg = msg;
            ExtraInfo = info;
        }

        public const double SMALLESTDELAY = 0.25;

        public static bool operator==(Telegram t1, Telegram t2)
        {
            return (Math.Abs(t1.DispatchTime - t2.DispatchTime) < SMALLESTDELAY) &&
                    (t1.Sender == t2.Sender) &&
                    (t1.Reciever == t2.Reciever) &&
                    (t1.Msg == t2.Msg);
        }
        public static bool operator<(Telegram t1, Telegram t2)
        {
            if (t1 == t2)
                return false;
            else
                return (t1.DispatchTime < t2.DispatchTime);
        }
        public static bool operator>(Telegram t1, Telegram t2)
        {
            if (t1 == t2)
                return false;
            else
                return (t1.DispatchTime > t2.DispatchTime);
        }
        public static bool operator!=(Telegram t1, Telegram t2)
        {
            return true;
        }
    }
}
