using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeLeft : MonoBehaviour
{

	[SerializeField]
	private string levelToLoad;

    [SerializeField]
    private Slider TimeBar;

	public float time;
    private bool over = false;

    void Start()
    {
        TimeBar.maxValue = time;
        TimeBar.value = time;
    }

	void FixedUpdate()
	{
		time -= Time.fixedDeltaTime;
        TimeBar.value = time;


		if(time <= 0f && !over)
		{
            over = true;
            var gover = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameOver>();
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;
            gover.Gameover();
        }
	}
}
