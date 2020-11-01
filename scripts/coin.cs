using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

	public int CoinValue = 1;
	
	private void OnTriggerEnter2D(Collider2D player)
	{
		//Debug.Log(player);
		if(player.gameObject.CompareTag("player"))
		{
			ScoreManger.instance.ChangeScore(CoinValue);
		}
	}	
}
