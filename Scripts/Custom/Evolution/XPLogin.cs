using System;
using System.Text;
using Server;
using Server.Commands;
using Server.Mobiles;

namespace Server
{
    class Broadcast
    {
        public static void Initialize()
        {
            EventSink.Login += new LoginEventHandler(EventSink_Login);
        }

        public static void EventSink_Login(LoginEventArgs e)
        {
            if (e.Mobile.Player)
            {
                if (e.Mobile is TMobile)
                {
                    //if (((TMobile)e.Mobile).NextExp < DateTime.Now)
                        ((TMobile)e.Mobile).NextExp = DateTime.Now.AddMinutes(10);
                }
            }
        }
    }
}