using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    
    void Start()
    {
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Destroy(this.gameObject);
    }
    private void OnCollisionExit(Collision collision)
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
