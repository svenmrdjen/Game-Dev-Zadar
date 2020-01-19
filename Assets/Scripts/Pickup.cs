using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void Update()
    {
        // rotacija objekta oko svoje osi
        // prvi parametar - centar rotacije
        // drugi parametar - os oko koje se rotira
        // treći parametar - brzina rotacije
        transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * 90f);
    }

    // kada neki objekt uđe u trigger, izvršava se zadani event
    private void OnTriggerEnter(Collider other)
    {
        // provjeravamo je li objekt koji je ušao u trigger "Player"
        // ako je, izvrši sljedeće linije koda unutar if statement-a
        // ako nije, ignoriraj ga
        // ovime osiguravamo da samo igrač može skupiti pickup,
        // ali ne i ostali objekti unutar scene
        // P.S. - ne zaboravi namjestiti tag unutar inspectora
        if (other.tag == "Player")
        {
            // poziva UpdateScore metodu na ScoreManageru
            // ScoreManager zatim povećava bodove za 1
            ScoreManager.Instance.IncreaseScore();

            // uništava pickup nakon što ga je igrač pokupio
            Destroy(gameObject); 
        }
    }
}
