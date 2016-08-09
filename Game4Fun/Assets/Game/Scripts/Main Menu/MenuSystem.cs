using UnityEngine;
using System.Collections;

public class MenuSystem : MonoBehaviour {

	public Transform menuCanvas;
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Paused();
		}
	}

	public void Paused()
	{
		if(menuCanvas.gameObject.activeInHierarchy == false)
		{
			menuCanvas.gameObject.SetActive(true);
			Time.timeScale = 0;
		}
		else
		{
			menuCanvas.gameObject.SetActive(false);
			Time.timeScale = 1;
		}
	}

	public void Exit()
	{
		Application.Quit();
	}
}
