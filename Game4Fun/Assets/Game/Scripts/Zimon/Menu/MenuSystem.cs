using UnityEngine;
using System.Collections;

public class MenuSystem : MonoBehaviour {

	public Transform menuCanvas;
	public Transform mainMenu;
	public Transform levelSelectMenu;
	public Transform creditsMenu;

	void Start () 
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			PausedGame();
		}
	}

	public void PausedGame()
	{
		if(menuCanvas.gameObject.activeInHierarchy == false)
			{
				//Active
				menuCanvas.gameObject.SetActive(true);
				mainMenu.gameObject.SetActive(true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				Time.timeScale = 0;

				//Inactive
				levelSelectMenu.gameObject.SetActive(false);
				creditsMenu.gameObject.SetActive(false);
			}
			else
			{
				menuCanvas.gameObject.SetActive(false);
				mainMenu.gameObject.SetActive(false);
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				Time.timeScale = 1;
			}
	}

	public void LevelSelect(bool OpenMenu)
	{
		if(OpenMenu)
		{
			levelSelectMenu.gameObject.SetActive(true);
			mainMenu.gameObject.SetActive(false);
		}
		if(!OpenMenu)
		{
			levelSelectMenu.gameObject.SetActive(false);
			mainMenu.gameObject.SetActive(true);
		}
	}

	public void Credits(bool OpenMenu)
	{
		if(OpenMenu)
		{
			creditsMenu.gameObject.SetActive(true);
			mainMenu.gameObject.SetActive(false);
		}
		if(!OpenMenu)
		{
			creditsMenu.gameObject.SetActive(false);
			mainMenu.gameObject.SetActive(true);
		}
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}