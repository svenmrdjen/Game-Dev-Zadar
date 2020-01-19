using UnityEngine;

public class LightSwitch : Interactable
{
    public GameObject pointLight;

    public override void OnInteract()
    {
        pointLight.SetActive(!pointLight.activeSelf); // toggle
    }
}
