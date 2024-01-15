using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento lateral
    public float rotationSmoothness = 0.1f; // Suavidad del giro
    public float jumpForce = 8.0f; // Fuerza de salto
    public float gravity = 20.0f; // Gravedad aplicada al salto
    public float groundRaycastDistance = 0.2f; // Distancia de raycast para detectar el suelo
    private GroundSensor gs;

    private CharacterController characterController;
    private Vector3 moveDirection;
    private float ySpeed;

        //Salto
    [SerializeField] private float _alturaSalto = 1;
    private float _gravedad = -9.81f;
    private Vector3 _jugadorGravedad;
    [SerializeField] private Transform _posicionSensor;
    [SerializeField] private float _radioSensor = 0.2f;
    [SerializeField] private LayerMask _layerSuelo;
    public bool _isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gs = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
    }

    void Update()
    {
        HandleMovementInput();
        Salto();
    }

    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        moveDirection = new Vector3(horizontalInput, 0, 0);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        // Aplicar gravedad
        if (!characterController.isGrounded)
        {
            ySpeed -= gravity * Time.deltaTime;
        }
        else
        {
            ySpeed = -gravity * 0.5f; // Resetear la velocidad de caída cuando está en el suelo
        }

        moveDirection.y = ySpeed;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void Salto()
    {
        _isGrounded = Physics.CheckSphere(_posicionSensor.position, _radioSensor, _layerSuelo);

        if(_isGrounded && _jugadorGravedad.y < 0)
        {
            _jugadorGravedad.y = -2;
        }

        if(_isGrounded && Input.GetButtonDown("Jump"))
        {
            _jugadorGravedad.y = Mathf.Sqrt(_alturaSalto * -2 * _gravedad);
        }
        _jugadorGravedad.y += _gravedad * Time.deltaTime;
        characterController.Move(_jugadorGravedad * Time.deltaTime);
    }
}