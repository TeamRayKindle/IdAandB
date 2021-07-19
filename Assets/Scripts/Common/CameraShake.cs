using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform CameraTransform;
	
	// How long the object should shake for.
	public float ShakeDuration = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float ShakeAmount = 0.7f;
	public float DecreaseFactor = 1.0f;
	
	private Vector3 originalPosition;
	
	void Awake()
	{
		if (CameraTransform == null)
		{
			CameraTransform = GetComponent<Transform>();
		}
	}
	
	void OnEnable()
	{
		originalPosition = CameraTransform.localPosition;
	}

	void Update()
	{
		if (ShakeDuration > 0)
		{
			CameraTransform.localPosition = originalPosition + Random.insideUnitSphere * ShakeAmount;
			//Debug.Log("ShakeDuration" + ShakeDuration);
			ShakeDuration -= Time.deltaTime * DecreaseFactor;
		}
		else
		{
			ShakeDuration = 0f;
			CameraTransform.localPosition = originalPosition;
		}
	}
	public void SetShakeDurationAndAmount(float shakeDuration, float shakeAmount)
    {
		ShakeDuration = shakeDuration;
		ShakeAmount = shakeAmount;
    }
}