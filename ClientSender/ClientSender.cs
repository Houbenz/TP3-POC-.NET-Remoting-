using System;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using IRemote;

namespace ClientSender
{
    class ClientSender
    {
        static void Main(string[] args)
        {
            try
            {
                TcpChannel chnl = new TcpChannel();
                ChannelServices.RegisterChannel(chnl, false);
                Console.WriteLine("Client:canal enregistré");

                IMailbox mailbox = (IMailbox)Activator.GetObject(typeof(IMailbox), "tcp://localhost:1234/objMailBox");

                //IFabrique fab = (IFabrique)Activator.GetObject(typeof(IFabrique), "tcp://localhost:1234/objfab");
                //IMailbox mailbox = fab.createInstance();


                if (mailbox == null)
                {
                    Console.WriteLine("erreur serveur, impossible de recevoir l'objet");
                }
                else { 
                    Console.WriteLine("Réference acquise de l'objet "+ mailbox);

                    do
                    {
                        mailbox.SendMsg(new Message((String)Console.ReadLine()));
                        Console.WriteLine("voulez vous envoyer un nouveau message ? o/n");
                    }
                    while (Console.ReadLine().Equals("o"));
                }
                Console.ReadLine();

            }catch(Exception ex)
            {
                Console.WriteLine("erreur coté client : " + ex.Message+"\n"+ ex.StackTrace);
            }
        }
    }
}
