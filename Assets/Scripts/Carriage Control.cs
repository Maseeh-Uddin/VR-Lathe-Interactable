using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriageControl : MonoBehaviour
{
    GameObject feedWheel1;
    private Quaternion initialRotation;
    public float translationSpeed = 0.00004f;

    // Start is called before the first frame update
    void Start()
    {
        feedWheel1 = GameObject.Find("handle1");
        initialRotation = feedWheel1.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the rotation change
        Quaternion rotationChange = feedWheel1.transform.rotation * Quaternion.Inverse(initialRotation);

        // Convert the rotation change to Euler angles for translation
        Vector3 eulerRotationChange = rotationChange.eulerAngles;
        // Use the change in rotation to adjust translation
        if (eulerRotationChange.x > 300)
        {
            float translationAmount = (360-eulerRotationChange.x) * translationSpeed;

            // Update the position based on the calculated translation
            transform.Translate(translationAmount,0, 0);
            //Debug.Log("carriage near full " + eulerRotationChange);

        }
        else
        {
            float translationAmount = eulerRotationChange.x * translationSpeed;

            transform.Translate(-translationAmount,0, 0);
            //Debug.Log("carriage near zero " + eulerRotationChange);

        }


        // Update the initial rotation for the next frame
        initialRotation = feedWheel1.transform.rotation;
    }
}
