using Server.Spells;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Transformations
{
    [PropertyObject]
    public class Transformation
    {
        Mobile mobile;

        public ArrayList m_MetamorphoseList = new ArrayList();
        public static Hashtable m_SpellTransformation = new Hashtable();
        public static Hashtable m_SpellName = new Hashtable();
        public static Hashtable m_SpellHue = new Hashtable();

        [CommandProperty(AccessLevel.Batisseur)]		
        public bool MetamorphoseMod		
        {		
            get { return !mobile.CanBeginAction(typeof(MetamorphoseSpell)); }		
        }		
		
        public ArrayList MetamorphoseList		
        {		
            get { return m_MetamorphoseList; }		
            set { m_MetamorphoseList = value; }		
        }

        public Transformation(Mobile m)
        {
            mobile = m;
        }

        public void DispelAllTransformations()
        {
            AlterationSpell.StopTimer(mobile);
            SubterfugeSpell.StopTimer(mobile);
            TransmutationSpell.StopTimer(mobile);
            ChimereSpell.StopTimer(mobile);
            MutationSpell.StopTimer(mobile);
            MetamorphoseSpell.StopTimer(mobile);
            OmbreSpell.StopTimer(mobile);
            InstinctCharnelSpell.StopTimer(mobile);
        }

        public void OnTransformationChange(int body, string name, int hue, bool spell)
        {
            if (spell)
            {
                if (body == 0 && name == null && hue == -1)
                {
                    m_SpellTransformation.Remove(mobile);
                    m_SpellName.Remove(mobile);
                    m_SpellHue.Remove(mobile);
                }
                else
                {
                    m_SpellTransformation[mobile] = body;
                    m_SpellName[mobile] = name;
                    m_SpellHue[mobile] = hue;
                }
            }

            OnBodyChange(body);
            OnNameChange(name);
            OnHueChange(hue);
        }

        public void OnHueChange(int hue)
        {
            if (hue != -1)
            {
                mobile.HueMod = hue;
                return;
            }
            else if (m_SpellTransformation.Contains(this))
            {
                mobile.HueMod = (int)m_SpellHue[this];
                return;
            }
            /*else if (m_DeguisementInfos != null && m_DeguisementInfos.Hue != -1)
            {
                HueMod = m_DeguisementInfos.Hue;
                return;
            }*/
            else
            {
                mobile.HueMod = -1;
                return;
            }
        }

        public void OnBodyChange(int body)
        {
            if (body != 0)
            {
                mobile.BodyMod = body;
                mobile.Delta(MobileDelta.Body);
                return;
            }
            else if (m_SpellTransformation.Contains(this))
            {
                mobile.BodyMod = (int)m_SpellTransformation[this];
                mobile.Delta(MobileDelta.Body);
                return;
            }
            /*else if (m_DeguisementInfos != null && m_DeguisementInfos.Body != 0)
            {
                BodyMod = m_DeguisementInfos.Body;
                Delta(MobileDelta.Body);
                return;
            }*/
            else
            {
                mobile.BodyMod = 0;
                mobile.Delta(MobileDelta.Body);
                return;
            }
        }

        public void OnNameChange(string name)
        {
            if (name != null)
            {
                mobile.NameMod = name;
                mobile.InvalidateProperties();
                return;
            }
            else if (m_SpellName.Contains(this))
            {
                mobile.NameMod = (string)m_SpellName[this];
                mobile.InvalidateProperties();
                return;
            }
            /*else if (m_DeguisementInfos != null && m_DeguisementInfos.Name != null)
            {
                NameMod = m_DeguisementInfos.Name;
                InvalidateProperties();
                return;
            }*/
            else
            {
                mobile.NameMod = null;
                mobile.InvalidateProperties();
                return;
            }
        }

    }
}
