using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// potrebno je dodati ovaj namespace kako bi se moglo raditi s NavMesh funkcionalnostima
using UnityEngine.AI;

// RequireComponent automatically creates
// all the required components on the object
// when we put this script on it
[RequireComponent(typeof(NavMeshAgent))]
// ova klasa pruža funkcionalnost praćenja objekta kojeg zadamo
public class RunningEnemy : MonoBehaviour
{
    public GameObject target;

    // objekt koji će vlasnik ove skripte pratiti
    // kada dohvatimo cijeli player gameObject,
    // preko njega ćemo moći dohvatiti i njegovu poziciju
    private GameObject player;
    
    // komponenta potrebna za pozivanje naredbe za praćenje
    private NavMeshAgent agent;

    private Animator animator;

    [SerializeField] private float maxDistance = 6;

    // Start is called before the first frame update
    void Start()
    {
        // dohvaćamo NavMeshAgent komponentu
        agent = GetComponent<NavMeshAgent>();

        // dohvaćamo objekt s tagom "Player", koji se nalazi u sceni
        player = GameObject.FindWithTag("Player");

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3.Distance vraća udaljenost između 2 objekta
        if (Vector3.Distance(transform.position, player.transform.position) < maxDistance) {
            // ako je udaljenost manja od 4 unita, počni pratiti Playera
            MoveToLocation();            
        }       

        // ako je brzina neprijatelja veća od 0, pokreni animaciju trčanja
        // inače, pokreni animaciju mirovanja
        if (agent.velocity.magnitude > 0)
        {
            animator.SetBool("isChasing", true);    
        }
        else
        {
            animator.SetBool("isChasing", false);
        }
    }

    private void MoveToLocation()
    {
        // AI-u zadajemo destinaciju, u ovom slučaju zadajemo poziciju Playera
        agent.SetDestination(player.transform.position);
    }
}
