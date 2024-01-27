using UnityEngine;

namespace ItemSystem
{
    public enum ItemGroup_e
    {
        KING,
        ROYALTY
    }
    
    public class CItem : MonoBehaviour
    {
        private static readonly string[] m_szNames =
        {
            "Carrot",
            "Shovel",
            "Shield",
            "Coat of Arms",
            "Beer Mug",
            "Apple",
            "Book",
            "Hammer"
        };
        
        public CItem(string szDescription, ItemGroup_e eItemGroup, int nFunFactor,
            int nOffensiveFactor, int nSelfDepravation)
        {
            m_szName = m_szNames[Random.Range(0, m_szNames.Length+1)];
            m_szDescription = szDescription;
            m_nFunFactor = nFunFactor;
            m_nOffensiveFactor = nOffensiveFactor;
            m_nSelfDepravation = nSelfDepravation;
        }
        
        public CItem(string szName, string szDescription, ItemGroup_e eItemGroup, int nFunFactor,
            int nOffensiveFactor, int nSelfDepravation)
        {
            m_szName = szName;
            m_szDescription = szDescription;
            m_nFunFactor = nFunFactor;
            m_nOffensiveFactor = nOffensiveFactor;
            m_nSelfDepravation = nSelfDepravation;
        }

        public CItem copy()
        {
            GameObject obj = Instantiate(gameObject);
            CItem itm = obj.AddComponent<CItem>();
            return itm;
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