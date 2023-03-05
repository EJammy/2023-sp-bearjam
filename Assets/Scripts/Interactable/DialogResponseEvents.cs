using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogResponseEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent OldmanUE1_1;
    [SerializeField] private UnityEvent OldmanUE2_2;
    [SerializeField] private UnityEvent OldmanUE2_3;
    [SerializeField] private UnityEvent OldmanUE2_5;

    [SerializeField] private GameObject dialogUI;

    [SerializeField] private DialogObj oldman1_1;
    [SerializeField] private DialogObj oldman1_2;
    [SerializeField] private DialogObj oldman2_1;
    [SerializeField] private DialogObj oldman2_2;
    [SerializeField] private DialogObj oldman2_3;
    [SerializeField] private DialogObj oldman2_4;
    [SerializeField] private DialogObj oldman2_5;

    [SerializeField] private DialogObj altar2;

    public void Oldman1()
    {
        Interactable oldman = GameObject.Find("Old Man").GetComponent<Interactable>();
        oldman.dialogObj = oldman1_1;
        oldman.dialogEvent = OldmanUE1_1;
    }

    public void FuncOldman1_1()
    {
        int price = 1;
        if (Statics.coins < price)
        {
            dialogUI.GetComponent<DialogUI>().ShowDialogue(oldman1_2, null);
        } else
        {
            dialogUI.GetComponent<DialogUI>().ShowDialogue(oldman2_1, null);
            Statics.hasPick = true;
            Statics.coins -= price;
            Interactable oldman = GameObject.Find("Old Man").GetComponent<Interactable>();
            oldman.dialogObj = oldman2_2;
            oldman.dialogEvent = OldmanUE2_2;
        }
    }

    public void FuncOldman2_2()
    {
        Interactable oldman = GameObject.Find("Old Man").GetComponent<Interactable>();
        oldman.dialogObj = oldman2_3;
        oldman.dialogEvent = OldmanUE2_3;
    }

    public void FuncOldman2_3()
    {
        int price = 1;
        if (Statics.coins < price)
        {
            dialogUI.GetComponent<DialogUI>().ShowDialogue(oldman2_4, null);
        }
        else
        {
            dialogUI.GetComponent<DialogUI>().ShowDialogue(oldman2_5, OldmanUE2_5);
            Statics.hasKnife = true;
            Statics.coins -= price;
        }
    }

    public void FuncOldman2_5()
    {
        GameObject.Find("Old Man").SetActive(false);
    }

    public void Altar1()
    {
        if (Statics.hasKnife)
        {
            GameObject.Find("SceneManager").GetComponent<TransitionManager>().EndScene();
        } else
        {
            dialogUI.GetComponent<DialogUI>().ShowDialogue(altar2, null);
        }
    }
}
