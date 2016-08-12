using UnityEngine;
using System.Collections;

public class GameOverCanvas : MonoBehaviour
{
    public void Retry()
    {
        var over = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameOver>();
        over.StartOver();
    }
}
