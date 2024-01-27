using System;
using UnityEngine;

namespace ItemSystem
{
    public class CItemWrapper : MonoBehaviour
    {
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
            CItem item = new CItem(def, m_eItemGroup, 0, 0, 0);
            m_pItem = item;
            GetComponent<SpriteRenderer>().sprite = def.icon;
        }

        [SerializeField] private ItemGroup_e m_eItemGroup = ItemGroup_e.KING;
        private CItem m_pItem;
        public int m_nFF, m_nOF, m_nSD;
    }
}