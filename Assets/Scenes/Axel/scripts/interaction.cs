using UnityEngine;
using UnityEngine.InputSystem;

public class interaction : MonoBehaviour
{
    public Vector2 size;
    public LayerMask mask;
    public PlayerMovement playerMovement;

    private Transform playerTransform;

    private void Update()
    {
        if(playerMovement.isWizard)
        {
            playerTransform = playerMovement.wizard.transform;
        }
        else
        {
            playerTransform = playerMovement.firefly.transform;
        }
    }

    public void Interact(InputAction.CallbackContext ctx)
    {
        Debug.Log("Began if");

        if (ctx.ReadValue<float>() == 0)
            return;

        RaycastHit2D hit = Physics2D.BoxCast(playerTransform.position, size, 0, Vector2.zero, 0, mask);

        Debug.Log("Ray Cast");

        if (hit && hit.collider.TryGetComponent(out interactable Interactable))
        {
            if((playerMovement.isWizard && Interactable.type.HasFlag(interactable.PlayerType.Wizard)) || (!playerMovement.isWizard && Interactable.type.HasFlag(interactable.PlayerType.Firefly)))
            {
                Debug.Log("invoked interact");
                Interactable.onInteract.Invoke();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(playerTransform.position, size);
    }
}
