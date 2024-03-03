using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerControls : MonoBehaviour

{
    // Start is called before the first frame update
    [SerializeField] float speedControl = 10f;
    [SerializeField] float xRange = 3f;
    [SerializeField] float yRange = 3f;
    float moveX;
    float moveY;
    [SerializeField] float PostionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -20f;
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
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * PostionPitchFactor + moveY * controlPitchFactor;
        float yaw = 0f;
        float roll = transform.localPosition.z * PostionPitchFactor + moveX * controlPitchFactor;
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
}
