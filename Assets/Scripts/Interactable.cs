using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    #region Variables
    [SerializeField] private DialogObj dialogObj;
    [SerializeField] private GameObject dialogUI;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Interact(PlayerInteract player)
    {
        dialogUI.GetComponent<DialogUI>().ShowDialogue(dialogObj);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInteract player = collision.gameObject.GetComponent<PlayerInteract>();
            player.displayInteractKey();
            player.interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInteract player = collision.gameObject.GetComponent<PlayerInteract>();
            player.closeInteractKey();
            if (player.interactable == this)
            {
                player.interactable = null;
            }
        }
    }
}
