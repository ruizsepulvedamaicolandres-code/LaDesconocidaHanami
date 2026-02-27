using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject hudPlayerPanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField,TextArea(4,6)] private string[] dialogueLines;
    [SerializeField] private float textSpeed;

    private bool rangePlayer = false;
    private bool isDialogueActive = false;
    private int lineIndex;
    void Update()
    {
        if (rangePlayer == true && Input.GetKeyDown(KeyCode.F))
        {
            if (isDialogueActive == false)
            {
                StartDialogue();
            }
            else if(dialogueText.text == dialogueLines[lineIndex])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    private void StartDialogue()
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        hudPlayerPanel.SetActive(false);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextLine()
    {
      lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            isDialogueActive = false;
            dialoguePanel.SetActive(false);
            dialogueMark?.SetActive(true);
            hudPlayerPanel.SetActive(true);
        }
    }
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(textSpeed);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rangePlayer = true; 
            dialogueMark.SetActive(true);
           
        }
    }

  

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rangePlayer = false;
            dialogueMark.SetActive(false);
            
        }

    }
}
