using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Interact(PlayerInteract player);

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
