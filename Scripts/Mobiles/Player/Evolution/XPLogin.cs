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
                if (e.Mobile is PlayerMobile)
                {
                    //if (((PlayerMobile)e.Mobile).NextExp < DateTime.Now)
                        ((PlayerMobile)e.Mobile).Experience.NextExp = DateTime.Now.AddMinutes(10);
                }
            }
        }
    }
}