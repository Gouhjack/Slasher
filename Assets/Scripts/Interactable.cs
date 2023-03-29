using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 3f;
    public Transform interactionTransform;
    public bool isFocus = false;
    private Transform player;
    private bool hasInteracted = false;

    private void Update()
    {
        if (isFocus && !hasInteracted) 
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius) 
            {
                Debug.Log("INTERACT");
                Interact();
                hasInteracted = false;
            }
        }
    }

    public virtual void Interact()
    {
        // THIS METHOD IS MEANT TO BE OVERWRITTEN
        Debug.Log("Interacting with" + transform.name);
    }
    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

}
