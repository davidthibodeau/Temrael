using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Targeting;
using Server.Mobiles;
using Server.Network;
using Server.Commands;

namespace Server.Commandes.Temrael
{
    class AddRandom
    {

        public static void Initialize()
        {
            CommandSystem.Register("AddRandom", AccessLevel.Batisseur, new CommandEventHandler(AddRandom_OnCommand));
        }


        [Usage("AddRandom <object> <amount>")]
        [Description("Permet d'ajouter un objet <amount> fois dans une zone définie par deux targets, de façon aléatoire.")]
        private static void AddRandom_OnCommand(CommandEventArgs e)
        {
            AddRandomHandler arh = new AddRandomHandler(e);

            if (arh.ValidateArgs())
            {
                arh.Do();
            }

        }

        public class AddRandomHandler
        {
            private const int MAXIMUM_AMOUNT = 225;

            // Parce que ça a pas d'allure passer 15 paramètres dans les fonctions static...
            public struct Values
            {
                public Mobile from;
                public CommandEventArgs cmdArgs;
                public Type typeObject;
                public int amount;
            }

            Values v;


            /* Trouve l'objet à placer, et prend le args <amount> si il existe.
             * Retourne true si l'objet a été trouvé.*/
            public bool ValidateArgs()
            {
                if (v.cmdArgs.Length >= 1)
                {
                    v.typeObject = ScriptCompiler.FindTypeByName(v.cmdArgs.GetString(0));

                    if (v.typeObject != null)
                    {
                        if (v.cmdArgs.GetInt32(1) <= MAXIMUM_AMOUNT && v.cmdArgs.GetInt32(1) > 0)
                        {
                            v.amount = v.cmdArgs.GetInt32(1);
                        }
                        // else m_amount = 1; Setté par défaut dans le constructeur.

                        return true;
                    }
                    else
                    {
                        v.cmdArgs.Mobile.SendMessage("L'objet n'a pas été trouvé.");
                    }
                }
                else
                {
                    v.cmdArgs.Mobile.SendMessage("Le nom de l'objet doit être spécifié.");
                }

                return false;
            }


            /* Fonction principale qui appelle une série d'autres fonctions.
             * Crée deux targets, une fois que les targets sont trouvés, appelle la fonction ValidateTargets().*/
            public void Do()
            {
                v.from.Target = new GroundTarget1(v);
            }

            /* Valide les targets et prend leur position, avant d'appeller la fonction AddObjects(). */
            protected static void ValidateTargets(Values v, object target1, object target2)
            {
                IPoint3D p1 = target1 as IPoint3D;
                IPoint3D p2 = target2 as IPoint3D;

                if (p1 == null)
                    return;
                if (p2 == null)
                    return;

                if (p1 is Item)
                    p1 = ((Item)p1).GetWorldTop();
                else if (p1 is Mobile)
                    p1 = ((Mobile)p1).Location;

                if (p2 is Item)
                    p2 = ((Item)p2).GetWorldTop();
                else if (p2 is Mobile)
                    p2 = ((Mobile)p2).Location;

                AddObjects(v, p1, p2);
            }

            /* Crée l'objet "m_item" m_amount fois entre les deux points passés en paramètre, de façon aléatoire.*/
            private static void AddObjects(Values v, IPoint3D point1, IPoint3D point2)
            {
                Point3D point = new Point3D();
                object o;
                for (int i = 0; i < v.amount; i++)
                {
                    point.X = Utility.RandomMinMax(point1.X, point2.X);
                    point.Y = Utility.RandomMinMax(point1.Y, point2.Y);
                    point.Z = v.from.Location.Z + 5;

                    o = v.from.Map.GetTopSurface(point);

                    if (o == null)
                        return;

                    if (o is LandTile)
                    {
                        point.Z = ((LandTile)o).Z;
                    }
                    else if (o is StaticTile)
                    {
                        point.Z = ((StaticTile)o).Z;
                    }

                    String[] s = new String[1];
                    s[0] = v.cmdArgs.GetString(0);
                    Add.Invoke(v.from, point, point, s);
                }
            }


            // ctor
            public AddRandomHandler(CommandEventArgs e)
            {
                v.from = e.Mobile;
                v.cmdArgs = e;
                v.typeObject = null;
                v.amount = 1;
            }

            private class GroundTarget1 : Target
            {
                Values m_v;
                public GroundTarget1(Values v)
                    : base(15, true, TargetFlags.None)
                {
                    m_v = v;
                }

                protected override void OnTarget(Mobile from, object targeted)
                {
                    from.Target = new GroundTarget2(m_v, targeted);
                }
            }

            private class GroundTarget2 : Target
            {
                Values m_v;
                private object m_Targeted1;

                public GroundTarget2(Values v, object targeted1)
                    : base(15, true, TargetFlags.None)
                {
                    m_v = v;
                    m_Targeted1 = targeted1;
                }

                protected override void OnTarget(Mobile from, object targeted)
                {
                    ValidateTargets(m_v, m_Targeted1, targeted);
                }
            }
        }
    }
}
