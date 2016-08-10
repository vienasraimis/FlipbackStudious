using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float volume = 1f;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(PlayerPrefs.GetInt("FirstRun") == 0)
        {
            PlayerPrefs.SetInt("FirstRun", 1);
            PlayerPrefs.SetFloat("Volume", 1f);

            PlayerPrefs.Save();
        }

        volume = PlayerPrefs.GetFloat("Volume");
        ChangeVolume();

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChangeVolume();
    }


    public void ChangeVolume()
    {

        var allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (var au in allAudioSources)
        {
            au.volume = volume;
        }
    }

}
