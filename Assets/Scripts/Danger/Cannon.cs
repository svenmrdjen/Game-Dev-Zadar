using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform muzzle;
    public GameObject projectile;

    private GameObject player;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float shootingTimer = 2f;
    private float currentTimer;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");

        currentTimer = shootingTimer;
    }

    // kada imamo i znamo igračevu poziciju pomoću transforma
    // možemo usmjeriti top prema igraču
    private void Update()
    {
        Vector3 targetDirection = player.transform.position - transform.position;

        float singleStep = speed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0f);

        transform.rotation = Quaternion.LookRotation(newDirection);

        currentTimer -= Time.deltaTime;

        // top ispucava projektile svake 2 sekunde
        if (currentTimer <= 0)
        {
            ShootProjectile();
            currentTimer = shootingTimer;
        }
    }

    private void ShootProjectile()
    {
        Instantiate(projectile, muzzle.position, muzzle.rotation);
    }
}
