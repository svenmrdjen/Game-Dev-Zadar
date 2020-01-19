using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// RequireComponent automatically creates
// all the required components on the object
// when we put this script on it
[RequireComponent(typeof(NavMeshAgent))]
public class PointAndClick : MonoBehaviour
{
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                //print(hit.point);
                agent.SetDestination(hit.point);
            }
        }
    }
}
