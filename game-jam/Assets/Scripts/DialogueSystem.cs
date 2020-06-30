using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text NPCName;
    public Text currentText;

    public Animator myAnimator;

    private Queue<string> dialog;

    // Start is called before the first frame update
    void Start()
    {
        dialog = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(Dialogue data)
    {
        myAnimator.SetBool("IsOpen", true);

        NPCName.text = data.name;

        dialog.Clear();

        foreach(string text in data.sentences)
        {
            dialog.Enqueue(text);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(dialog.Count == 0)
        {
            EndDialogue();
            return;
        }

        string text = dialog.Dequeue();
        currentText.text = text;
    }

    public void EndDialogue()
    {
        myAnimator.SetBool("IsOpen", false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
