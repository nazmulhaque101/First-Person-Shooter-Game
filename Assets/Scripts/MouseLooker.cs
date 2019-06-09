using UnityEngine;
using System.Collections;

public class MouseLooker : MonoBehaviour {

 
	public float XSensitivity = 2f;
	public float YSensitivity = 2f;
	public bool clampVerticalRotation = true;
	public float MinimumX = -90F;
	public float MaximumX = 90F;
	public bool smooth;
	public float smoothTime = 5f;
	
 
	private Quaternion m_CharacterTargetRot;
	private Quaternion m_CameraTargetRot;
	private Transform character;
	private Transform cameraTransform;

	void Start() {
 
		LockCursor (true);

 
		character = gameObject.transform;

 
		cameraTransform = Camera.main.transform;

 
		m_CharacterTargetRot = character.localRotation;
		m_CameraTargetRot = cameraTransform.localRotation;
	}
	
	void Update() {
 
		LookRotation ();

 
		if(Input.GetButtonDown("Cancel")){
			LockCursor (false);
		}

 
		if(Input.GetButtonDown("Fire1")){
			LockCursor (true);
		}
	}
	
	private void LockCursor(bool isLocked)
	{
		if (isLocked) 
		{
 
			Cursor.visible = false;

 
			Cursor.lockState = CursorLockMode.Locked;
		} else {
 
			Cursor.visible = true;
 
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public void LookRotation()
	{
 
		float yRot = Input.GetAxis("Mouse X") * XSensitivity;
		float xRot = Input.GetAxis("Mouse Y") * YSensitivity;
 
		m_CharacterTargetRot *= Quaternion.Euler (0f, yRot, 0f);
		m_CameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);
 
		if(clampVerticalRotation)
			m_CameraTargetRot = ClampRotationAroundXAxis (m_CameraTargetRot);
 
		if(smooth)  
		{
			character.localRotation = Quaternion.Slerp (character.localRotation, m_CharacterTargetRot,
			                                            smoothTime * Time.deltaTime);
			cameraTransform.localRotation = Quaternion.Slerp (cameraTransform.localRotation, m_CameraTargetRot,
			                                         smoothTime * Time.deltaTime);
		}
		else  
		{
			character.localRotation = m_CharacterTargetRot;
			cameraTransform.localRotation = m_CameraTargetRot;
		}
	}
 
	Quaternion ClampRotationAroundXAxis(Quaternion q)
	{
		q.x /= q.w;
		q.y /= q.w;
		q.z /= q.w;
		q.w = 1.0f;
		
		float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);
		
		angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);
		
		q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);
		
		return q;
	}
}
