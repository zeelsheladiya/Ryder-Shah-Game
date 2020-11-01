using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplate : MonoBehaviour
{
	public ParticleSystem coinparticle;
	
	public GameObject finishM;
	
	bool finish = false;
	
	private void OnTriggerEnter2D(Collider2D player)
	{
		//Debug.Log(this.gameObject);
		if(this.gameObject.CompareTag("Coin"))
		{
			coinparticle.Play();
			//new WaitForSeconds(2);
			//Destroy(this.gameObject);
			//this.gameObject.SetActive (false);
			
			finish = true;
			
			StartCoroutine(waiter());
		}
	}
	
	IEnumerator waiter()
	{

		
		float counter = 0;
		
		finish = true;
		//Wait for 2 seconds
		float waitTime = 2;
		while (counter < waitTime)
		{
			//Increment Timer until counter >= waitTime
			counter += Time.deltaTime;
			//Debug.Log("We have waited for: " + counter + " seconds");
			//Wait for a frame so that Unity doesn't freeze
			//Check if we want to quit this function
			if (finish == false)
			{
				//Quit function
				yield break;
			}
			yield return null;
			
		}
		
		//Debug.Log("finish");
		
		finishM.gameObject.SetActive (true);
		
		Time.timeScale = 0f;

	}
	
}
