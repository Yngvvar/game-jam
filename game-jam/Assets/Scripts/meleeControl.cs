using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeControl : MonoBehaviour
{

    int timer = 0;
    // Start is called before the first frame update
    
    private void FixedUpdate()
    {
        timer++;
        if (timer == 2)
        {
            Destroy(this.gameObject);
        }
    }

}
