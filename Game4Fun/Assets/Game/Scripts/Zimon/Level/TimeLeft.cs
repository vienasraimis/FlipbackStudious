using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeLeft : MonoBehaviour {

	[SerializeField]
	string levelToLoad;

	public float time;

	void FixedUpdate()
	{
		time -= Time.fixedDeltaTime;

		if(time <= 0f)
		{
			SceneManager.LoadScene(levelToLoad);
		}
	}
}
