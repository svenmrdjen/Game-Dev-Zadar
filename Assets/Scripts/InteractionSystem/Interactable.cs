using UnityEngine;

public class Interactable : MonoBehaviour, IInteract
{
    // virtual znači da child klasa koja naslijedi ovu klasu
    // može OnInteract metodi promijeniti funkcionalnost
    public virtual void OnInteract()
    {
        Debug.Log("Interacted with: " + gameObject.name);
    }
}
