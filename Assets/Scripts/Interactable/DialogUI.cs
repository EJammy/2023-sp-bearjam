using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogObj testDialog;
    public bool isOpen { get; private set; }

    private TypewriterEffect typewriterEffect;

    private Coroutine currDialogCoroutine;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        isOpen = false;
        dialogBox.SetActive(false);
        textLabel.text = string.Empty;
    }

    public void ShowDialogue(DialogObj dialogObj, UnityEvent dialogEvent)
    {
        isOpen = true;
        Statics.hasControl = false;
        Statics.player.GetComponent<PlayerInteract>().closeInteractKey();
        dialogBox.SetActive(true);
        currDialogCoroutine = StartCoroutine(stepThroughDialog(dialogObj, dialogEvent));
    }

    private IEnumerator stepThroughDialog(DialogObj dialogObj, UnityEvent dialogEvent)
    {
        foreach (string dialog in dialogObj.Dialogue)
        {
            yield return RunTypingEffect(dialog);
            textLabel.text = dialog;
            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        CloseDialogBox();

        if (dialogEvent != null)
        {
            Debug.Log("Involing event");
            dialogEvent.Invoke();
        }
    }

    private IEnumerator RunTypingEffect(string dialog)
    {
        typewriterEffect.Run(dialog, textLabel);

        while (typewriterEffect.IsRunning)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                typewriterEffect.Stop();
            }
        }
    }

    private void CloseDialogBox()
    {
        isOpen = false;
        Statics.hasControl = true;
        dialogBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
