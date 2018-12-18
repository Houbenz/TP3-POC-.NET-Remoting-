using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using IRemote;

namespace ClientReceiver
{
    class ClientReceiver
    {
        static void Main(string[] args)
        {
            try {
                TcpChannel chnl = new TcpChannel();
                ChannelServices.RegisterChannel(chnl, false);

                IMailbox mailbox = (IMailbox)Activator.GetObject(typeof(IMailbox), "tcp://localhost:1234/objMailbox");

                //IFabrique fab = (IFabrique)Activator.GetObject(typeof(IFabrique), "tcp://localhost:1234/objfab");
                //IMailbox mailbox = fab.createInstance();

                if (mailbox == null)
                    Console.WriteLine("objmailbox null");
                else { 
                Console.WriteLine("acquisation de reference par Singleton \n les messages :");

                    Message[] recMsg = mailbox.ReciveMsg();
                    for (int i = 0; i < recMsg.Length - 1; i++)
                    {
                        if (recMsg[i] == null)
                        {
                            break;
                        }
                        Console.WriteLine(recMsg[i].Data);
                    }

                   }
                Console.ReadLine();
            }catch(Exception ex)
            {
                Console.WriteLine("erreur " + ex.Message);
            }
        }
    }
}
