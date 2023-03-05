using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectionInteractable : MonoBehaviour, IInteractable
{
    #region Variables
    [SerializeField] private DialogObj dialogObj;
    [SerializeField] private GameObject dialogUI;
    [SerializeField] private UnityEvent collectionHandler;
    #endregion

    public void Interact(PlayerInteract player)
    {
        dialogUI.GetComponent<DialogUI>().ShowDialogue(dialogObj, null);
        HandleCollection();
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

    private void HandleCollection()
    {
        Statics.coins += 1;
        Debug.Log(Statics.coins);
        this.gameObject.SetActive(false);
    }
}
