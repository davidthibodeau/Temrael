using Server.Mobiles;
using Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Hiding
{
    public class DetectionGarde : Detection
    {
        [CommandProperty(AccessLevel.Batisseur)]
        public int DetectionRange
        {
            get;
            set;
        }

        public DetectionGarde(Garde g)
            : base(g)
        {
            DetectionRange = 5;
        }

        public DetectionGarde(Garde g, GenericReader reader)
            : base(g)
        {
            int version = reader.ReadInt();
            
            DetectionRange = reader.ReadInt();
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(0); //version

            writer.Write(DetectionRange);
        }

        public override void DetecterAlentours()
        {
            IPooledEnumerable<Mobile> eable = mobile.GetMobilesInRange(DetectionRange);
            foreach (Mobile mob in eable)
            {
                ScriptMobile m = mob as ScriptMobile;
                if (m == null || m == mobile || !m.Hidden || !mobile.InLOS(m) || m.AccessLevel > AccessLevel.Player)
                    continue;

                m.Hidden = false;

                Packet p = null;

                IPooledEnumerable<NetState> neable = mobile.Map.GetClientsInRange(mobile.Location);

                foreach (NetState state in neable)
                {
                    if (state.Mobile.CanSee(this) && state.Mobile.InLOS(this))
                    {
                        string text = String.Format("Fais signe à {0} de déguerpir.", mob.GetNameUsedBy(state.Mobile));

                        p = new UnicodeMessage(mobile.Serial, mobile.Body, MessageType.Emote, 1209, 3, 
                            mobile.Language, mobile.Name, text);

                        p.Acquire();

                        state.Send(p);

                        Packet.Release(p);
                    }
                }
                neable.Free();
            }

            eable.Free();
        }
    }
}
