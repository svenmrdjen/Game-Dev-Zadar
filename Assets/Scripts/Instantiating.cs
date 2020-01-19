using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiating : MonoBehaviour
{
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnProjectile(); 
        }
    }

    void SpawnProjectile() 
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
