using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOverCanvas;

    private GameManager gm;

    void Awake()
    {
        gm = GetComponent<GameManager>();
    }

    public void Gameover()
    {
        Instantiate(GameOverCanvas);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartOver()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        gm.ReloadScene();
    }
}
