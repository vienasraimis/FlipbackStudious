using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    public float coins = 0f;
    public float volume = 1f;

    public int SceneIndex = 0;

    public LevelBuilder lvlBuilder;

    private List<Level> levels;

    void Awake()
    {
        singleton = this;

        DontDestroyOnLoad(gameObject);

        levels = lvlBuilder.Build();

        if (PlayerPrefs.GetInt("FirstRun") == 0)
        {
            PlayerPrefs.SetInt("FirstRun", 1);
            PlayerPrefs.SetFloat("Volume", 1f);
            PlayerPrefs.SetFloat("Coins", 0f);

            PlayerPrefs.Save();
        }

        volume = PlayerPrefs.GetFloat("Volume");
        ChangeVolume();

        coins = PlayerPrefs.GetFloat("Coins");

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
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

    #region Levels

    public List<Level> GetUnlockedLevels()
    {
        List<Level> un = new List<Level>();

        foreach (var Level in levels)
        {
            if (Level.unlocked)
            {
                un.Add(Level);
            }
        }

        return un;
    }

    public List<Level> GetLevels()
    {
        return levels;
    }

    public Level GetCurrentLevel()
    {
        foreach (var lvl in levels)
        {
            if (lvl.index + 1 == SceneIndex)
            {
                return lvl;
            }
        }

        return new Level();
    }

    public Level GetLevelByName(string name)
    {
        foreach (var lvl in levels)
        {
            if (lvl.SceneName == name)
            {
                return lvl;
            }
        }

        return new Level();
    }

    public void UnlockLevel(Level lvl)
    {
        levels[lvl.index].unlocked = true;

        lvlBuilder.Save(levels);
    }
    #endregion

}
