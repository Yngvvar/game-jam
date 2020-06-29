using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    [SerializeField]
    GameObject character;
    [SerializeField]
    float walkingSpeed;
    [SerializeField]
    GameObject characterRepresentation;
    CharacterController characterCtrl;
    Vector3 mousePositionOnScreen;
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
            //if not grounded apply gravity
            move.y += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            move.y = 0;
        }
        characterRepresentation.transform.LookAt(mousePositionOnScreen);
        characterCtrl.Move(move);
    }
    void getInput()
    {
        walkingInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        walkingInput = Vector3.ClampMagnitude(walkingInput, 1.0f);

        //print(Input.mousePosition.normalized);
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            mousePositionOnScreen = hit.point;
            
        else
            print("I'm looking at nothing!");
            
    }

}
