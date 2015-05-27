using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Items
{
    public class RepubliqueInstitutionHandler : InstitutionHandler
    {

        public override List<int> RangSalaire        // Contient les salaires des différents échelons.
        {
            get
            {
                return new List<int> 
                {
                    0,   // Aucun rang.
                    0,   // Gardé à 0 pour empêcher n'importe qui de rejoindre.
                    1500,// Tribun
                    2000,// Consul
                };
            }
        }

        [Constructable]
        public RepubliqueInstitutionHandler()
            : base()
        {
        }

        public RepubliqueInstitutionHandler(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
}

