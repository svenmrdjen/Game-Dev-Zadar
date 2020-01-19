using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCMovement : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundMask;

    [Space, Header("Data")]
    [SerializeField] private MovementInputData movementInputData;

    CharacterController controller;

    [SerializeField] private float movementSpeed = 12f;
    [SerializeField] private float jumpHeight = 3f;

    private Vector3 velocity;
    private float gravity = -9.81f;
    private float groundDistance = 0.25f;
    private bool isGrounded;

    private float horizontal;
    private float vertical;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // -2, a ne 0, jer bi checksphere mogao registrirati prije nego igrač dotakne tlo
        }

        horizontal = movementInputData.InputVector.x;
        vertical = movementInputData.InputVector.y;

        direction = transform.right * horizontal + transform.forward * vertical;

        // ne koristimo verziju ispod jer ona koristi globalne koordinate
        // igrač bi se kretao uvijek u istom smjeru, neovisno o smjeru prema kojem je tijelo okrenuto

        //Vector3 direction = new Vector3(horizontal, 0, vertical); 

        // osiguravamo da se ne kreće brže dijagonalno
        direction.Normalize();

        // kretanje igrača lijevo-desno, naprijed-nazad
        controller.Move(direction * movementSpeed * Time.deltaTime);

        Jump();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity); // korijen iz -2gh
        }

        velocity.y += gravity * Time.deltaTime;

        // kretanje igrača prema dolje (gravitacija)
        controller.Move(velocity * Time.deltaTime);
    }
}
