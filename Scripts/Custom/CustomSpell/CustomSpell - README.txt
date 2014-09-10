
La classe CSpell a pour but d'éviter la répétition présente dans les spells, et de faciliter 
l'intégration de nouveaux spells. Elle est une interface entre la classe Spell de base de UO, 
et nos spells maisons. La classe CSpell contient plusieurs spécialisations/catégories, qui 
regroupent les executions d'une sorte de spell.


Ex : Je veux faire un sort de genre boule de glace, qui fait 10 de dégâts. C'est un sort qui 
nécessite un target, donc je crée un nouveau CTargettedSpell, auquel j'envoie les paramètres 
(Un SpellInfo du bon namespace) ainsi que la fonction.


EXEMPLE :

// BouleDeGlace.cs
class BouleDeGlace : CTargettedSpell
{
	const public InfoTargettedSpell info = InfoTargettedSpell(

	"Boule de Glace", "Kal Vas Ayss",
	SpellCircle.Fifth,
	218,
	9002,
	50,
	SkillName.ArtMagique,
	40,
	1,            // 1 seconde de temps de cast.
	Reagent.Garlic,
	Reagent.MandrakeRoot,
	Reagent.SulfurousAsh );


	public override Effect( Mobile caster, Mobile target )
	{
		if ( SkillUtilise.level > NiveauSkillReq ) //Admettons..
		{
			target.hitsPoints -= 10;
		}
	}
}

// SpellBook.cs , ou whatever.

int UtilisationExemple()
{
	Mobile caster = new Mobile();
	Mobile target = new Mobile();

	// Plus tard, quand on clicke sur le spell dans un livre, par exemple.
	BouleDeGlace.cast(caster, target);
}


 
////// La classe CTargettedSpell gère donc :

      - Le temps de cast.
      - Le coût de mana.
      - Le range, etc...
      - Création d'un target.
      - Réaction au click.
      - L'execution de la commande passée en paramètre.

	En se servant des paramètres présent dans InfoTargettedSpell. 
	
	Si par exemple on aurait utilisé un CSpellAoE, la class CSpell serait allée chercher l'override 
	de la fonction UseAoESpell à la place de UseTargettedSpell dans la classe qui dérive, et aurait 
	appliquée l'effet du UseAoESpell sur tous les personnages dans un rayon de X.
 