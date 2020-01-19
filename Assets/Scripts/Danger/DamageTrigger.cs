using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // "other" se referencira na objekt koji je ušao u ovaj trigger
            // u ovom slučaju, "other" je Player
            // preko "other" možemo pomoću "." dohvatiti "gameObject"
            // preko "gameObject" zatim možemo dohvatiti skriptu
            // i zatim na njoj možemo pozvati Respawn metodu
            other.gameObject.GetComponent<RBMovement>().Respawn();
        }
    }
}
