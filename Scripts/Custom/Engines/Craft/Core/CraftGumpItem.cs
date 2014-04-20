using System;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Craft
{
	public class CraftGumpItem : Gump
	{
		private Mobile m_From;
		private CraftSystem m_CraftSystem;
		private CraftItem m_CraftItem;
		private BaseTool m_Tool;

		private const int LabelHue = 0x480; // 0x384
		private const int RedLabelHue = 0x20;

		private const int LabelColor = 0x7FFF;
		private const int RedLabelColor = 0x6400;

		private const int GreyLabelColor = 0x3DEF;

		private int m_OtherCount;

		public CraftGumpItem( Mobile from, CraftSystem craftSystem, CraftItem craftItem, BaseTool tool ) : base( 40, 40 )
		{
			m_From = from;
			m_CraftSystem = craftSystem;
			m_CraftItem = craftItem;
			m_Tool = tool;

			from.CloseGump( typeof( CraftGump ) );
			from.CloseGump( typeof( CraftGumpItem ) );

			AddPage( 0 );
			AddBackground( 0, 0, 530, 417, 5054 );
			AddImageTiled( 10, 10, 510, 22, 2624 );
			AddImageTiled( 10, 37, 150, 148, 2624 );
			AddImageTiled( 165, 37, 355, 90, 2624 );
			AddImageTiled( 10, 190, 155, 22, 2624 );
			AddImageTiled( 10, 217, 150, 53, 2624 );
			AddImageTiled( 165, 132, 355, 80, 2624 );
			AddImageTiled( 10, 275, 155, 22, 2624 );
			AddImageTiled( 10, 302, 150, 53, 2624 );
			AddImageTiled( 165, 217, 355, 80, 2624 );
			AddImageTiled( 10, 360, 155, 22, 2624 );
			AddImageTiled( 165, 302, 355, 80, 2624 );
			AddImageTiled( 10, 387, 510, 22, 2624 );
			AddAlphaRegion( 10, 10, 510, 399 );

            AddHtml(170, 40, 150, 20, "<h3><basefont color=#FFFFFF>Objet<basefont></h3>", false, false);
            AddHtml(10, 192, 150, 22, "<h3><basefont color=#FFFFFF><center>Compétences</center><basefont></h3>", false, false);
            AddHtml(10, 277, 150, 22, "<h3><basefont color=#FFFFFF><center>Matériaux</center><basefont></h3>", false, false);
            AddHtml(10, 362, 150, 22, "<h3><basefont color=#FFFFFF><center>Autre</center><basefont></h3>", false, false);

			//AddHtmlLocalized( 170, 40, 150, 20, 1044053, LabelColor, false, false ); // ITEM
			//AddHtmlLocalized( 10, 192, 150, 22, 1044054, LabelColor, false, false ); // <CENTER>SKILLS</CENTER>
			//AddHtmlLocalized( 10, 277, 150, 22, 1044055, LabelColor, false, false ); // <CENTER>MATERIALS</CENTER>
			//AddHtmlLocalized( 10, 362, 150, 22, 1044056, LabelColor, false, false ); // <CENTER>OTHER</CENTER>

			if ( craftSystem.GumpTitleNumber > 0 )
				AddHtmlLocalized( 10, 12, 510, 20, craftSystem.GumpTitleNumber, LabelColor, false, false );
			else
				//AddHtml( 10, 12, 510, 20, craftSystem.GumpTitleString, false, false );
                AddHtml(10, 12, 510, 20, "<h3><basefont color=#FFFFFF><center>" + craftSystem.GumpTitleString + "</center><basefont></h3>", false, false);

			AddButton( 15, 387, 4014, 4016, 0, GumpButtonType.Reply, 0 );
			//AddHtmlLocalized( 50, 390, 150, 18, 1044150, LabelColor, false, false ); // BACK
            AddHtml(50, 390, 150, 20, "<h3><basefont color=#FFFFFF>Retour<basefont></h3>", false, false);

			bool needsRecipe = ( craftItem.Recipe != null && from is PlayerMobile && !((PlayerMobile)from).HasRecipe( craftItem.Recipe ) );

			if( needsRecipe )
			{
				AddButton( 270, 387, 4005, 4007, 0, GumpButtonType.Page, 0 );
				//AddHtmlLocalized( 305, 390, 150, 18, 1044151, GreyLabelColor, false, false ); // MAKE NOW
                AddHtml(305, 390, 150, 20, "<h3><basefont color=#FFFFFF>Fabriquer<basefont></h3>", false, false);
			}
			else
			{
				AddButton( 270, 387, 4005, 4007, 1, GumpButtonType.Reply, 0 );
				//AddHtmlLocalized( 305, 390, 150, 18, 1044151, LabelColor, false, false ); // MAKE NOW
                AddHtml(305, 390, 150, 20, "<h3><basefont color=#FFFFFF>Fabriquer<basefont></h3>", false, false);
			}

			if ( craftItem.NameNumber > 0 )
				AddHtmlLocalized( 330, 40, 180, 18, craftItem.NameNumber, LabelColor, false, false );
			else
				//AddLabel( 330, 40, LabelHue, craftItem.NameString );
                AddHtml(330, 40, 150, 20, "<h3><basefont color=#FFFFFF><center>" + craftItem.NameString + "</center><basefont></h3>", false, false);

			if ( craftItem.UseAllRes )
				//AddHtmlLocalized( 170, 302 + (m_OtherCount++ * 20), 310, 18, 1048176, LabelColor, false, false ); // Makes as many as possible at once
                AddHtml(170, 302 + (m_OtherCount++ * 20), 300, 20, "<h3><basefont color=#FFFFFF><center>Fabriquer le plus possible</center><basefont></h3>", false, false);

			DrawItem();
			DrawSkill();
			DrawResource();

			/*
			if( craftItem.RequiresSE )
				AddHtmlLocalized( 170, 302 + (m_OtherCount++ * 20), 310, 18, 1063363, LabelColor, false, false ); //* Requires the "Samurai Empire" expansion
			 * */

			if( craftItem.RequiredExpansion != Expansion.None )
			{
				bool supportsEx = (from.NetState != null && from.NetState.SupportsExpansion( craftItem.RequiredExpansion ));
				TextDefinition.AddHtmlText( this, 170, 302 + (m_OtherCount++ * 20), 310, 18, RequiredExpansionMessage( craftItem.RequiredExpansion ), false, false, supportsEx ? LabelColor : RedLabelColor, supportsEx ? LabelHue : RedLabelHue );
			}

			if( needsRecipe )
				//AddHtmlLocalized( 170, 302 + (m_OtherCount++ * 20), 310, 18, 1073620, RedLabelColor, false, false ); // You have not learned this recipe.
                AddHtml(170, 302 + (m_OtherCount++ * 20), 300, 20, "<h3><basefont color=#FFFFFF><center>Vous n'avez pas la recette</center><basefont></h3>", false, false);
		}

		private TextDefinition RequiredExpansionMessage( Expansion expansion )
		{
			switch( expansion )
			{
				case Expansion.SE:
					return 1063363; // * Requires the "Samurai Empire" expansion
				case Expansion.ML:
					return 1072651; // * Requires the "Mondain's Legacy" expansion
				default:
					return String.Format( "* Requires the \"{0}\" expansion", ExpansionInfo.GetInfo( expansion ).Name );
			}
		}

		private bool m_ShowExceptionalChance;

		public void DrawItem()
		{
            try
            {
			    Type type = m_CraftItem.ItemType;

                Item item = (Item)Activator.CreateInstance(m_CraftItem.ItemType);

                if (item is BaseWeapon)
                {
                    BaseWeapon weapon = (BaseWeapon)item;

                    AddHtml(170, 302 + (m_OtherCount++ * 20), 300, 20, "<h3><basefont color=#FFFFFF><center>Niveau d'Attirail : " + weapon.NiveauAttirail.ToString() + "</center><basefont></h3>", false, false);
                }

                if (item is BaseArmor)
                {
                    string nameEnd = String.Empty;
                    Type typeRes = null;
                    string nameString = String.Empty;
                    int nameNumber = 0;

                    CraftContext context = m_CraftSystem.GetContext(m_From);

                    CraftSubResCol res = (m_CraftItem.UseSubRes2 ? m_CraftSystem.CraftSubRes2 : m_CraftSystem.CraftSubRes);
                    int resIndex = -1;

                    if (context != null)
                        resIndex = (m_CraftItem.UseSubRes2 ? context.LastResourceIndex2 : context.LastResourceIndex);

                    for (int i = 0; i < m_CraftItem.Resources.Count; i++)
                    {
                        CraftRes craftResource = m_CraftItem.Resources.GetAt(i);

                        typeRes = craftResource.ItemType;
                        nameString = craftResource.NameString;
                        nameNumber = craftResource.NameNumber;

                        if (typeRes == res.ResType && resIndex > -1)
                        {
                            CraftSubRes subResource = res.GetAt(resIndex);

                            typeRes = subResource.ItemType;

                            nameString = subResource.NameString;
                            nameNumber = subResource.GenericNameNumber;

                            if (nameNumber <= 0)
                                nameNumber = subResource.NameNumber;
                        }

                        if ((craftResource.ItemType.ToString() == "Server.Items.Leather" || craftResource.ItemType.ToString() == "Server.Items.Bone") && nameEnd == String.Empty)
                        {
                            nameEnd = nameString;
                        }

                        //Console.WriteLine(craftResource.ItemType.ToString());
                        //Console.WriteLine(nameString.ToString());
                    }

                    BaseArmor armor = (BaseArmor)item;
                    int req = armor.NiveauAttirail;

                    if (armor.MaterialType == ArmorMaterialType.Bone)
                    {
                        switch (nameEnd)
                        {
                            case "Os":
                            case "Os Reptilien":
                                req = 1;
                                break;
                            case "Os Nordique":
                            case "Os Désertique":
                                req = 2;
                                break;
                            case "Os Maritime":
                            case "Os Volcanique":
                                req = 3;
                                break;
                            case "Os Géant":
                            case "Os Minotaure":
                            case "Os Ophidien":
                            case "Os Arachnide":
                                req = 4;
                                break;
                            case "Os Magique":
                            case "Os Ancien":
                            case "Os Demoniaque":
                            case "Os Dragonique":
                                req = 5;
                                break;
                            case "Os Balron":
                            case "Os Wyrmique":
                                req = 6;
                                break;
                        }
                    }
                    /*else if (armor.MaterialType == ArmorMaterialType.Leather || armor.MaterialType == ArmorMaterialType.Studded)
                    {
                        switch (nameEnd)
                        {
                            case "Cuir":
                            case "Cuir Reptilien":
                                req = 1;
                                break;
                            case "Cuir Nordique":
                            case "Cuir Désertique":
                                req = 2;
                                break;
                            case "Cuir Maritime":
                            case "Cuir Volcanique":
                                req = 3;
                                break;
                            case "Cuir Géant":
                            case "Cuir Minotaure":
                            case "Cuir Ophidien":
                            case "Cuir Arachnide":
                                req = 4;
                                break;
                            case "Cuir Magique":
                            case "Cuir Ancien":
                            case "Cuir Demoniaque":
                            case "Cuir Dragonique":
                                req = 5;
                                break;
                            case "Cuir Lupus":
                                req = 6;
                                break;
                        }
                    }*/

                    AddHtml(170, 302 + (m_OtherCount++ * 20), 300, 20, "<h3><basefont color=#FFFFFF><center>Niveau d'Attirail : " + req.ToString() + "</center><basefont></h3>", false, false);
                }


			    AddItem( 20, 50, CraftItem.ItemIDOf( type ) );

			    if ( m_CraftItem.IsMarkable( type ) )
			    {
                    AddHtml(170, 302 + (m_OtherCount++ * 20), 300, 20, "<h3><basefont color=#FFFFFF><center>Cet objet prendra la marque de son createur.</center><basefont></h3>", false, false);
				    //AddHtmlLocalized( 170, 302 + (m_OtherCount++ * 20), 310, 18, 1044059, LabelColor, false, false ); // This item may hold its maker's mark
				    m_ShowExceptionalChance = true;
			    }
                item.Delete();
            }
            catch (Exception e)
            {
                Misc.ExceptionLogging.WriteLine(e);
            }
		}

		public void DrawSkill()
		{
            CraftSubResCol res = (m_CraftItem.UseSubRes2 ? m_CraftSystem.CraftSubRes2 : m_CraftSystem.CraftSubRes);
            int resIndex = -1;

			for ( int i = 0; i < m_CraftItem.Skills.Count; i++ )
			{
				CraftSkill skill = m_CraftItem.Skills.GetAt( i );
				//double minSkill = skill.MinSkill, maxSkill = skill.MaxSkill;
                double minSkill = AdjustSkill(skill.MinSkill, m_From);
                double maxSkill = AdjustSkill(skill.MaxSkill, m_From);

				if ( minSkill < 0 )
					minSkill = 0;

                AddHtml(170, 132 + (i * 20), 300, 20, "<h3><basefont color=#FFFFFF>" + skill.SkillToMake.ToString() +  "<basefont></h3>", false, false);
                AddHtml(480, 132 + (i * 20), 300, 20, "<h3><basefont color=#FFFFFF>" + Convert.ToInt32(minSkill) + "%<basefont></h3>", false, false);
				//AddHtmlLocalized( 170, 132 + (i * 20), 200, 18, 1044060 + (int)skill.SkillToMake, LabelColor, false, false );
				//AddLabel( 430, 132 + (i * 20), LabelHue, String.Format( "{0:F1}", minSkill ) );
			}

			CraftContext context = m_CraftSystem.GetContext( m_From );

			if ( context != null )
				resIndex = ( m_CraftItem.UseSubRes2 ? context.LastResourceIndex2 : context.LastResourceIndex );

			bool allRequiredSkills = true;
            bool allRequiredAptitudes = true;
			double chance = m_CraftItem.GetSuccessChance( m_From, resIndex > -1 ? res.GetAt( resIndex ).ItemType : null, m_CraftSystem, false, ref allRequiredSkills, ref allRequiredAptitudes );
			double excepChance = m_CraftItem.GetExceptionalChance( m_CraftSystem, chance, m_From );

            if (!(allRequiredAptitudes))
                AddHtml(170, 302 + (m_OtherCount++ * 20), 300, 20, "<h3><basefont color=#FFFFFF>Vous n'avez pas l'aptitude nécessaire.<basefont></h3>", false, false);

			if ( chance < 0.0 )
				chance = 0.0;
			else if ( chance > 1.0 )
				chance = 1.0;
            try
            {
                int chan = Convert.ToInt32(chance * 100);

                AddHtml(170, 80, 300, 20, "<h3><basefont color=#FFFFFF>Chance de Succès :<basefont></h3>", false, false);
                AddHtml(480, 80, 300, 20, "<h3><basefont color=#FFFFFF>" + chan.ToString() + "%<basefont></h3>", false, false);
                //AddHtmlLocalized( 170, 80, 250, 18, 1044057, LabelColor, false, false ); // Success Chance:
                //AddLabel( 430, 80, LabelHue, String.Format( "{0:F1}%", chance * 100 ) );
            }
            catch (OverflowException e)
            {
                Misc.ExceptionLogging.WriteLine(e, "La valeur convertie en int était {0}. L'item était {1}",
                    chance * 100, m_CraftItem.ItemType.ToString());
   
            }

			if ( m_ShowExceptionalChance )
			{
				if( excepChance < 0.0 )
					excepChance = 0.0;
				else if( excepChance > 1.0 )
					excepChance = 1.0;
                try
                {
                    int exept = Convert.ToInt32(excepChance * 100);

                    AddHtml(170, 100, 300, 20, "<h3><basefont color=#FFFFFF>Chance d'Object Exceptionel:<basefont></h3>", false, false);
                    AddHtml(480, 100, 300, 20, "<h3><basefont color=#FFFFFF>" + exept.ToString() + "%<basefont></h3>", false, false);
                    //AddHtmlLocalized( 170, 100, 250, 18, 1044058, 32767, false, false ); // Exceptional Chance:
                    //AddLabel( 430, 100, LabelHue, String.Format( "{0:F1}%", excepChance * 100 ) );
                }
                catch (OverflowException e)
                {
                    Misc.ExceptionLogging.WriteLine(e, "La valeur convertie en int était {0}. L'item était {1}", 
                        excepChance * 100, m_CraftItem.ItemType.ToString());
                }
			}
		}

		private static Type typeofBlankScroll = typeof( BlankScroll );
		private static Type typeofSpellScroll = typeof( SpellScroll );

		public void DrawResource()
		{
			bool retainedColor = false;

			CraftContext context = m_CraftSystem.GetContext( m_From );

			CraftSubResCol res = ( m_CraftItem.UseSubRes2 ? m_CraftSystem.CraftSubRes2 : m_CraftSystem.CraftSubRes );
			int resIndex = -1;

			if ( context != null )
				resIndex = ( m_CraftItem.UseSubRes2 ? context.LastResourceIndex2 : context.LastResourceIndex );

			bool cropScroll = ( m_CraftItem.Resources.Count > 1 )
				&& m_CraftItem.Resources.GetAt( m_CraftItem.Resources.Count - 1 ).ItemType == typeofBlankScroll
				&& typeofSpellScroll.IsAssignableFrom( m_CraftItem.ItemType );

			for ( int i = 0; i < m_CraftItem.Resources.Count - (cropScroll ? 1 : 0) && i < 4; i++ )
			{
				Type type;
				string nameString;
				int nameNumber;

				CraftRes craftResource = m_CraftItem.Resources.GetAt( i );

				type = craftResource.ItemType;
				nameString = craftResource.NameString;
				nameNumber = craftResource.NameNumber;
				
				// Resource Mutation
				if ( type == res.ResType && resIndex > -1 )
				{
					CraftSubRes subResource = res.GetAt( resIndex );

					type = subResource.ItemType;

					nameString = subResource.NameString;
					nameNumber = subResource.GenericNameNumber;

					if ( nameNumber <= 0 )
						nameNumber = subResource.NameNumber;
				}
				// ******************

				if ( !retainedColor && m_CraftItem.RetainsColorFrom( m_CraftSystem, type ) )
				{
					retainedColor = true;
                    AddHtml(170, 302 + (m_OtherCount++ * 20), 300, 20, "<h3><basefont color=#FFFFFF>*  L'objet retient la couleur de ce matériel<basefont></h3>", false, false);
                    AddHtml(500, 219 + (i * 20), 20, 20, "<h3><basefont color=#FFFFFF>*<basefont></h3>", false, false);
                    //AddHtmlLocalized( 170, 302 + (m_OtherCount++ * 20), 310, 18, 1044152, LabelColor, false, false ); // * The item retains the color of this material
					//AddLabel( 500, 219 + (i * 20), LabelHue, "*" );
				}

				if ( nameNumber > 0 )
					AddHtmlLocalized( 170, 219 + (i * 20), 310, 18, nameNumber, LabelColor, false, false );
				else
					//AddLabel( 170, 219 + (i * 20), LabelHue, nameString );
                    AddHtml(170, 219 + (i * 20), 300, 20, "<h3><basefont color=#FFFFFF>" + nameString + "<basefont></h3>", false, false);

                AddHtml(480, 219 + (i * 20), 300, 20, "<h3><basefont color=#FFFFFF>" + craftResource.Amount.ToString() + "<basefont></h3>", false, false);
				//AddLabel( 430, 219 + (i * 20), LabelHue, craftResource.Amount.ToString() );
			}

			if ( m_CraftItem.NameNumber == 1041267 ) // runebook
			{
				AddHtmlLocalized( 170, 219 + (m_CraftItem.Resources.Count * 20), 310, 18, 1044447, LabelColor, false, false );
				AddLabel( 430, 219 + (m_CraftItem.Resources.Count * 20), LabelHue, "1" );
			}

			if ( cropScroll )
                AddHtml(170, 302 + (m_OtherCount++ * 20), 300, 20, "<h3><basefont color=#FFFFFF>Les parchemins magiques nécessitent de la mana et un parchemin vierge.<basefont></h3>", false, false);
				//AddHtmlLocalized( 170, 302 + (m_OtherCount++ * 20), 360, 18, 1044379, LabelColor, false, false ); // Inscribing scrolls also requires a blank scroll and mana.
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			// Back Button
			if ( info.ButtonID == 0 )
			{
				CraftGump craftGump = new CraftGump( m_From, m_CraftSystem, m_Tool, null );
				m_From.SendGump( craftGump );
			}
			else // Make Button
			{
				int num = m_CraftSystem.CanCraft( m_From, m_Tool, m_CraftItem.ItemType );

				if ( num > 0 )
				{
					m_From.SendGump( new CraftGump( m_From, m_CraftSystem, m_Tool, num ) );
				}
				else
				{
					Type type = null;

					CraftContext context = m_CraftSystem.GetContext( m_From );

					if ( context != null )
					{
						CraftSubResCol res = ( m_CraftItem.UseSubRes2 ? m_CraftSystem.CraftSubRes2 : m_CraftSystem.CraftSubRes );
						int resIndex = ( m_CraftItem.UseSubRes2 ? context.LastResourceIndex2 : context.LastResourceIndex );

						if ( resIndex > -1 )
							type = res.GetAt( resIndex ).ItemType;
					}

					m_CraftSystem.CreateItem( m_From, m_CraftItem.ItemType, type, m_Tool, m_CraftItem );
				}
			}
		}

        private static Type[] m_UseLeathers = new Type[]
			{
				typeof(FemaleLeatherChest),
				typeof(LeatherArms),
				typeof(LeatherBustierArms),
				typeof(LeatherCap),
				typeof(LeatherChest),
				typeof(LeatherGloves),
				typeof(LeatherGorget),
				typeof(LeatherLegs),
				typeof(LeatherShorts),
				typeof(LeatherSkirt),

				typeof(FemaleStuddedChest),
				typeof(StuddedArms),
				typeof(StuddedBustierArms),
				typeof(StuddedChest),
				typeof(StuddedGloves),
				typeof(StuddedGorget),
				typeof(StuddedLegs),

                typeof(LeatherBarbareLeggings),
                typeof(LeatherBarbareTunic),
                typeof(RoublardLeggings),
                typeof(RoublardTunic),
                typeof(ElfiqueCuirTunic),
                typeof(ElfiqueCuirRobe),
                
                typeof(ElfeHelm),
                typeof(ElfeGorget),
                typeof(ElfeArms),
                typeof(ElfeLeggings),
                typeof(ElfeTunic),
                typeof(StuddedBarbareGreaves),
                typeof(StuddedBarbareGorget),
                typeof(StuddedBarbareLeggings),
                typeof(StuddedBarbareTunic)
			};

        private static Type[] m_UseBones = new Type[]
			{
				typeof(BoneArms),
				typeof(BoneChest),
				typeof(BoneGloves),
				typeof(BoneHelm),
				typeof(BoneLegs)
			};

        private static Type[] m_UseIngots = new Type[]
			{
				typeof(RingmailArms),
				typeof(RingmailChest),
				typeof(RingmailGloves),
				typeof(RingmailLegs),

				typeof(ChainChest),
				typeof(ChainLegs),

				typeof(FemalePlateChest),
				typeof(PlateArms),
				typeof(PlateChest),
				typeof(PlateGloves),
				typeof(PlateGorget),
				typeof(PlateLegs),

				typeof(Bascinet),
				typeof(ChainCoif),
				typeof(CloseHelm),
				typeof(Helmet),
				typeof(NorseHelm),
				typeof(PlateHelm),

                typeof(DrowHelm),
                typeof(DrowGorget),
                typeof(DrowArms),
                typeof(DrowLeggings),
                typeof(DrowTunic),

                typeof(BourgeonLeggings),
                typeof(BourgeonGreaves),
                typeof(BourgeonTunic),
                
                typeof(MaillonsLeggings),
                typeof(MaillonsGreaves),
                typeof(MaillonsTunic),

                typeof(MailluresLeggings),
                typeof(MailluresGreaves),
                typeof(MailluresTunic),

                typeof(ElfiqueChaineLeggings),
                typeof(ElfiqueChaineTunic),

                typeof(MaillesHelm),
                typeof(MaillesLeggings),
                typeof(MaillesTunic),

                typeof(ElfiquePlaqueGorget),
                typeof(ElfiquePlaqueLeggings),
                typeof(ElfiquePlaqueTunic),

                typeof(BrassardsGothique),
                typeof(CuirasseGothique),
                typeof(CasqueGothique),

                typeof(PlaqueBarbareGreaves),
                typeof(PlaqueBarbareGorget),
                typeof(PlaqueBarbareLeggings),
                typeof(PlaqueBarbareTunic),

                typeof(BrassardsOrne),
                typeof(CuirasseOrne),

                typeof(BrassardsDecorer),
                typeof(GantsDecorer),
                typeof(GorgetDecorer),
                typeof(JambieresDecorer),
                typeof(CuirasseDecorer),
                typeof(CasqueDecorer),
                typeof(CasqueClosDecorer),

                typeof(PlaqueChevalierGreaves),
                typeof(PlaqueChevalierGloves),
                typeof(PlaqueChevalierGorget),
                typeof(PlaqueChevalierLeggings),
                typeof(PlaqueChevalierTunic),
                typeof(PlaqueChevalierHelm),

                typeof(ArmureDaedricGreaves),
                typeof(ArmureDaedricGloves),
                typeof(ArmureDaedricGorget),
                typeof(ArmureDaedricLeggings),
                typeof(ArmureDaedricTunic),
                typeof(ArmureDaedricHelm),

                typeof(LeggingsBarbare),
                typeof(TunicBarbare),

                typeof(TuniqueChaine),
                typeof(CuirasseReligieuse),
                typeof(Cuirasse),
                typeof(CuirasseBarbare),
                typeof(CuirasseNordique),
                typeof(CuirasseDraconique),
                typeof(CasqueNordique),
                typeof(CasqueSudiste),
                typeof(CasqueCorne),
                typeof(Brassards),
                typeof(BrassardsChaotique),

                typeof(Buckler),
                typeof(BronzeShield),
                typeof(MetalShield),
                typeof(WoodenKiteShield),
                typeof(BouclierGarde),
                typeof(MetalKiteShield),
                typeof(ChaosShield),
                typeof(OrderShield),
                typeof(BouclierComte),
                typeof(BouclierMarquis),
                typeof(BouclierDuc),
                typeof(BouclierNordique),
                typeof(BouclierElfique),
                typeof(BouclierChevaleresque),
                typeof(BouclierVieux),
                typeof(HeaterShield),
                typeof(BouclierDecorer),
                typeof(BouclierPavoisNoir)
			};

        private static Type[] m_UseIngotsJewels = new Type[]
			{
				//typeof(Ring),
				typeof(Necklace),
				//typeof(Bracelet),
				//typeof(Earrings),
			};
        //PAREIL DANS CRAFTITEM
        public double AdjustSkill(double skill, Mobile from)
        {
            CraftSubResCol res = m_CraftSystem.CraftSubRes;
            CraftContext context = m_CraftSystem.GetContext(from);
            Type ItemType = m_CraftItem.ItemType;
            int resIndex = (context == null ? -1 : context.LastResourceIndex);
            string name = "";

            if (resIndex > -1)
            {
                CraftSubRes subResource = res.GetAt(resIndex);

                name = subResource.ItemType.Name;
            }

            bool contains = false;

            for (int i = 0; !contains && i < m_UseLeathers.Length; ++i)
                contains = (ItemType == m_UseLeathers[i]);

            if (contains)
            {
                switch (name)
                {
                    case "ReptilienLeather": skill += 5.0; break;
                    case "NordiqueLeather": skill += 10.0; break;
                    case "LupusLeather": skill += 15.0; break;
                    case "GeantLeather": skill += 20.0; break;
                    case "MaritimeLeather": skill += 20.0; break;
                    case "PierreLeather": skill += 25.0; break;
                    case "TerathanLeather": skill += 30.0; break;
                    case "OphidianLeather": skill += 35.0; break;
                    case "GargouillienLeather": skill += 40.0; break;
                    case "RautourLeather": skill += 45.0; break;
                    case "DraconiqueLeather": skill += 50.0; break;
                    case "DemoniaqueLeather": skill += 50.0; break;
                }

                return skill;
            }

            contains = false;

            for (int i = 0; !contains && i < m_UseBones.Length; ++i)
                contains = (ItemType == m_UseBones[i]);

            if (contains)
            {
                switch (name)
                {
                    case "MorcithBone": skill += 15.0; break;
                    case "ReptilienBone": skill += 15.0; break;
                    case "NordiqueBone": skill += 20.0; break;
                    case "DesertiqueBone": skill += 20.0; break;
                    case "VolcaniqueBone": skill += 30.0; break;
                    case "GeantBone": skill += 30.0; break;
                    case "MaritimeBone": skill += 40.0; break;
                    case "CentiriusBone": skill += 40.0; break;
                    case "DragonBone": skill += 45.0; break;
                    case "DemonBone": skill += 45.0; break;
                    case "AncienneBone": skill += 50.0; break;
                }

                return skill;
            }

            contains = false;

            for (int i = 0; !contains && i < m_UseIngots.Length; ++i)
                contains = (ItemType == m_UseIngots[i]);

            if (contains)
            {
                switch (name)
                {
                    case "CuivreIngot": skill += 5.0; break;
                    case "BronzeIngot": skill += 5.0; break;
                    case "AcierIngot": skill += 10.0; break;
                    case "ArgentIngot": skill += 10.0; break;
                    case "OrIngot": skill += 10.0; break;
                    case "MytherilIngot": skill += 15.0; break;
                    case "LuminiumIngot": skill += 15.0; break;
                    case "ObscuriumIngot": skill += 15.0; break;
                    case "MystiriumIngot": skill += 20.0; break;
                    case "DominiumIngot": skill += 20.0; break;
                    case "EclariumIngot": skill += 25.0; break;
                    case "VenariumIngot": skill += 20.0; break;
                    case "AtheniumIngot": skill += 25.0; break;
                    case "UmbrariumIngot": skill += 25.0; break;
                }

                return skill;
            }

            contains = false;

            for (int i = 0; !contains && i < m_UseIngotsJewels.Length; ++i)
                contains = (ItemType == m_UseIngotsJewels[i]);

            if (contains)
            {
                switch (name)
                {
                    case "ArgentIngot": skill += 10.0; break;
                    case "GoldIngot": skill += 20.0; break;
                }

                return skill;
            }

            return skill;
        }
	}
}