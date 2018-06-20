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
        int Sender;
        int Reciever;
        int Msg;
        double DispatchTime;
        string ExtraInfo;
        public Telegram()
        {
            Sender = -1;
            Reciever = -1;
            DispatchTime = -1;
            Msg = -1;
        }
        public Telegram (double time, int sender, int reciever, int msg, string info)
        {
            DispatchTime = time;
            Sender = sender;
            Reciever = reciever;
            Msg = msg;
            ExtraInfo = info;
        }
    }
}
