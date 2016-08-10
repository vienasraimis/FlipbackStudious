using UnityEngine;
using System.Collections;

public class MenuSystem : MonoBehaviour {

	public Transform menuCanvas;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
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
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Time.timeScale = 0;
		}

		else
		{
			menuCanvas.gameObject.SetActive(false);
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			Time.timeScale = 1;
		}
	}

	public void Exit()
	{
		Application.Quit();
	}
}
