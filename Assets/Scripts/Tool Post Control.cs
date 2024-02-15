using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPostControl : MonoBehaviour
{
    GameObject feedWheel2;
    private Quaternion initialRotation;
    private float translationSpeed = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        feedWheel2 = GameObject.Find("handle2");
        initialRotation = feedWheel2.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the rotation change
        Quaternion rotationChange = feedWheel2.transform.rotation * Quaternion.Inverse(initialRotation);

        // Convert the rotation change to Euler angles for translation
        Vector3 eulerRotationChange = rotationChange.eulerAngles;
        // Use the change in rotation to adjust translation
        float translationAmount = eulerRotationChange.y * translationSpeed;
        if (eulerRotationChange.x > 330){
            // Update the position based on the calculated translation
            transform.Translate(0, 0, translationAmount);
            Debug.Log("near full "+eulerRotationChange);

        }
        else
        {
            transform.Translate(0, 0, -translationAmount);
            Debug.Log("near zero "+eulerRotationChange);

        }


        // Update the initial rotation for the next frame
        initialRotation = feedWheel2.transform.rotation;
    }
}
