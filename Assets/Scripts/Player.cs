using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    //private Animator _anim;
    private Transform _camera;

    //Movimiento
    private float _horizontal;
    private float _vertical;
    [SerializeField] private float _vel = 5;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    //Salto
    [SerializeField] private float _alturaSalto = 1;
    private float _gravedad = -35f;
    private Vector3 _jugadorGravedad;
    [SerializeField] private Transform _posicionSensor;
    [SerializeField] private float _radioSensor = 0.2f;
    [SerializeField] private LayerMask _layerSuelo;
    public bool _isGrounded;

    //Ataque
    public float damage = 10f;
    public LayerMask enemyLayer;
    public float attackRadius = 1.5f;

    //Dash
    public float dashDistance = 5f;
    public float dashDuration = 0.5f;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        //_anim = GetComponentInChildren<Animator>();
        _camera = Camera.main.transform;
    }

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        //_vertical = Input.GetAxisRaw("Vertical");
        Movimiento();
        
        Salto();
        //_anim.SetBool("isJumping",!_isGrounded);

        if (Input.GetButtonDown("Fire1"))
        {
            PerformAttack();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            PerformDash();
        }
    
    }

    void Movimiento()
    {
        Vector3 _direccion = new Vector3 (_horizontal, 0, 0);

        //_anim.SetFloat("VelX",0);
        //_anim.SetFloat("VelZ", _direccion.magnitude);

        if(_direccion != Vector3.zero)
        {
            float _targetAngle = Mathf.Atan2(_direccion.x, _direccion.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            float _smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0,_smoothAngle,0);
            Vector3 _moveDirection = Quaternion.Euler(0, _targetAngle, 0) * Vector3.forward;
            _controller.Move(_moveDirection.normalized * _vel * Time.deltaTime);
        }
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
        _controller.Move(_jugadorGravedad * Time.deltaTime);
    }

   void PerformAttack()
    {
        //animator.SetTrigger("Attack");

       Collider[] enemies = Physics.OverlapSphere(transform.position, attackRadius, enemyLayer);

        foreach (Collider enemy in enemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    void PerformDash()
    {
        Vector3 finalPosition = transform.position + transform.forward * dashDistance;

        StartCoroutine(Dash(finalPosition, dashDuration));
    }

    IEnumerator Dash(Vector3 finalPosition, float duration)
    {
        float startTime = Time.time;
        float completionPercentage = 0f;

        while (completionPercentage < 1f)
        {
            completionPercentage = (Time.time - startTime) / duration;
            transform.position = Vector3.Lerp(transform.position, finalPosition, completionPercentage);
            yield return null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
    
}