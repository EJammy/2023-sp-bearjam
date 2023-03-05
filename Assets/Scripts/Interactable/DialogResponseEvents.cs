using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogResponseEvents : MonoBehaviour
{
    [SerializeField] private GameObject dialogUI;

    [SerializeField] private DialogObj dialogue1;
    [SerializeField] private DialogObj dialogue2;
    public void testEvent()
    {
        Debug.Log("event activating");
        dialogUI.GetComponent<DialogUI>().ShowDialogue(dialogue2, null);
    }
}
