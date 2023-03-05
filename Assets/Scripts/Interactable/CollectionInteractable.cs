using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectionInteractable : MonoBehaviour, IInteractable
{
    #region Variables
    [SerializeField] private DialogObj dialogObj;
    [SerializeField] private GameObject dialogUI;
    [SerializeField] private CollectionInteractable.CollectableType collectableType;
    #endregion

    public void Interact(PlayerInteract player)
    {
        dialogUI.GetComponent<DialogUI>().ShowDialogue(dialogObj, null);
        Debug.Log(collectableType);
        switch(collectableType)
        {
            case CollectableType.Coin: CollectCoin(); break;
            case CollectableType.Flashlight: CollectFlashlight(); Debug.Log("Collected flashlight"); break;
        }
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

    private void CollectCoin()
    {
        Statics.coins += 1;
        gameObject.SetActive(false);
    }

    private void CollectFlashlight()
    {
        Statics.player.GetComponent<PlayerFlashlight>().SetOn();
        gameObject.SetActive(false);
    }

    private enum CollectableType
    {
        Coin = 0,
        Flashlight = 1,
    }
}
