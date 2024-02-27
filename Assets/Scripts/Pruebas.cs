using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebas : MonoBehaviour
{
   /* public float speed = 5f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    public float parryCooldown = 1f;
    public float meleeRange = 2f;
    public LayerMask meleeLayer;
    private CharacterController characterController;
    private bool isDashing = false;
    private bool canParry = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

            if (moveDirection.x != 0)
            {
                StartCoroutine(Dash());
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && canParry)
        {
            StartCoroutine(ParryCooldown());

            // Verificar si hay un objetivo cercano para el parry melee
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, meleeRange, meleeLayer);
            if (hitColliders.Length > 0)
            {
                PerformMeleeParry(hitColliders[0]);
            }
            else
            {
                PerformRangedParry();
            }
        }
        else
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 moveVelocity = new Vector3(moveDirection.x * speed, 0f, moveDirection.z * speed);

        characterController.Move(moveVelocity * Time.deltaTime);
    }

    System.Collections.IEnumerator Dash()
    {
        isDashing = true;

        float originalSpeed = speed;
        speed = dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        speed = originalSpeed;
        isDashing = false;
    }

    void PerformMeleeParry(Collider target)
    {
    // Aquí puedes reproducir una animación melee
    // Puedes utilizar un Animator para controlar las animaciones.
    Animator playerAnimator = GetComponent<Animator>();
    playerAnimator.SetTrigger("MeleeParry");

    // Aplicar el golpe especial al objetivo
    EnemyController enemyController = target.GetComponent<EnemyController>();
    if (enemyController != null)
    {
        ApplySpecialMeleeAttack();
    }

    Debug.Log("Melee Parry and Special Attack!");
    }

    void PerformRangedParry()
    {
    // Detectar proyectiles cercanos
    Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5f);

    foreach (var collider in hitColliders)
    {
        // Verificar si el objeto es un proyectil
        if (collider.CompareTag("Proyectil"))
        {
            // Obtener dirección del proyectil hacia el jugador
            Vector3 directionToPlayer = (transform.position - collider.transform.position).normalized;

            // Calcular nueva dirección para reflejar el proyectil
            Vector3 reflectedDirection = Vector3.Reflect(directionToPlayer, Vector3.right).normalized;

            // Aplicar la nueva dirección al proyectil
            Rigidbody projectileRigidbody = collider.GetComponent<Rigidbody>();
            if (projectileRigidbody != null)
            {
                projectileRigidbody.velocity = reflectedDirection * projectileRigidbody.velocity.magnitude;
            }

            // Puedes agregar efectos visuales o sonoros aquí
            Debug.Log("Projectile Reflected!");
        }
    }

    Debug.Log("Ranged Parry and Projectile Reflection!");
    }*/
}
