using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Gumps;
using System.Collections;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{

    public class PathTester : BaseCreature
    {
        [Constructable]
        public PathTester() : base(   AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
        {
            SetStr( 10, 30 );
            SetDex( 10, 30 );
            SetInt( 10, 30 );
            SpeechHue = Utility.RandomDyedHue();
            Title = "Path Tester";
            Hue = Utility.RandomSkinHue();
            Blessed = true;
            NameHue = 0x35;
            Debug = true;

            this.Body = 0x190;
            this.Name = NameList.RandomName( "male" );
            Item hair = new Item( Utility.RandomList( 0x203B, 0x203C, 0x203D, 0x2044, 0x2045, 0x2047, 0x2048 ) );
            hair.Hue = Utility.RandomHairHue();
            hair.Layer = Layer.Hair;
            hair.Movable = false;
            AddItem( hair );
            Item beard = new Item( Utility.RandomList( 0x0000, 0x203E, 0x203F, 0x2040, 0x2041, 0x2067, 0x2068, 0x2069 ) );
            AddItem( new LongPants( GetRandomHue() ) );
            AddItem( new FancyShirt( GetRandomHue() ) );
            AddItem( new Boots( Utility.RandomNeutralHue() ) );
            AddItem( new Cloak( GetRandomHue() ) );

            Container pack = new Backpack();
            pack.Movable = false;
		    pack.Visible = false;
			
			
            AddItem( pack );
        }

       public override bool ClickTitle{ get{ return false; } }

       public override bool PlayerRangeSensitive
       {
	       get { return false; }
       }
		    

       
       public override bool HandlesOnSpeech( Mobile from )
       {
         if ( from.InRange( this.Location, 20 ) )
            return true;

         return base.HandlesOnSpeech( from );
       }

       public void Goto(int x, int y, int z)
       {
			if (!AIObject.MoveToDistant(new Point3D(x,y,z),false))
			{
				this.DebugSay("Unable to reach location");
				CurrentSpeed = 3;
			}	       
       }
       
		public override void OnSpeech( SpeechEventArgs e )
		{
			//base.OnSpeech( e );

			Mobile from = e.Mobile;

			if ( from.InRange( this, 20 ))
			{
				if (from != null)
				{
					if (e.Speech.ToLower().IndexOf("go") > -1) 
					{
						string gostring = e.Speech.ToLower();						
						string[] goprops = gostring.Split(' ');
						
						int x, y, z;
						if (goprops.Length ==4)
						{
							x = GetIntArg(goprops[1]);
							y = GetIntArg(goprops[2]);
							z = GetIntArg(goprops[3]);
						}
						else if (goprops.Length ==3)
						{
							x = GetIntArg(goprops[1]);
							y = GetIntArg(goprops[2]);
							z = 0;														
						}
						else
						{
							from.Target = new InternalTarget(this);
							return;
						}						
						
                    	this.DebugSay("Going to location "+x+","+y+","+z);
                    	CurrentSpeed = 0.5;
						if (!AIObject.MoveToDistant(new Point3D(x,y,z),false))
						{
							this.DebugSay("Unable to reach location");
							CurrentSpeed = 3;
						}
               		}
					if (e.Speech.ToLower().IndexOf("stop") > -1) 
					{
						AIObject.StopMove();
						CurrentSpeed = 3;
					}
				}
			}
		}

        public int GetIntArg(string arg)
        {
	        arg = arg.Trim();
	        int i = 0;
            try { i = int.Parse(arg);}
            catch { Console.WriteLine("PathTester: int expected but unable to parse"+arg+""); }
			return i;
        }
			
		public override bool DisallowAllMoves
		{
			get { return false; }
		}
	
		public PathTester( Serial serial ) : base( serial )
		{
		}
	
		private int GetRandomHue()
		{
	        switch ( Utility.Random( 6 ) )
	        {
	            default:
	            case 0: return 0;
	            case 1: return Utility.RandomBlueHue();
	            case 2: return Utility.RandomGreenHue();
	            case 3: return Utility.RandomRedHue();
	            case 4: return Utility.RandomYellowHue();
	            case 5: return Utility.RandomNeutralHue();
	        }
	    }
	

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
        }

		private class InternalTarget : Target
		{
			private PathTester m_pt;
			public InternalTarget(PathTester p) : base( 12, true, TargetFlags.None )
			{
				m_pt = p;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				IPoint3D p3d = o as IPoint3D;
				m_pt.Goto(p3d.X, p3d.Y, p3d.Z);				
			}

			protected override void OnTargetFinish( Mobile from )
			{
			}
		}
    }
}

