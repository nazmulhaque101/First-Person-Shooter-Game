using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
 
	public GameObject projectile;
	public float power = 80.0f;
	 
	public AudioClip shootSFX;
	 
	void Update () { 
		if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
		{	 
			if (projectile)
			{ 
				GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;
 
				if (!newProjectile.GetComponent<Rigidbody>()) 
				{
					newProjectile.AddComponent<Rigidbody>();
				} 
				newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);
				 
				if (shootSFX)
				{
					if (newProjectile.GetComponent<AudioSource> ()) {  
						newProjectile.GetComponent<AudioSource> ().PlayOneShot (shootSFX);
					} else { 
						AudioSource.PlayClipAtPoint (shootSFX, newProjectile.transform.position);
					}
				}
			}
		}
	}
}
