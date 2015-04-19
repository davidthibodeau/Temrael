using Server.Accounting;
using Server.DataStructures;
using Server.Misc;
using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Evolution
{
    // Ceci n'est pas vraiment un item. C'est une façon de conserver dans les saves
    // les informations de transferts qui sont liés à un compte
    public class Transfert : Item
    {
        public enum Position
        {
            Premier,
            Second,
            Troisieme
        }

        public static Transfert GetTransfert(PlayerMobile m)
        {
            if (m == null || m.Account == null)
                return null;
            Account a = m.Account as Account;
            return a.Transfert;
        }

        private string account;
        private DateTime prochainTransfert;
        private bool transfertDesactive;

        public const double pourcentageConserve = 0.80;

        public Pair<string, Experience> Premier { get; set; }
        public Pair<string, Experience> Second { get; set; }
        public Pair<string, Experience> Troisieme { get; set; }

        public Transfert(string acc)
        {
            account = acc;
            prochainTransfert = DateTime.Now;
        }

        public Transfert(Serial serial)
            : base(serial)
        {
        }

        public void ConvertTagsIntoActualTransferts()
        {
            Account acc = Accounts.ServerAccounts.GetAccount(account) as Account;

            if (acc == null)
            {
                ExceptionLogging.WriteLine(new NullReferenceException(), "Account {0} not found.", account);
                return;
            }
            string save = acc.GetTag("SavedXP1");

            if (save != null)
            {
                acc.RemoveTag("SavedXP1");
                if (save != "0")
                {
                    Premier = new Pair<string, Experience>("", new Experience());
                    try
                    {
                        Premier.Right.XP = Convert.ToInt32(save);
                    }
                    catch { }
                }
            }

            save = acc.GetTag("SavedXP2");

            if (save != null)
            {
                acc.RemoveTag("SavedXP2");
                if (save != "0")
                {
                    Second = new Pair<string, Experience>("", new Experience());
                    try
                    {
                        Second.Right.XP = Convert.ToInt32(save);
                    }
                    catch { }
                }
            }

            save = acc.GetTag("SavedXP3");

            if (save != null)
            {
                acc.RemoveTag("SavedXP3");
                if (save != "0")
                {
                    Troisieme = new Pair<string, Experience>("", new Experience());
                    try
                    {
                        Troisieme.Right.XP = Convert.ToInt32(save);
                    }
                    catch { }
                }
            }
        }

        private void MoveTransfertsUp()
        {
            if (Premier == null)
            {
                if (Second != null)
                {
                    Premier = Second;
                    if (Troisieme != null)
                    {
                        Second = Troisieme;
                        Troisieme = null;
                    }
                    else
                        Second = null;
                }
                else if (Troisieme != null)
                {
                    Premier = Troisieme;
                    Troisieme = null;
                }
            }
            else if (Second == null)
            {
                if (Troisieme != null)
                {
                    Second = Troisieme;
                    Troisieme = null;
                }
            }
        }

        public void Supprimer(Position p)
        {
            switch (p)
            {
                case Position.Premier:
                    Premier = null;
                    break;
                case Position.Second:
                    Second = null;
                    break;
                case Position.Troisieme:
                    Troisieme = null;
                    break;
            }
            MoveTransfertsUp();
        }

        public bool Extraire(PlayerMobile m)
        {
            Experience exp = m.Experience;
            exp.XP = (int) (exp.XP * pourcentageConserve);
            m.Experience = new Experience();
            foreach(Skill sk in m.Skills)
            {
                sk.Base = 0;
            }

            if (Premier == null)
            {
                Premier = new Pair<string,Experience>(m.Name, exp);
                return true;
            }

            if (Second == null)
            {
                Second = new Pair<string, Experience>(m.Name, exp);
                return true;
            }

            if (Troisieme == null)
            {
                Troisieme = new Pair<string, Experience>(m.Name, exp);
                return true;
            }

            return false;
        }

        public bool Transferer(PlayerMobile pm, Position p)
        {
            switch (p)
            {
                case Position.Premier:
                    if (Premier == null) return false;
                    pm.Experience = Premier.Right;
                    pm.Experience.Niveau = 0;
                    Premier = null;
                    break;
                case Position.Second:
                    if (Second == null) return false;
                    pm.Experience = Second.Right;
                    pm.Experience.Niveau = 0;
                    Second = null;
                    break;
                case Position.Troisieme:
                    if (Troisieme == null) return false;
                    pm.Experience = Troisieme.Right;
                    pm.Experience.Niveau = 0;
                    Troisieme = null;
                    break;
            }
            MoveTransfertsUp();
            return true;
        }

        public bool PeutTransferer(out string error)
        {
            if (transfertDesactive)
            {
                error = "Votre capacité de transférer a été désactivée. Veuillez contacter un coordinateur.";
                return false;
            }

            if (DateTime.Now < prochainTransfert)
            {
                error = String.Format("Vous ne pouvez effectuer votre prochain transfert avant le {0}.", prochainTransfert);
                return false;
            }
                
            if (Premier != null && Second != null && Troisieme != null)
            {
                error = "Vous ne pouvez avoir plus de trois transferts dans votre liste.";
                return false;
            }

            error = "";
            return true;
        }

		private static void SetSaveFlag( ref SaveFlag flags, SaveFlag toSet, bool setIf )
		{
            if (setIf)
                flags |= toSet;
		}

		private static bool GetSaveFlag( SaveFlag flags, SaveFlag toGet )
		{
            return ((flags & toGet) != 0);
		}

        [Flags]
        private enum SaveFlag
        {
            None      = 0x00,
            Premier   = 0x01,
            Second    = 0x02,
            Troisieme = 0x04,
            Desactive = 0x08,
            Prochain  = 0x10
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            account = reader.ReadString();

            SaveFlag flags = (SaveFlag)reader.ReadInt();

            if (GetSaveFlag(flags, SaveFlag.Premier))
            {
                string name = "";
                if (version > 0)
                    name = reader.ReadString();
                Premier = new Pair<string, Experience>(name, new Experience(reader));
            }

            if (GetSaveFlag(flags, SaveFlag.Second))
            {
                string name = "";
                if (version > 0)
                    name = reader.ReadString();
                Second = new Pair<string, Experience>(name, new Experience(reader));
            }

            if (GetSaveFlag(flags, SaveFlag.Troisieme))
             {
                string name = "";
                if (version > 0)
                    name = reader.ReadString();
                Troisieme = new Pair<string, Experience>(name, new Experience(reader));
            }

            if (GetSaveFlag(flags, SaveFlag.Desactive))
                transfertDesactive = reader.ReadBool();
            else
                transfertDesactive = false;

            if (GetSaveFlag(flags, SaveFlag.Prochain))
                prochainTransfert = reader.ReadDateTime();
            else
                prochainTransfert = DateTime.Now;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(1); // version

            writer.Write(account);

            SaveFlag flags = SaveFlag.None;

            SetSaveFlag(ref flags, SaveFlag.Premier, Premier != null);
            SetSaveFlag(ref flags, SaveFlag.Second, Second != null);
            SetSaveFlag(ref flags, SaveFlag.Troisieme, Troisieme != null);
            SetSaveFlag(ref flags, SaveFlag.Desactive, transfertDesactive);
            SetSaveFlag(ref flags, SaveFlag.Prochain, prochainTransfert > DateTime.Now);

            writer.Write((int)flags);

            if (GetSaveFlag(flags, SaveFlag.Premier))
            {
                writer.Write(Premier.Left);
                Premier.Right.Serialize(writer);
            }

            if (GetSaveFlag(flags, SaveFlag.Second))
            {
                writer.Write(Second.Left);
                Second.Right.Serialize(writer);
            }

            if (GetSaveFlag(flags, SaveFlag.Troisieme))
            {
                writer.Write(Troisieme.Left);
                Troisieme.Right.Serialize(writer);
            }

            if (GetSaveFlag(flags, SaveFlag.Desactive))
                writer.Write(transfertDesactive);

            if(GetSaveFlag(flags, SaveFlag.Prochain))
                writer.Write(prochainTransfert);
        }
    }
}
