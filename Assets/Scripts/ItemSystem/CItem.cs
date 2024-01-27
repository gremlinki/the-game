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
    
    [Serializable]
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
        public CItem(ItemGroup_e eItemGroup, int nFunFactor,
            int nOffensiveFactor, int nSelfDepravation)
        {
            m_pItemDef = GameManager.instance.ItemManager.getRandomItem();
            m_nFunFactor = nFunFactor;
            m_nOffensiveFactor = nOffensiveFactor;
            m_nSelfDepravation = nSelfDepravation;
            m_eGroup = eItemGroup;
        }

        public CItem(ItemDefinition def, ItemGroup_e eItemGroup, int nFunFactor,
            int nOffensiveFactor, int nSelfDepravation)
        {
            m_pItemDef = def;
            m_nFunFactor = nFunFactor;
            m_nOffensiveFactor = nOffensiveFactor;
            m_nSelfDepravation = nSelfDepravation;
        }
        
        public CItem(CItem obj)
        {
            m_pItemDef = obj.m_pItemDef;
            m_pParent = obj.parent;
            m_nFunFactor = obj.funFactor;
            m_nOffensiveFactor = obj.offensiveFactor;
            m_nSelfDepravation = obj.selfDepravation;
            m_eGroup = obj.group;
        }
        
        public override string ToString()
        {
            return $"{name()} {description()} {group} {m_pItemDef.id}";
        }

        /// <summary>
        /// Creates a copy of an item GameObject and returns the item component
        /// </summary>
        /// <returns><see cref="CItem"/> component of the copied item</returns>
        public CItem copy()
        {
            return new CItem(this);
        }

        public Sprite icon()
        {
            return m_pItemDef.icon;
        }
        
        public string name()
        {
            return m_pItemDef.data.name;
        }

        public string description()
        {
            return m_pItemDef.data.description;
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

        public GameObject parent
        {
            get
            {
                return m_pParent;
            }

            set
            {
                m_pParent = value;
            }
        }

        private ItemDefinition m_pItemDef;
        private int m_nFunFactor, m_nOffensiveFactor, m_nSelfDepravation;
        private ItemGroup_e m_eGroup;
        private GameObject m_pParent;
    }
}