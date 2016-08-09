using UnityEngine;
using UnityEngine.Networking;

public class DisableComponents : NetworkBehaviour {

	[SerializeField]
	Behaviour[] componentsToDisable;

	// Use this for initialization
	void Start() 
	{
		if(!isLocalPlayer)
		{
			for(int i = 0; i < componentsToDisable.Length; i++)
			{
				componentsToDisable[i].enabled = false;
			}
		}
		else
		{
			Camera.main.gameObject.SetActive(false);
		}
	}
}
