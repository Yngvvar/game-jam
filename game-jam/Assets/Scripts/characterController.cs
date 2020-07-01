using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    [SerializeField]
    GameObject character;
    [SerializeField]
    float walkingSpeed = 12;
    [SerializeField]
    float dashPower = 5;
    [SerializeField]
    GameObject characterRepresentation;
    [SerializeField]
    GameObject characterGun;
    CharacterController characterCtrl;
    Vector3 mousePositionOnScreen;
    Vector2 walkingInput;
    Vector3 move;
    float dash;





    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindWithTag("Player");
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
        move = new Vector3(walkingInput.x, move.y, walkingInput.y) * walkingSpeed * Time.deltaTime * dash;



        if (!characterCtrl.isGrounded)
        {
            //if not grounded apply gravity
            move.y += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            move.y = 0;
        }
        //rotate character representation towards mouse cursor
        characterRepresentation.transform.LookAt(new Vector3(mousePositionOnScreen.x, character.transform.position.y, mousePositionOnScreen.z));
        characterGun.transform.LookAt(mousePositionOnScreen);
        characterCtrl.Move(move);
    }
    void getInput()
    {
        walkingInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        walkingInput = Vector3.ClampMagnitude(walkingInput, 1.0f);
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            mousePositionOnScreen = hit.point;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dash += dashPower;
        }
        else
        {
            dash -= 0.5f;
            dash = Mathf.Clamp(dash, 1, dashPower);
        }
    }

}
