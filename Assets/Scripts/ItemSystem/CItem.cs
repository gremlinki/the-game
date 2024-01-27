using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ItemSystem
{
    public enum ItemGroup_e
    {
        KING,
        ROYALTY
    }
    
    [Flags]
    public enum ItemID_e
    {
        CARROT = 1 << 0,
        SHOVEL = 1 << 1,
        SWORD = 1 << 2,
        SHIELD = 1 << 3,
        COATOFARMS = 1 << 4,
        BEERMUG = 1 << 5,
        APPLE = 1 << 6,
        BOOK = 1 << 7,
        HAMMER = 1 << 8
    }

    public struct ItemDefinition_t
    {
        public string name;
        public string description;

        public ItemDefinition_t(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }

    public class CItem
    {
        private static readonly List<ItemDefinition_t> m_szNames = new List<ItemDefinition_t>()
        {
            new ItemDefinition_t("Carrot", "Great source of vitamins, indispensable part of snowman."),
            new ItemDefinition_t("Shovel", "Perfect tool to dig out some graves for your opponents."),
            new ItemDefinition_t("Sword", "Sometimes it's short, sometimes it's long, but always deadly. Ideal addition to your throne room."),
            new ItemDefinition_t("Shield", "Big, bulky, round object used mainly for defence. If you got hungry on the battlefield, you can use it as plate."),
            new ItemDefinition_t("Coat of Arms", "Colourfull, shiny shield that depicts the glory of Kingdom of Podolskho."),
            new ItemDefinition_t("Beer Mug", "Big wooden mug, full of delicious monk-made wheat beer."),
            new ItemDefinition_t("Apple", "Great for bow shooting competitions as a target, but it's main purpose is being delicious fruit with lots of sweetenes."),
            new ItemDefinition_t("Book", "Sheets of processed cellulose stuck in beetween two big sheets of cow's skin. Source of wisdom, sorcery and other kinds of wealthy's nobels whim."),
            new ItemDefinition_t("Hammer", "Construction tool, big toy for big boys. Main intend was to nail nails, but you can get absolute creative with this tool. Beware: Do not combine with sickle.")
        };
        
        public CItem(ItemGroup_e eItemGroup, int nFunFactor,
            int nOffensiveFactor, int nSelfDepravation)
        {
            ItemDefinition_t def = m_szNames[Random.Range(0, m_szNames.Count)];
            m_szName = def.name;
            m_szDescription = def.description;
            m_nFunFactor = nFunFactor;
            m_nOffensiveFactor = nOffensiveFactor;
            m_nSelfDepravation = nSelfDepravation;
            m_eGroup = eItemGroup;
        }

        public CItem(CItem obj)
        {
            m_szName = obj.name;
            m_szDescription = obj.description;
            m_nFunFactor = obj.funFactor;
            m_nOffensiveFactor = obj.offensiveFactor;
            m_nSelfDepravation = obj.selfDepravation;
            m_eGroup = obj.group;
        }

        /// <summary>
        /// Creates a copy of an item GameObject and returns the item component
        /// </summary>
        /// <returns><see cref="CItem"/> component of the copied item</returns>
        public CItem copy()
        {
            return new CItem(this);
        }
        
        public string name
        {
            get
            {
                return m_szName;
            }

            set
            {
                m_szName = value;
            }
        }

        public string description
        {
            get
            {
                return m_szDescription;
            }

            set
            {
                m_szDescription = value;
            }
        }

        public int funFactor
        {
            get
            {
                return m_nFunFactor;
            }

            set
            {
                m_nFunFactor = value;
            }
        }

        public int offensiveFactor
        {
            get
            {
                return m_nOffensiveFactor;
            }

            set
            {
                m_nOffensiveFactor = value;
            }
        }

        public int selfDepravation
        {
            get
            {
                return m_nSelfDepravation;
            }

            set
            {
                m_nSelfDepravation = value;
            }
        }

        public ItemGroup_e group
        {
            get
            {
                return m_eGroup;
            }

            set
            {
                m_eGroup = value;
            }
        }

        private string m_szName, m_szDescription;
        private int m_nFunFactor, m_nOffensiveFactor, m_nSelfDepravation;
        private ItemGroup_e m_eGroup;
    }
}