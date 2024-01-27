using UnityEngine;

namespace ItemSystem
{
    public class CItemSpawner : MonoBehaviour
    {
        [SerializeField] private ItemID_e m_eAllowedItems = ItemID_e.CARROT;
    }
}