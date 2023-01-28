using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
	// Start is called before the first frame update
	public Canvas gameOver;
	void Start()
	{
		gameOver.enabled = false;
	}

	// Update is called once per frame
	public void HandleDeath()
	{
		gameOver.enabled = true;
		Time.timeScale = 0;
		FindObjectOfType<Weapons>().enabled = false;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}
