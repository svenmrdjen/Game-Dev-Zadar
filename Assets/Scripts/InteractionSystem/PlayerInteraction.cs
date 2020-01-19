using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public LayerMask interactableLayer;
    public InteractionInputData interactionInputData;

    [SerializeField] float rayDistance = 2.5f;

    private Camera mainCamera;
    private RaycastHit hitInfo;

    private bool canInteract;

    Ray ray;
    bool hitSomething;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        hitSomething = Physics.Raycast(ray, out hitInfo, rayDistance, interactableLayer); // add layer mask later

        // DEBUG RAY
        Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * rayDistance, hitSomething ? Color.green : Color.red);

        canInteract = hitSomething;

        if (hitSomething)
        {
            UIManager.Instance.ChangeCrosshairs(Color.green);

            if (interactionInputData.HasInteracted)
            {
                Interact();
            }
        }
        else
        {
            UIManager.Instance.ChangeCrosshairs(Color.white);
        }
    }

    private void Interact()
    {
        Interactable hitObject = hitInfo.transform.GetComponent<Interactable>();

        if (hitObject != null)
        {
            hitObject.OnInteract();
        }
    }
}
