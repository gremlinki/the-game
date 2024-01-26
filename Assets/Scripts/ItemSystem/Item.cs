using UnityEngine;

namespace ItemSystem
{
    public enum ItemGroup_e
    {
        KING,
        ROYALTY
    }
    
    public class CItem
    {
        public CItem(string szName, string szDescription, ItemGroup_e eItemGroup, int nFunFactor,
            int nOffensiveFactor, int nSelfDepravation)
        {
            m_szName = szName;
            m_szDescription = szDescription;
            m_nFunFactor = nFunFactor;
            m_nOffensiveFactor = nOffensiveFactor;
            m_nSelfDepravation = nSelfDepravation;
        }

        /// <summary>
        /// Create an item with provided name and description
        /// </summary>
        /// <param name="szName">Name of the item</param>
        /// <param name="szDescription">Description of the item</param>
        /// <returns></returns>
        public static CItem item(string szName, string szDescription, ItemGroup_e eGroup)
        {
            return new CItem(szName, szDescription, eGroup, 0, 0, 0);
        }
        
        public string name()
        {
            return m_szName;
        }

        public string description()
        {
            return m_szDescription;
        }

        public int funFactor()
        {
            return m_nFunFactor;
        }

        public int offensiveFactor()
        {
            return m_nOffensiveFactor;
        }

        public int selfDepravation()
        {
            return m_nSelfDepravation;
        }

        public ItemGroup_e group()
        {
            return m_eGroup;
        }

        private string m_szName, m_szDescription;
        private int m_nFunFactor, m_nOffensiveFactor, m_nSelfDepravation;
        private ItemGroup_e m_eGroup;
    }
}