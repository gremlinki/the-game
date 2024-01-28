using ItemSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    PAUSED,
    IDLE,
    GATHERING,
    SPECTACLE
}

public class GameManager : MonoBehaviour
{
    public Animator animK;
    public Animator animR;
    public Animator animN;
    public Animator animB;

    public static GameManager instance;

    public CInventoryManager InventoryManager { get; private set; }
    public RelationManager relationManager { get; private set; }
    public Performence Performence { get; private set; }
    public ItemManager ItemManager { get; private set; }

    private AudioSource audioSource;
    public AudioClip[] sounds;

    [SerializeField] private ItemDefinition[] itemDefs;
    private CItem[] items;

    public Player player;
    public GameObject pickupWindow; // The window that pops up when player gets near an item
    public GameState gameState = GameState.IDLE; // Current state of game

    private float timer;
    private int spectacleCounter = 0;
    public int day = 1;
    

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        InventoryManager = new CInventoryManager();
        ItemManager = new ItemManager(itemDefs);
        relationManager = new RelationManager();
    }


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (!player)
        {
            Debug.Log("No player was provided to Game Manager.");
        }
        if (!pickupWindow)
        {
            Debug.Log("PickupWindow wasn't provided to Game Manager.");
        }

        items = InventoryManager.items();

        audioSource.clip = sounds[0];
        audioSource.loop = true;
        audioSource.Play();
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.PAUSED:
                break;
            case GameState.IDLE:
                if (spectacleCounter < 2)
                    StartSpectacle();
                else
                    AdvanceDay();
                break;
            case GameState.GATHERING:
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    StartSpectacle();
                    break;
                }
                else if(InventoryManager.m_pItems[3] != null){
                    StartSpectacle();
                    break;
                }
                break;
            case GameState.SPECTACLE:
                // Spectacle logic here?
                // Player displays all items in succession
                // Npcs do their reactions

                // Each item's values get added to corresponding stats
                foreach (CItem item in items)
                {
                    relationManager.kingAffinity += item.KingFactor * (item.group == ItemGroup_e.KING ? 1 : -1);
                    relationManager.nobillityAffinity += item.RoyaltyFactor * (item.group == ItemGroup_e.KING ? 1 : -1);
                    relationManager.mentalHealth += item.JesterFactor;
                    Performence.AutomaticAfflictionSlider();
                    relationManager.UpdateLevels();
                    //Trigger react emojis
                    if(item.group == ItemGroup_e.KING){
                        animK.SetInteger("KingLike", 1);
                        animN.SetInteger("NobelLike", 2);
                        animR.SetInteger("RussLike", 2);
                        animB.SetInteger("BlackLike", 2);
                    }
                }
                
                spectacleCounter++;
                gameState = GameState.IDLE;
                break;
        }
    }

    public void StartGathering()
    {
        SceneManager.LoadScene("Main Game");
        gameState = GameState.GATHERING;
        timer = 30;
    }

    public void StartSpectacle()
    {
        gameState = GameState.SPECTACLE;
    }

    public void AdvanceDay()
    {
        day++;
        spectacleCounter = 0;
    }

    public void PlayEnding(string name)
    {
        audioSource.Stop();
        switch(name)
        {
            case "king_win":
                break;
            case "king_lose":
                break;
            case "nobillity_win":
                break;
            case "nobillity_lose":
                break;
            case "jester_win":
                break;
            case "jester_lose":
                break;
        }

        // <-- Exit game
    }
}