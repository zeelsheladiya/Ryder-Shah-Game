using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComtroller : MonoBehaviour
{
	
	public Transform target;
	
	public Vector3 offset;
	
	private void LateUpdate()
	{
		
		Vector3 newpos = target.position + offset ; 
		newpos.z = transform.position.z;
		
		transform.position = newpos;
		
	}
	
}
