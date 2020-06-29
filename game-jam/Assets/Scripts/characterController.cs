using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    [SerializeField]
    GameObject character;
    [SerializeField]
    float walkingSpeed;
    CharacterController characterCtrl;
    Vector2 mouseInput;
    Vector2 walkingInput;
    Vector3 move;

    



    // Start is called before the first frame update
    void Start()
    {
        characterCtrl = character.GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        movePlayer();
    }
    void Update()
    {
        getInput();
    }

    void movePlayer()
    {
        move = new Vector3(walkingInput.x, 0, walkingInput.y) * walkingSpeed * Time.deltaTime;
        if (!characterCtrl.isGrounded)
        {
            move.y += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            move.y = 0;
        }
        characterCtrl.Move(move);
    }
    void getInput()
    {
        walkingInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        walkingInput = Vector3.ClampMagnitude(walkingInput, 1.0f);
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

}
