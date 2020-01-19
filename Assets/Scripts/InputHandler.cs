using UnityEngine;

public class InputHandler : MonoBehaviour
{
    #region Data
        [Space,Header("Input Data")]
        [SerializeField] private MovementInputData movementInputData;
        [SerializeField] private InteractionInputData interactionInputData;
    #endregion

    private void Start() 
    {
        movementInputData.ResetInput();
        interactionInputData.ResetInput();
    }

    private void Update() 
    {
        GetMovementInputData();
        GetInteractionInputData();
    }

    private void GetMovementInputData()
    {
        movementInputData.InputVectorX = Input.GetAxisRaw("Horizontal");
        movementInputData.InputVectorY = Input.GetAxisRaw("Vertical");
    }

    private void GetInteractionInputData()
    {
        interactionInputData.HasInteracted = Input.GetKeyDown(KeyCode.E);
    }
}
