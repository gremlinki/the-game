using System;
using Unity.VisualScripting;
using UnityEngine;

namespace ItemSystem
{
    public class CItemSpawner : MonoBehaviour
    {
        [SerializeField] private ItemID_e m_eAllowedItems = ItemID_e.CARROT;
        private CItemWrapper wrapper;
        
        private void Awake()
        {
            wrapper = gameObject.AddComponent<CItemWrapper>();
            wrapper.init(m_eAllowedItems);
        }
    }
}