using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
	
	public GameObject Menu;
	
	public void exit()
	{
		Application.Quit();
	}
	
	public void play()
	{
		Menu.gameObject.SetActive (true);
	}
	
	public void backToMenu()
	{
		Menu.gameObject.SetActive(false);
	}
}
