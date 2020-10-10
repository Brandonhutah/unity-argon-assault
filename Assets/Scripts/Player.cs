using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float thrustSpeed;
    [SerializeField] float xSpeed = 30f;
    [SerializeField] float xRange = 11f;
    [SerializeField] float ySpeed = 30f;
    [SerializeField] float yRange = 6f;
    [SerializeField] float pitchFactor = -1f;
    [SerializeField] float yawFactor = 2f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;

    // Update is called once per frame
    void Update()
    {
        ProcessTransform();
        ProcessRotation();
    }

    private void ProcessTransform()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float xPos = Mathf.Clamp(xOffset + transform.localPosition.x, -xRange, xRange);
        float yPos = Mathf.Clamp(yOffset + transform.localPosition.y, -yRange, yRange);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = (transform.localPosition.y * pitchFactor) + (yThrow * controlPitchFactor); // pitch from position + pitch from input
        float yaw = transform.localPosition.x * yawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);        
    }
}
