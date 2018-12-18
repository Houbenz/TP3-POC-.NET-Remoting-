using System;


namespace IRemote
{

    public interface IMailbox
    {
        void SendMsg(Message msg);
        Message[] ReciveMsg();
    }


    public interface IFabrique
    {
         IMailbox createInstance();

    }

    [Serializable]
    public class Message

    {

        string data;

        public Message(string data)
        {
            this.data = data;
        }
    
        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
    }
}