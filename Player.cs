using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In Ms^-1")][SerializeField] float speed = 18f;
    [SerializeField] float xOffSet;
    [SerializeField] float yOffset;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    public float xThrow, yThrow;

    float pitch;
    float yaw;
    float roll;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();

    }

    private void ProcessRotation()
    {
        pitch = (positionPitchFactor * transform.localPosition.y) + (yThrow * controlPitchFactor);
        yaw = positionYawFactor * transform.localPosition.x;
        roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        xOffSet = xThrow * speed * Time.deltaTime;
        yOffset = yThrow * speed * Time.deltaTime;
        float rawNewXpos = Mathf.Clamp(transform.localPosition.x + xOffSet, -xRange, xRange);
        float rawNewYpos = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);
        print(xOffSet);

        transform.localPosition = new Vector3(rawNewXpos, rawNewYpos, transform.localPosition.z);
    }
}
