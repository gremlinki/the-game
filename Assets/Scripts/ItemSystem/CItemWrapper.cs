using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ItemSystem
{
    public class CItemWrapper : MonoBehaviour
    {
        private static int[] values =
        {
            -20, -15, -10, -5, 5, 10, 15, 20
        };
        
        public CItem item
        {
            get
            {
                return m_pItem;
            }

            set
            {
                m_pItem = value;
            }
        }

        public void init(ItemID_e allowedItems)
        {
            ItemDefinition def = GameManager.instance.ItemManager.getRandomItem(allowedItems);
            int kf, nf, js;

            kf = values[Random.Range(0, values.Length)];
            nf = values[Random.Range(0, values.Length)];
            js = values[Random.Range(0, values.Length)];
            
            CItem item = new CItem(def, m_eItemGroup, kf, nf, js);
            m_pItem = item;
            GetComponent<SpriteRenderer>().sprite = def.icon;
            NumberAssingner(kf,nf,js);
        }

        [SerializeField] private ItemGroup_e m_eItemGroup = ItemGroup_e.KING;
        private CItem m_pItem;
        public int KingNumber, NobleNumber, PSYNumber;

        void NumberAssingner(int KingF, int NobleF, int JesterS){
            KingNumber = KingF;
            NobleNumber = NobleF;
            PSYNumber = JesterS;
        }
    }
}