using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private GameObject dialogueWindow;
    [SerializeField] private TextMeshProUGUI dialogueText;
    
    [SerializeField] private Button nextButton;
    [SerializeField] private Button beginDialogueButton;
    [SerializeField] private Button closeDialogueButton;

    [SerializeField] private string[] messages;
    private int _dialogueNumber;
    private GameObject _player;

    private void Start()
    {
        _dialogueNumber = 0;
    }

    private void Update()
    {
        closeDialogueButton.onClick.AddListener(ExitDialogue);
        beginDialogueButton.onClick.AddListener(TalkWith);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            _player = col.gameObject;

            dialogueWindow.SetActive(true);
            dialogueText.text = messages[_dialogueNumber];

            if (_dialogueNumber < messages.Length)
            {
                beginDialogueButton.gameObject.SetActive(true);
                nextButton.onClick.AddListener(NextDialogue);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            beginDialogueButton.gameObject.SetActive(false);
            dialogueWindow.SetActive(false);
            _dialogueNumber = 0;
            nextButton.onClick.RemoveAllListeners();
        }
    }

    private void NextDialogue()
    {
        _dialogueNumber++;
        dialogueText.text = messages[_dialogueNumber];
        if (_dialogueNumber == messages.Length - 1)
        {
            nextButton.gameObject.SetActive(false);
            closeDialogueButton.gameObject.SetActive(true);
        }
    }

    private void ExitDialogue()
    {
        if (_player != null) _player.GetComponent<PlatformerPlayer>().speed = 15f;
        closeDialogueButton.gameObject.SetActive(false);
        dialogueWindow.SetActive(false);
        nextButton.onClick.RemoveAllListeners();
        _dialogueNumber = 0;
    }

    private void TalkWith()
    {
        if (_player != null) _player.GetComponent<PlatformerPlayer>().speed = 0f;
        
        beginDialogueButton.gameObject.SetActive(false);

        if (_dialogueNumber < messages.Length)
        {
            nextButton.gameObject.SetActive(true);
        }
    }
}
