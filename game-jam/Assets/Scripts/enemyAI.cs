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
    Vector3 randomNewPos;
    Rigidbody enemyRB;
    int time;
    int sceneTime;
    int timeOfMovment;
    bool canRandomlyMove = false;





    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        time = sceneTime + Random.Range(2,5);
        enemyRB = enemy.GetComponent<Rigidbody>();
        randomNewPos = new Vector3(enemy.transform.position.x + Random.Range(-5, 5), enemy.transform.position.y, enemy.transform.position.z + Random.Range(-5, 5)) - enemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        spotingPlayer();
        sceneTime = Mathf.RoundToInt(Time.timeSinceLevelLoad);

        if (isAgro && Vector3.Distance(enemy.transform.position, player.transform.position) > 2)
        {
            Vector3 newDirection = Vector3.RotateTowards(enemy.transform.forward, player.transform.position - enemy.transform.position, turnSpeed * Time.deltaTime, 0);
            //print(newDirection);
            enemy.transform.rotation = Quaternion.LookRotation(new Vector3(newDirection.x, 0, newDirection.z));
            enemyRB.velocity = enemy.transform.forward * moveSpeed;
            if (Vector3.Distance(enemy.transform.position, player.transform.position) > 2 * viewDistance)
            {
                isAgro = false;
                time = sceneTime + Random.Range(2, 5);
            }
        }
        else
        {
            if (time == sceneTime)
            {
                //print("can move");
                canRandomlyMove = true;
                timeOfMovment = sceneTime;
            }
        }
        randomMovment();
    }

    void randomMovment()
    {
        if (canRandomlyMove)
        {
            
            Vector3 newDirection = Vector3.RotateTowards(enemy.transform.forward, randomNewPos, turnSpeed * Time.deltaTime, 0);
            //print(newDirection);
            enemy.transform.rotation = Quaternion.LookRotation(new Vector3(newDirection.x, 0, newDirection.z));
            enemyRB.velocity = enemy.transform.forward * moveSpeed/3;
            if (timeOfMovment + 0.5f < sceneTime)
            {
                canRandomlyMove = false;
                time = sceneTime + Random.Range(2, 5);

                randomNewPos = new Vector3(enemy.transform.position.x + Random.Range(-5, 5), enemy.transform.position.y, enemy.transform.position.z + Random.Range(-5, 5)) - enemy.transform.position;
                
            }
        }
    }

    void spotingPlayer()
    {
        if (Physics.CheckSphere(enemy.transform.position, viewDistance, layer))
        {
            //print("enemy spoted");
            isAgro = true;
        }
    }
}
