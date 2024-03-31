using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SocialPlatforms;

public class PlayerControls : MonoBehaviour

{
    // Start is called before the first frame update
    [SerializeField] float speedControl = 10f;
    [SerializeField] float xRange = 7f;
    [SerializeField] float yRange = 4f;
    float moveX;
    float moveY;
    [SerializeField] float postionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -20f;

    [SerializeField] float postionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] GameObject[] lasers;

    // [SerializeField]float pitch = 0f;
    // [SerializeField]float yaw = 0f;
    // [SerializeField]float roll = 0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * postionPitchFactor + moveY * controlPitchFactor;
        float yaw = transform.localPosition.x * postionYawFactor;
        float roll = moveX * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    private void ProcessTranslation()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        float xOffset = moveX * speedControl * Time.deltaTime;
        float newPosX = transform.localPosition.x + xOffset;
        float clampXPos = Mathf.Clamp(newPosX, -xRange, xRange);

        float yOffset = moveY * speedControl * Time.deltaTime;
        float newPosY = transform.localPosition.y + yOffset;
        float clampYPos = Mathf.Clamp(newPosY, -yRange, yRange);
        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }

    private void ProcessFiring()
    {
        if (Input.GetButton("Fire1") )
            SetLaserActive(true);
        else
            SetLaserActive(false);
    }

    void SetLaserActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emission= laser.GetComponent<ParticleSystem>().emission;
            emission.enabled=isActive;
        }
    }
  
}
