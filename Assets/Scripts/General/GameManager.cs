using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // SINGLETON CLASS: IT WILL EXIST BETWEEN SCENES

    #region SINGLETON
    private static GameManager Instance;
    private static bool IsApplicationQuiting = false;

    public bool IsGameOver = false;

    

    public static GameManager GetInstance
    {
        get
        {
            if (Instance == null && !IsApplicationQuiting)
            {
                Instance = FindObjectOfType<GameManager>();
                if (Instance == null)
                {
                    // No Instance found of this class : Create a new one
                    GameObject NewGameManager = new GameObject("Singleton_GameManager");
                    Instance = NewGameManager.AddComponent<GameManager>();
                }
            }

            return Instance;
        }
    }

    public void OnApplicationQuit()
    {
        IsApplicationQuiting = true;
    }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        IsGameOver = false;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                // Duplicate. We only want one Instance of this class
                Destroy(gameObject);
            }
        }

        // Get all other managers components like SceneManager, SoundManager ...
        _sceneManager = GetComponent<SceneController>();
        _soundManager = GetComponent<SoundManager>();
        _WorldManager = GetComponent<World>();

        _soundManager.PlayMusic();
    }

    #endregion

    public enum GameStage { Menu, Tutorial, Pause, Playing, GameOver, Restart };
    public enum ResourceType {  Wood, Mineral, WoodAndMineral };  // Last type if for the humans know wich resource grab
    public enum ContrusctionType {  Church, House, Forge, Farm };

    public enum PlayerNumber { Player1, Player2 };

    public enum HumanBehaviors {  MovingToResource, MovingToChurch, GatheringResource, MovingToBuild, Building, CheckIfResources };

    public enum HumanOrders {  GatherResources, BuildHouse, BuildChurch, NoOrders };

    // Level / Scene Management
    private GameStage _GameStage = GameStage.Menu;

    public PlayerNumber _PlayerWinner;

    // Manager objects 
    private SceneController _sceneManager = null;
    private SoundManager _soundManager = null;
    private World _WorldManager = null;


    private void Start()
    {
        
    }


    private void Update()
    {
        if (_sceneManager != null)
        {
            switch (_GameStage)
            {
                case GameStage.GameOver:
                    break;
                case GameStage.Restart:
                    break;

            }
        }

        if(IsGameOver)
        {
            _soundManager.StopMusic();
            SceneManager.LoadScene(2);
        }
    }


    public SoundManager SoundManager
    {
        get { return _soundManager; }
    }

    public SceneController SceneController
    {
        get { return _sceneManager; }
    }

    public World WorldManager
    {
        get { return _WorldManager; }
    }
}
