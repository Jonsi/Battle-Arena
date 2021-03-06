﻿using System.Collections;
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
    private int loadedScene;

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

    private void OnDisable()
    {
        //PhotonNetwork.RemoveCallbackTarget(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        BackButtonPressed();
    }

    public void LoadNewScene(SceneName sceneName)
    {
        PhotonNetwork.LoadLevel((int)sceneName);
    }

    public void OnSceneFinishedLoading(Scene scene, LoadSceneMode loadSceneMode)
    {
        loadedScene = scene.buildIndex;
    }

    //On SceneManager for the need in differen Scenes
    public void BackButtonPressed()
    {
        // Make sure user is on Android platform
        if (Application.platform == RuntimePlatform.Android)
        {

            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Exit?");
                //Switch case for different scenes
            }
        }
    }
}
