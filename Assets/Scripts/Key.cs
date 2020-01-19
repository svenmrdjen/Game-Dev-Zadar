using UnityEngine;

public class Key : Interactable
{
    public override void OnInteract()
    {
        base.OnInteract();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Inventory>().GetKey();
        
        Destroy(gameObject);
    }
}
