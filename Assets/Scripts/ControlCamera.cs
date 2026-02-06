

using UnityEngine;

public class CameraFlip : MonoBehaviour
{
    private bool isUpsideDown = false;
    // Rotation speed (optional, to make the movement smooth)
    public float rotationSpeed = 360f;

    void Update()
    {
        // UP arrow to return to normal (0 degrees)
        if (Input.GetKeyDown(KeyCode.UpArrow) && isUpsideDown)
        {
            StartCoroutine(RotateCamera(0f));
            isUpsideDown = false;
        }
        // DOWN arrow to flip (180 degrees)
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !isUpsideDown)
        {
            StartCoroutine(RotateCamera(180f));
            isUpsideDown = true;
        }
    }

    // Coroutine to rotate smoothly
    System.Collections.IEnumerator RotateCamera(float targetAngle)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, 0, targetAngle);
        float elapsed = 0f;

        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * (rotationSpeed / 180f);
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsed);
            yield return null;
        }
        transform.rotation = endRotation;
    }
}