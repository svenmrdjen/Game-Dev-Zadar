using UnityEngine;

[CreateAssetMenu(fileName = "InteractionInputData", menuName = "Data/InteractionInputData", order = 1)]
public class InteractionInputData : ScriptableObject
{
    private bool hasInteracted;

    public bool HasInteracted
    {
        get => hasInteracted;
        set => hasInteracted = value;
    }

    public void ResetInput()
    {
        hasInteracted = false;
    }
}
