using UnityEngine;

public class Goal : MonoBehaviour
{
    Pickup[] pickups;

    private void Start() 
    {
        // pronalazi sve novčiće i sprema ih u pickup array
        pickups = GameObject.FindObjectsOfType<Pickup>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // provjeri score (je li jednak uk. broju novčića)
            // ako je jednak, prijeđi na sljedeći level
            if (ScoreManager.Instance.Score == pickups.Length)
            {
                LevelManager.Instance.GoToNextScene();
            }
            else
            {
                print("You didn't collect all the coins!");
            }
        }
    }
}
