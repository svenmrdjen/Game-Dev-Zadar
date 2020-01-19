using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ova skripta omogućuje kretanje pomoću Rigidbody AddForce metode
public class RBMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontalAxis;
    private float verticalAxis;
    [SerializeField] private float jumpPower = 40f;
    [SerializeField] private float movementSpeed = 10f;

    private GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        // pomoću GetComponent-a možemo dohvatiti komponentu 
        // potrebno je proslijediti točno ime komponente koju želimo
        // P.S. - GetComponent može dohvatiti SAMO komponente koje
        // se nalaze na objektu na kojemu se nalazi i ova skripta
        rb = GetComponent<Rigidbody>();

        spawnPoint = GameObject.FindGameObjectWithTag("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis vraća vrijednosti od -1 do 1
        // ovisno o tipki koju je igrač pritisnuo
        // npr. lijeva strelica vraća rezultat -1
        // desna strelica vraća rezultat 1
        // ako igrač ne drži ni jednu tipku, vraća rezultat 0
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        // registracija inputa treba biti unutar Update metode
        // kako se ne bi dogodilo da se input ponekad ne registrira,
        // što se može dogoditi ako se registracija izvršava
        // unutar FixedUpdate metode
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    // fizičke kalkulacija trebaju biti unutar FixedUpdate metode
    // kako bi bile sinkronizirane s Unityjevim fizičkim engine-om
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // stvaramo Vector3 koji predstavlja smjer u kojem će AddForce djelovati
        // Vector3 predstavlja 3 vrijednosti: x, y i z
        Vector3 movementVector = new Vector3(horizontalAxis,0,verticalAxis);

        // osigurava da kretanje ne bude brže ako se igrač kreće dijagonalno
        movementVector.Normalize();

        rb.AddForce(movementVector * movementSpeed);
    }

    private void Jump()
    {
        rb.AddForce(new Vector3(0,10f,0) * jumpPower);
    }

    // respawn je ništa drugo nego obična teleportacija
    // dakle, samo je potrebno promijeniti transform.position vrijednosti
    public void Respawn()
    {
        // repozicioniramo objekt na poziciju spawnPointa
        transform.position = spawnPoint.transform.position;
    }
}
