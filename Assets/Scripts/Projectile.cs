using UnityEngine;

// ova klasa pruža funkcionalnost projektila
public class Projectile : MonoBehaviour
{
    // pomoću SerializeField atributa možemo učiniti privatne varijable
    // vidljivima unutar inspectora
    // P.S. - ako promijeni vrijednost ove varijable unutar inspectora,
    // ta vrijednost će overwrite-ati vrijednost unutar skripte
    [SerializeField] private float projectileSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        // Destroy uništava zadani objekt
        // 2. parametar označava broj sekundi koji treba proći
        // prije nego se objekt uništi
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        // svaki frame mijenjamo poziciju objekta
        // transform.forward označava smjer u kojem se objekt kreće
        transform.position += transform.forward * projectileSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other) 
    {
        // destroy itself (projectile)
        Destroy(gameObject);
    }
}
