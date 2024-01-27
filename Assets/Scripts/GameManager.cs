using ItemSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CInventoryManager InventoryManager { get; private set; }
    
    private GameManager()
    {
        InventoryManager = new CInventoryManager();
    }

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}