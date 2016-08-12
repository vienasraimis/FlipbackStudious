﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float volume = 1f;
    public int SceneIndex = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.GetInt("FirstRun") == 0)
        {
            PlayerPrefs.SetInt("FirstRun", 1);
            PlayerPrefs.SetFloat("Volume", 1f);

            PlayerPrefs.Save();
        }

        volume = PlayerPrefs.GetFloat("Volume");
        ChangeVolume();

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;

        SceneManager.LoadScene(1);
    }

    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChangeVolume();

        SceneIndex = scene.buildIndex;
    }


    public void ChangeVolume()
    {
        var allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (var au in allAudioSources)
        {
            au.volume = volume;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneIndex);
        

    }

}
