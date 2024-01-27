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
            new ItemDefinition_t("Carrot", ""),
            new ItemDefinition_t("Shovel", ""),
            new ItemDefinition_t("Sword", ""),
            new ItemDefinition_t("Shield", ""),
            new ItemDefinition_t("Coat of Arms", ""),
            new ItemDefinition_t("Beer Mug", ""),
            new ItemDefinition_t("Apple", ""),
            new ItemDefinition_t("Book", ""),
            new ItemDefinition_t("Hammer", "")
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