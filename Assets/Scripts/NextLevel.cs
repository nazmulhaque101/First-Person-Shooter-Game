using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	 
	void OnCollisionEnter(Collision newCollision)
	{
		 
		if (newCollision.gameObject.tag == "Projectile") {
			 
			GameManager.gm.NextLevel();
		}
	}
}
