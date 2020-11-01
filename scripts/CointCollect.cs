using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointCollect : MonoBehaviour
{
	public ParticleSystem coinparticle;
	
	private void OnTriggerEnter2D(Collider2D player)
	{
		//Debug.Log(this.gameObject);
		if(this.gameObject.CompareTag("Coin"))
		{
			coinparticle.Play();
			//new WaitForSeconds(2);
			Destroy(this.gameObject);
		}
	}	
	
}
