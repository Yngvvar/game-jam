using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoting : MonoBehaviour
{
    [SerializeField]
    GameObject character;
    [SerializeField]
    GameObject objectToSpawn;
    [SerializeField]
    Transform spawnPosytion;
    [SerializeField]
    Transform bullets;
    [SerializeField]
    float bulletSpeed;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            shoot();
        }
        spawnPosytion.localRotation = character.transform.localRotation;
    }




    void shoot()
    {
        GameObject bullet = Instantiate<GameObject>(objectToSpawn, spawnPosytion.transform.position, character.transform.rotation, bullets.transform);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(Vector3.forward * bulletSpeed, ForceMode.Force);

    }
}
