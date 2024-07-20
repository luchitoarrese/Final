using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootCannon : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform firePoint; // Punto de disparo (donde aparecerá la bala)
    public float bulletSpeed = 10f; // Velocidad de la bala
    public LayerMask player;
    RaycastHit2D hit;
    [SerializeField] float distance;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        hit = Physics2D.Raycast(transform.position, Vector3.left, distance, player);

        if(hit)
        {
            animator.SetBool("Atack", true);
        }
        else
        {
            animator.SetBool("Atack", false);
        }
       
    }

    

    void Shoot()
    {
        // Crea la bala en la posición y rotación del punto de disparo
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-bulletSpeed, 0); // Establece la velocidad de la bala hacia la izquierda
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * distance);
    }
}
