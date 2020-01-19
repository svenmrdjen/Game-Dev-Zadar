using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") 
        {
            if (other.gameObject.GetComponent<Inventory>().HasKey)
            {
                gameObject.SetActive(false);
            }
            else
            {
                print("You don't have a key!");
            }
        }
    }
}
