using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogResponseEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent Oldman1_1;

    [SerializeField] private GameObject dialogUI;

    [SerializeField] private DialogObj oldman1_1;
    [SerializeField] private DialogObj oldman1_2;
    [SerializeField] private DialogObj oldman2_1;

    public void Oldman1()
    {
        Interactable oldman = GameObject.Find("Old Man").GetComponent<Interactable>();
        oldman.dialogObj = oldman1_1;
        oldman.dialogEvent = Oldman1_1;
    }

    public void FuncOldman1_1()
    {
        if (Statics.coins < 1)
        {
            dialogUI.GetComponent<DialogUI>().ShowDialogue(oldman1_2, null);
        } else
        {
            dialogUI.GetComponent<DialogUI>().ShowDialogue(oldman2_1, null);
        }
    }
}
