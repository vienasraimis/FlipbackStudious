using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeLeft : MonoBehaviour {

	[SerializeField]
	private string levelToLoad;

    [SerializeField]
    private Slider TimeBar;

	public float time;

    void Start()
    {
        TimeBar.maxValue = time;
        TimeBar.value = time;
    }

	void FixedUpdate()
	{
		time -= Time.fixedDeltaTime;
        TimeBar.value = time;


		if(time <= 0f)
		{
            var over = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameOver>();
            over.Gameover();
        }
	}
}
