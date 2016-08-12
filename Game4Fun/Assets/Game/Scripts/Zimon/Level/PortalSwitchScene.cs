using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortalSwitchScene : MonoBehaviour {

	[SerializeField]
	string levelToLoad;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
            var lvl = GameManager.singleton.GetLevelByName(levelToLoad);
            GameManager.singleton.UnlockLevel(lvl);

			SceneManager.LoadScene(levelToLoad);
            
		}
	}
}
