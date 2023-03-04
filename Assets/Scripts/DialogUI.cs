using System.Collections;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogObj testDialog;
    public bool isOpen { get; private set; }

    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogBox();
    }

    public void ShowDialogue(DialogObj dialogObj)
    {
        isOpen = true;
        Statics.hasControl = false;
        Statics.player.GetComponent<PlayerInteract>().closeInteractKey();
        dialogBox.SetActive(true);
        StartCoroutine(stepThroughDialog(dialogObj));
    }

    private IEnumerator stepThroughDialog(DialogObj dialogObj)
    {
        foreach (string dialog in dialogObj.Dialogue)
        {
            yield return typewriterEffect.Run(dialog, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        CloseDialogBox();
    }

    private void CloseDialogBox()
    {
        isOpen = false;
        Statics.hasControl = true;
        if (Statics.player != null)
            Statics.player.GetComponent<PlayerInteract>().displayInteractKey();
        dialogBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
