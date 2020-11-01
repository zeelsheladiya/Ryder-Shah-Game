using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{
	public Rigidbody2D rb;
	
	public Transform player;

	public float speed = 20f;
	
	public float RotationSpeed = 2f;
	
	public GameObject DiePanel;
	
	public GameObject PausePanel;
	
	bool move = false;
	
	bool isGrounded = false;
	
	bool die = false;
	
	private void Update()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			move = true;
		}
		
		if(Input.GetButtonUp("Fire1"))
		{
			move = false;
		}
		
		if(player.transform.position.y<-150f)
		{
			Time.timeScale = 0.5f;
			DiePanel.gameObject.SetActive (true);
		}
		
	}
	
	private void FixedUpdate()
	{
		if(move==true)
		{
			if(isGrounded==true)
			{
				float Zangle = calangle(player.transform.localEulerAngles.z);
					
				//Debug.Log(Zangle);
				
	 			if(Zangle>150f && Zangle<300f)
				{
					// death function with 2 second delay
					StartCoroutine(waiter());
				}
				else
				{	
					die = false;
					rb.AddForce(transform.right * speed * Time.fixedDeltaTime * 100f , ForceMode2D.Force);
				} 
			}
			else
			{
				die = false;
				
				rb.AddTorque( RotationSpeed * RotationSpeed * Time.fixedDeltaTime * 100f , ForceMode2D.Force);	
				//Debug.Log("turn");
			}
		}
	}
	
	IEnumerator waiter()
	{

		
		float counter = 0;
		
		die = true;

		//Wait for 2 seconds
		float waitTime = 2;
		while (counter < waitTime)
		{
			//Increment Timer until counter >= waitTime
			counter += Time.deltaTime;
			//Debug.Log("We have waited for: " + counter + " seconds");
			//Wait for a frame so that Unity doesn't freeze
			//Check if we want to quit this function
			if (die == false)
			{
				//Quit function
				yield break;
			}
			yield return null;
			
		}
		
			if(die)
			{
				//Debug.Log("die");
				death();
			}

	}
	
	public static float calangle(float eulerAngles)
      {
          float result = eulerAngles - Mathf.CeilToInt(eulerAngles / 360f) * 360f;
          if (result < 0)
          {
              result += 360f;
          }
          return result;
      }
	
	public void Press(bool Press)
	{
		if(Press)
		{
			if(isGrounded==true)
			{
				rb.AddForce(transform.right * speed * Time.fixedDeltaTime * 100f , ForceMode2D.Force);
			}
			else
			{
				rb.AddTorque( RotationSpeed * RotationSpeed * Time.fixedDeltaTime * 100f , ForceMode2D.Force);	
				//Debug.Log("turn");
			}
		}	
	}
	
	public void UnPress()
	{
		rb.AddForce(transform.right * 0 * Time.fixedDeltaTime * 100f , ForceMode2D.Force);
		//Debug.Log("not clicked");
	}
	
	private void OnCollisionEnter2D()
	{
		isGrounded = true;
	}
	
	private void OnCollisionExit2D()
	{
		isGrounded = false;
	}
	
	public void death()
	{
		Time.timeScale = 0.5f;
		DiePanel.gameObject.SetActive (true);
		
	}
	
	public void Pause()
	{
		Time.timeScale = 0f;
		PausePanel.gameObject.SetActive (true);
	}
	
	public void Resume()
	{
		Time.timeScale = 1f;
		PausePanel.gameObject.SetActive (false);
	}
	
}
