using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    /// <summary>
    /// Non branchée pour le moment. Mais ça servira pour équilibrer plus
    /// facilement le combat. On y trouvera les résolutions (toucher, parrer, etc)
    /// mais aussi les dégats des armes sous forme de DPS. Les dégats seront
    /// calculé automatiquement en fonction du: Port d'attirail, arme une main/deux main,
    /// de la vitesse, et des bonus de dex(vitesse) et de force (dégats).
    /// Bien sur les aptitudes seront prisent en compte ici également
    /// </summary>
    public class CombatManager
    {
        private static object locker = new object();
        private static CombatManager m_Instance = null;

        public static CombatManager get()
        {
            if (m_Instance != null)
                return m_Instance;
            else
            {
                lock (locker)
                {
                    m_Instance = new CombatManager();
                    return m_Instance;
                }
            }
        }

        
        /*public void ConfigureCreature(BaseCreature mob, int niveau)
        {
            mob.SetStr(60 + niveau, 60 + niveau * 2);
            mob.SetDex( Math.Min(100, 20 + niveau), Math.Min(110,20 + niveau * 2) );
            mob.SetInt(60 + niveau, 60 + niveau * 2);


            mob.SetSkill(SkillName.ArmePoing, 30 + niveau * 2, 35 + niveau * 2);
            mob.SetSkill(SkillName.Tactiques, 30 + niveau * 2, 35 + niveau * 2);
            mob.SetSkill(SkillName.Parer, 35 + niveau * 2, 40 + niveau * 2);
            mob.SetSkill(SkillName.ArtMagique, 35 + niveau * 2, 40 + niveau * 2);

            double dam = (( (double)niveau / 3.0) + 4.0) ;

            
            
            mob.SetDamage( (int)(dam * .8), (int)(dam * 1.2) );

           

            mob.VirtualArmor = Math.Min( 70, (int)(niveau * 3.2) );

            mob.SetHits(5 + niveau * 14, 5 + niveau * 16);
        }*/

    
    }
}
