using UnityEngine;

[CreateAssetMenu(fileName = "MovementInputData", menuName = "Data/MovementInputData", order = 1)]
public class MovementInputData : ScriptableObject
{
    private Vector2 inputVector;
    private bool jumpClicked;
    private bool jumpReleased;

    public Vector2 InputVector => inputVector;

    public float InputVectorX
    {
        set => inputVector.x = value;
    }

    public float InputVectorY
    {
        set => inputVector.y = value;
    }

    public void ResetInput()
    {
        inputVector = Vector2.zero;
    }
}
