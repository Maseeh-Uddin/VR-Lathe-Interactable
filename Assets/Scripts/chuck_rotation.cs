using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chuck_rotation : MonoBehaviour
{
    public float rotationSpeed = 50.0f;  // Adjust the speed of rotation as needed
    public bool isSpindleRotating = false;

    private Coroutine rotationCoroutine;

    public void start_chuck_rotation()
    {
        if (!isSpindleRotating)
        {
            isSpindleRotating = true;
            rotationCoroutine = StartCoroutine(RotateChuck());
        }
    }

    public void stop_chuck_rotation()
    {
        if (isSpindleRotating && rotationCoroutine != null)
        {
            StopCoroutine(rotationCoroutine);
            isSpindleRotating = false;
        }
    }

    IEnumerator RotateChuck()
    {
        while (isSpindleRotating)
        {
            // Rotate the chuck around its own local Y-axis
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime*10);

            yield return null; // Wait for the next frame
        }
    }
}