using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private bool isInRange;

    private Text interractUI;

    private void Awake() 
    {
            interractUI = GameObject.FindGameObjectWithTag("InterractUI").GetComponent<Text>();
            interractUI.enabled = false;
    }
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {          
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interractUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interractUI.enabled = false;
            DialogueManager.instance.EndDialogue();
        }
    }

    void TriggerDialogue()
    { 
        DialogueManager.instance.StartDialogue(dialogue);
    }

}
