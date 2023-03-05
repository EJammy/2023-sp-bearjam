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
        dialogUI.GetComponent<DialogUI>().ShowDialogue(dialogObj, null);
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
        Statics.coins += 1;
        Debug.Log(Statics.coins);
        this.gameObject.SetActive(false);
    }
}
