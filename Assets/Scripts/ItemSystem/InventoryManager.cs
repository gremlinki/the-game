﻿using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

namespace ItemSystem
{
    public class CInventoryManager
    {
        private const int MAX_SLOT = 3;
        public CItem[] m_pItems = new CItem[MAX_SLOT];
        
        public CItem[] items()
        {
            return m_pItems;
        }

        public bool addItem(CItem pItem, int nSlot)
        {
            // Slot already occupied
            if (m_pItems[nSlot] != null) return false;
            m_pItems[nSlot] = pItem.copy();
            Debug.Log($"Adding {pItem} to slot {nSlot}");
            GameObject.Destroy(pItem.parent);
            return true;
        }

        /// <summary>
        /// Add a item to first free slot
        /// </summary>
        /// <param name="pItem"></param>
        public bool addItem(CItem pItem)
        {
            for (int i = 0; i < MAX_SLOT; i++)
            {
                if (m_pItems[i] != null) continue;
                return addItem(pItem, i);
            }

            return false;
        }
        
        public bool removeItem(int nSlot)
        {
            if (nSlot < 0 || nSlot >= MAX_SLOT) return false;
            m_pItems[nSlot] = null;
            return true;
        }

        public CItem getItem(int nSlot)
        {
            if (nSlot < 0 || nSlot >= MAX_SLOT) return null;
            return m_pItems[nSlot];
        }
    }
}