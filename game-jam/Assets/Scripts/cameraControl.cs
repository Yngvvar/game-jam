using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    [SerializeField]
    GameObject character;
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    Vector3 defaultCameraPos;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 newPos = character.transform.position + defaultCameraPos;
       
        if (Vector3.Distance(newPos, mainCamera.transform.position) > 0.1f)
        {
            mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, newPos, ref velocity, smoothTime);
        }
    }
}
