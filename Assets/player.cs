using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float Xspeed = 4f;
    [SerializeField] float Yspeed = 4f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3f;
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controllPitchFactor = -30f;
    [SerializeField] float positionYawFactor = -5f;
    [SerializeField] float controllRollFactor = -5f;
    float Xthrow;
    float Ythrow;
    // Start is called before the first frame update
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
        float pitch = (transform.localPosition.y * positionPitchFactor) + (Ythrow * controllPitchFactor);
        float roll = (Xthrow * controllRollFactor);
        float yaw = (transform.localPosition.x * positionYawFactor);
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    private void ProcessTranslation()
    {
        Xthrow = Input.GetAxis("Horizontal");
        Ythrow = Input.GetAxis("Vertical");
        float Xoffset = Xthrow * Xspeed * Time.deltaTime;
        float Yoffset = Ythrow * Yspeed * Time.deltaTime;
        float rawNewXpos = transform.localPosition.x + Xoffset;
        float rawNewYpos = transform.localPosition.y + Yoffset;
        rawNewXpos = Mathf.Clamp(rawNewXpos, -xRange, xRange);
        rawNewYpos = Mathf.Clamp(rawNewYpos, -yRange, yRange);
        transform.localPosition = new Vector3(rawNewXpos, rawNewYpos, transform.localPosition.z);
    }
}
