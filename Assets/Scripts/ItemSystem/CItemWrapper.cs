using System;
using UnityEngine;

namespace ItemSystem
{
    public class CItemWrapper : MonoBehaviour
    {
        public CItem item()
        {
            return m_pItem;
        }

        private void Awake()
        {
            // TODO: Figure out how to initialize attributes ~GabrielV
            m_pItem = new CItem(m_eItemGroup, 0, 0, 0);
        }

        [SerializeField] private ItemGroup_e m_eItemGroup = ItemGroup_e.KING;
        private CItem m_pItem;
        public int m_nFF, m_nOF, m_nSD;
    }
}