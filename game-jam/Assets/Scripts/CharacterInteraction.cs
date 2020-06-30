using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterInteraction : MonoBehaviour
{
    public Animator interactText;

    GameObject nearestInteractionObject = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nearestInteractionObject != null)
        {
            if(Input.GetKeyUp(KeyCode.F))
            {
                nearestInteractionObject.GetComponent<NPC>().TriggerDialogue();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "npc")
        {
            interactText.SetBool("IsOpen", true);
            nearestInteractionObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        nearestInteractionObject = null;
        interactText.SetBool("IsOpen", false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "portal")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
