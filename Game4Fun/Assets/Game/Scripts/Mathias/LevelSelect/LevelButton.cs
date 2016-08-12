using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    public string Level = "Level0";
    private Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.interactable = false;

        foreach (var lvl in GameManager.singleton.GetUnlockedLevels())
        {
            if(lvl.SceneName == Level && lvl.unlocked)
            {
                btn.interactable = true;
            }
        }
        
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(Level);
    }
}
