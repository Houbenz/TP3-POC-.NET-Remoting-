using System;
using IRemote;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;

namespace Serveur
{
   public class MailBox : MarshalByRefObject, IRemote.IMailbox
    {
       private Message[] messages = new Message[10];

       
        public Message[] ReciveMsg()
        {
            return messages;
        }
        public void SendMsg(Message msg)
        {

            for (int i = 0; i < messages.Length; i++)
            {
                if (messages[i] == null)
                {
                    messages[i] = msg;
                    //Console.WriteLine("message sent !");
                    break;
                }
            }
        }
    }


    public class Fabrique : MarshalByRefObject,IRemote.IFabrique
    {
        public IMailbox createInstance()
        {
            return new MailBox();
        }

    }

    class ServerMain
    {

       static void Main(string[] args) { 
           
            try {
                TcpChannel chnl = new TcpChannel(1234);
                ChannelServices.RegisterChannel(chnl, false);
               RemotingConfiguration.RegisterWellKnownServiceType(typeof(MailBox), "objMailBox", WellKnownObjectMode.SingleCall);

                //RemotingConfiguration.RegisterWellKnownServiceType(typeof(Fabrique),"objfab",WellKnownObjectMode.Singleton);

                Console.WriteLine("serveur lancé");
                Console.ReadLine();
            }catch(Exception ex)
            {
                Console.WriteLine("Serveur: erreur d'init" + ex.Message);
            }

        }
    }
}
