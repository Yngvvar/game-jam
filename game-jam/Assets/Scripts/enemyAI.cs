using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    float viewDistance;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float turnSpeed;
    [SerializeField]
    LayerMask layer;
    [SerializeField]
    GameObject player;

    bool isAgro = false;
    Vector3 target;
    Vector3 newPosytion;
    Rigidbody enemyRB;






    // Start is called before the first frame update
    void Start()
    {
        enemyRB = enemy.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        spotingPlayer();

        if (isAgro && Vector3.Distance(enemy.transform.position, player.transform.position) > 2)
        {
            Vector3 newDirection = Vector3.RotateTowards(enemy.transform.forward, player.transform.position - enemy.transform.position, turnSpeed * Time.deltaTime, 0);
            print(newDirection);
            enemy.transform.rotation = Quaternion.LookRotation(new Vector3(newDirection.x, 0, newDirection.z));
            enemyRB.velocity = enemy.transform.forward * moveSpeed;
            if (Vector3.Distance(enemy.transform.position, player.transform.position) > 2 * viewDistance)
            {
                isAgro = false;
            }
        }
    }

    void spotingPlayer() {
        if (Physics.CheckSphere(enemy.transform.position, viewDistance, layer))
        {
            print("enemy spoted");
            isAgro = true;
        }
    }
}
