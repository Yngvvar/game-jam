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
    [SerializeField]
    float moveSpead;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = character.transform.position + defaultCameraPos;
       
        if (Vector3.Distance(newPos, mainCamera.transform.position) > 0.1f)
        {
            mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, newPos, ref velocity, smoothTime);
        }
    }
}
