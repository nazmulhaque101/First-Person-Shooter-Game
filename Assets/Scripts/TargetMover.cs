using UnityEngine;
using System.Collections;

public class TargetMover : MonoBehaviour {
 
	public enum motionDirections {Horizontal, Vertical};
	
	public motionDirections motionState = motionDirections.Horizontal;

	public float spinSpeed = 180.0f;
	public float motionMagnitude = 0.1f;

	public bool spinRotation = true;

	void Update () {

		switch(motionState) {
			case motionDirections.Horizontal:
				gameObject.transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
				break;
			case motionDirections.Vertical:
				gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
				break;
		}

		if(spinRotation){
			gameObject.transform.Rotate (Vector3.up * spinSpeed * Time.deltaTime);
		}
	}
}
