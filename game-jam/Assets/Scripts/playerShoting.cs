using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoting : MonoBehaviour
{
    [SerializeField]
    GameObject gun;
    [SerializeField]
    GameObject objectToSpawn;
    [SerializeField]
    GameObject meleObject;
    [SerializeField]
    Transform spawnPosytion;
    [SerializeField]
    Transform bullets;
    [SerializeField]
    float bulletSpeed;

    GameObject meleeWeapon;


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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            melee();
        }
        Debug.DrawRay(spawnPosytion.transform.position, gun.transform.forward, Color.red);
        //spawnPosytion.localRotation = gun.transform.localRotation;
    }

    void shoot()
    {
        GameObject bullet = Instantiate<GameObject>(objectToSpawn, spawnPosytion.transform.position, gun.transform.rotation, bullets.transform);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        
        bulletRb.AddForce(gun.transform.forward * bulletSpeed, ForceMode.Force);
        print(gun.transform.forward);
    }
    void melee()
    {
        meleeWeapon = Instantiate<GameObject>(meleObject, spawnPosytion.transform.position, gun.transform.rotation, bullets.transform);
        

    }
    private void LateUpdate()
    {
        
    }
}
