using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{

    [Header("Debugging")]
    [SerializeField]private bool initializeDataIfNull=false;
    [Header("File Storage Config")]
    [SerializeField] private string fileNanme;
    [SerializeField] private bool useEncryption;

    private GameData gameData;


    public static DataPersistenceManager instance { get; private set; }

    

    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler DataHandler;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Tim thay Datapersistence Manager trong scene ");            
            Destroy(this.gameObject);
            return;

        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.DataHandler = new FileDataHandler(Application.persistentDataPath, fileNanme, useEncryption);
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }


    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // Load any data from dataHandler
        this.gameData = DataHandler.Load();
        if(this.gameData == null && initializeDataIfNull)
        {
            NewGame();
        }

        if (this.gameData == null)
        {
            Debug.Log("No Data was found");
            return;
        }

      foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {

        if(this.gameData == null)
        {
            Debug.LogWarning("no data was found, a new game need to be started.");
            return ;
        }

        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            
            // save data to file using dataHandler
                dataPersistenceObj.SaveData(gameData);  
        }

        Scene scene = SceneManager.GetActiveScene();
        if (!scene.name.Equals("MainMenu")) // khong luu mainmenu scene
            {
                gameData.currentSceneName = scene.name;
                
            }                
        DataHandler.Save(gameData);     

    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }


    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistencesObjects);
    }


    public bool HasGameData()
    {
        return gameData!= null;
    }

    public string GetsavedSceneName()
    {
        if(gameData==null)
        {
            Debug.LogError("Tried to get scene name but was null");
            return null;
        }
        return gameData.currentSceneName;
    }
}
