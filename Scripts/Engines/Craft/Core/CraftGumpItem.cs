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

			if ( craftSystem.GumpTitleNumber > 0 )
				AddHtmlLocalized( 10, 12, 510, 20, craftSystem.GumpTitleNumber, LabelColor, false, false );
			else
                AddHtml(10, 12, 510, 20, "<h3><basefont color=#FFFFFF><center>" + craftSystem.GumpTitleString + "</center><basefont></h3>", false, false);

			AddButton( 15, 387, 4014, 4016, 0, GumpButtonType.Reply, 0 );
            AddHtml(50, 390, 150, 20, "<h3><basefont color=#FFFFFF>Retour<basefont></h3>", false, false);

			bool needsRecipe = ( craftItem.Recipe != null && from is PlayerMobile && !((PlayerMobile)from).HasRecipe( craftItem.Recipe ) );

			if( needsRecipe )
			{
				AddButton( 270, 387, 4005, 4007, 0, GumpButtonType.Page, 0 );
                AddHtml(305, 390, 150, 20, "<h3><basefont color=#FFFFFF>Fabriquer<basefont></h3>", false, false);
			}
			else
			{
				AddButton( 270, 387, 4005, 4007, 1, GumpButtonType.Reply, 0 );
                AddHtml(305, 390, 150, 20, "<h3><basefont color=#FFFFFF>Fabriquer<basefont></h3>", false, false);
			}

			if ( craftItem.NameNumber > 0 )
				AddHtmlLocalized( 330, 40, 180, 18, craftItem.NameNumber, LabelColor, false, false );
			else
                AddHtml(330, 40, 150, 20, "<h3><basefont color=#FFFFFF><center>" + craftItem.NameString + "</center><basefont></h3>", false, false);

			if ( craftItem.UseAllRes )
                AddHtml(170, 302 + (m_OtherCount++ * 20), 300, 20, "<h3><basefont color=#FFFFFF><center>Fabriquer le plus possible</center><basefont></h3>", false, false);

			DrawItem();
			DrawSkill();
			DrawResource();

			if( needsRecipe )
				//AddHtmlLocalized( 170, 302 + (m_OtherCount++ * 20), 310, 18, 1073620, RedLabelColor, false, false ); // You have not learned this recipe.
                AddHtml(170, 302 + (m_OtherCount++ * 20), 300, 20, "<h3><basefont color=#FFFFFF><center>Vous n'avez pas la recette</center><basefont></h3>", false, false);
		}

		public void DrawItem()
		{
            try
            {
			    Type type = m_CraftItem.ItemType;

			    AddItem( 20, 50, CraftItem.ItemIDOf( type ) );

			    if ( m_CraftItem.IsMarkable( type ) )
			    {
                    AddHtml(170, 302 + (m_OtherCount++ * 20), 300, 20, "<h3><basefont color=#FFFFFF><center>Cet objet prendra la marque de son createur.</center><basefont></h3>", false, false);
			    }
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
                double minSkill = m_CraftItem.ScaleWithRessource(skill.MinSkill, m_From, m_CraftSystem);

				if ( minSkill < 0 )
					minSkill = 0;

                AddHtml(170, 132 + (i * 20), 300, 20, "<h3><basefont color=#FFFFFF>" + skill.SkillToMake.ToString() +  "<basefont></h3>", false, false);
                AddHtml(480, 132 + (i * 20), 300, 20, "<h3><basefont color=#FFFFFF>" + Convert.ToInt32(minSkill) + "%<basefont></h3>", false, false);
			}

			CraftContext context = m_CraftSystem.GetContext( m_From );

			if ( context != null )
				resIndex = ( m_CraftItem.UseSubRes2 ? context.LastResourceIndex2 : context.LastResourceIndex );

			bool allRequiredSkills = true;
			double chance = m_CraftItem.GetSuccessChance( m_From, resIndex > -1 ? res.GetAt( resIndex ).ItemType : null, m_CraftSystem, false, ref allRequiredSkills );
			double excepChance = m_CraftItem.GetExceptionalChance( chance, m_From );

			if ( chance < 0.0 )
				chance = 0.0;
			else if ( chance > 1.0 )
				chance = 1.0;
            try
            {
                int chan = Convert.ToInt32(chance * 100);

                AddHtml(170, 80, 300, 20, "<h3><basefont color=#FFFFFF>Chance de Succès :<basefont></h3>", false, false);
                AddHtml(480, 80, 300, 20, "<h3><basefont color=#FFFFFF>" + chan.ToString() + "%<basefont></h3>", false, false);
            }
            catch (OverflowException e)
            {
                Misc.ExceptionLogging.WriteLine(e, "La valeur convertie en int était {0} * 100. L'item était {1}",
                    chance, m_CraftItem.ItemType.ToString());
   
            }

			if( excepChance < 0.0 )
				excepChance = 0.0;
			else if( excepChance > 1.0 )
				excepChance = 1.0;
            try
            {
                int exept = Convert.ToInt32(excepChance * 100);

                AddHtml(170, 100, 300, 20, "<h3><basefont color=#FFFFFF>Chance d'Objet Exceptionel:<basefont></h3>", false, false);
                AddHtml(480, 100, 300, 20, "<h3><basefont color=#FFFFFF>" + exept.ToString() + "%<basefont></h3>", false, false);
            }
            catch (OverflowException e)
            {
                Misc.ExceptionLogging.WriteLine(e, "La valeur convertie en int était {0} * 100. The original chance value was : {1}. L'item était {2}",
                    excepChance, chance, m_CraftItem.ItemType.ToString());
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
	}
}