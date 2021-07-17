using UnityEngine;

public class DialogActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogObject dialogObject;

    public void UpdateDialogObject(DialogObject dialogObject)
    {
        this.dialogObject = dialogObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerMovement player)) //checks for player tag and component
        {
            player.Interactable = this;
        } 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerMovement player))
        {
            if(player.Interactable is DialogActivator dialogActivator && dialogActivator == this)
            {
                player.Interactable = null; // in the case that there r multiple activated, it makes sure that its null if its sure that its the current interactable
            }
        }
    }

    public void Interact(PlayerMovement player)
    {
        foreach(DialogResponseEvents responseEvents in GetComponents<DialogResponseEvents>())
        {
            if(responseEvents.DialogObject == dialogObject)
            {
                player.DialogUI.AddResponseEvents(responseEvents.Events);
                break;
            }
        }


        player.DialogUI.ShowDialog(dialogObject);
    }
}
