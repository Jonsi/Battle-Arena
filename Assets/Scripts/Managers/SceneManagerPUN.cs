using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

public enum SceneName
{
    LobbyScene = 0,
    RoomScene = 1,
    ArenaScene = 2
}

public class SceneManagerPUN : MonoBehaviour
{
    public static SceneManagerPUN Singleton;

    private int currentScene;

    private void Awake()
    {
        if (SceneManagerPUN.Singleton == null)
        {
            SceneManagerPUN.Singleton = this;
        }
        else if(SceneManagerPUN.Singleton != null)
        {
            Destroy(SceneManagerPUN.Singleton);
            SceneManagerPUN.Singleton = this;
        }

        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNewScene(SceneName sceneName)
    {
        PhotonNetwork.LoadLevel((int)sceneName);
    }

    public void OnSceneFinishedLoading(Scene scene, LoadSceneMode loadSceneMode)
    {
        currentScene = scene.buildIndex;
        SceneManager.LoadScene(scene.buildIndex);
    }
}
