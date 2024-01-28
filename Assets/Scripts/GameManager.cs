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
    
    public AudioSource audioSource;
    public AudioClip[] sounds;

    [SerializeField] private ItemDefinition[] itemDefs;
    private CItem[] items;

    public Player player;
    public GameObject pickupWindow; // The window that pops up when player gets near an item
    public GameState gameState = GameState.GATHERING; // Current state of game

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
        if (SceneManager.GetActiveScene().buildIndex == (int)SceneLoader.EScene.ENDING) return;
        
        if (SceneManager.GetActiveScene().buildIndex == (int)SceneLoader.EScene.SPECTACLE)
        {
            animK = GameObject.FindWithTag("king").GetComponent<Animator>();
            animN = GameObject.FindWithTag("noble").GetComponent<Animator>();
            animB = GameObject.FindWithTag("blacknoble").GetComponent<Animator>();
            animR = GameObject.FindWithTag("russ").GetComponent<Animator>();
            Performence = GameObject.FindWithTag("Respawn").GetComponent<Performence>();
        }
        
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
                if(InventoryManager.items()[2] != null){
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
        gameState = GameState.GATHERING;
        timer = 30;
        SceneLoader.LoadScene(SceneLoader.EScene.GAME, new SceneLoader.SceneCallback_t());
    }

    public void StartSpectacle()
    {
        gameState = GameState.SPECTACLE;
        SceneLoader.LoadScene(SceneLoader.EScene.SPECTACLE, new SceneLoader.SceneCallback_t());
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
                SceneLoader.LoadScene(SceneLoader.EScene.ENDING, new SceneLoader.SceneCallback_t((int)EndingManager.Ending_t.KING_WIN));
                break;
            case "king_lose":
                SceneLoader.LoadScene(SceneLoader.EScene.ENDING, new SceneLoader.SceneCallback_t((int)EndingManager.Ending_t.KING_LOSE));
                break;
            case "nobillity_win":
                SceneLoader.LoadScene(SceneLoader.EScene.ENDING, new SceneLoader.SceneCallback_t((int)EndingManager.Ending_t.NOBILLITY_WIN));
                break;
            case "nobillity_lose":
                SceneLoader.LoadScene(SceneLoader.EScene.ENDING, new SceneLoader.SceneCallback_t((int)EndingManager.Ending_t.NOBILLITY_LOSE));
                break;
            case "jester_win":
                SceneLoader.LoadScene(SceneLoader.EScene.ENDING, new SceneLoader.SceneCallback_t((int)EndingManager.Ending_t.JESTER_WIN));
                break;
            case "jester_lose":
                SceneLoader.LoadScene(SceneLoader.EScene.ENDING, new SceneLoader.SceneCallback_t((int)EndingManager.Ending_t.JESTER_LOSE));
                break;
        }

        // <-- Exit game
    }
}