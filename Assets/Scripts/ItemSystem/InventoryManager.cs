﻿using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
    public class CInventoryManager
    {
        private static readonly int MAX_SLOT = 3;
        private CItem[] m_pItems = new CItem[MAX_SLOT];
        private int m_nCurrentSlot = 0;
        
        public CItem[] items()
        {
            return m_pItems;
        }

        public void addItem(CItem pItem)
        {
            for (int i = 0; i < MAX_SLOT; i++)
            {
                if (m_pItems[i] != null) continue;
                m_pItems[i] = pItem.copy();
                break;
            }
            Debug.Log(m_pItems[0]);
        }

        public void removeItem(int nSlot)
        {
            if (nSlot < 0 || nSlot >= MAX_SLOT) return;
            m_pItems[nSlot] = null;
        }

        public CItem getItem(int nSlot)
        {
            if (nSlot >= MAX_SLOT) return null;
            m_nCurrentSlot = nSlot;
            return m_pItems[nSlot];
        }
    }
}