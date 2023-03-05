using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionInteractable : MonoBehaviour, IInteractable
{
    #region Variables
    [SerializeField] private DialogObj dialogObj;
    [SerializeField] private GameObject dialogUI;
    #endregion

    public void Interact(PlayerInteract player)
    {
        dialogUI.GetComponent<DialogUI>().ShowDialogue(dialogObj);
        HandleCollection(player);
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

    private void HandleCollection(PlayerInteract player)
    {
        Debug.Log("Closing self");
        this.gameObject.SetActive(false);
    }
}
