using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

 
	void OnCollisionEnter (Collision newCollision)
	{
 
		if (newCollision.gameObject.tag == "Projectile")
		{
 
			GameManager.gm.Exit();
		}
	}
}