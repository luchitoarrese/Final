using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PatrowlPirat : MonoBehaviour
{
    public Rigidbody2D rb2d;
    RaycastHit2D rchit;
    RaycastHit2D rhit;
    [SerializeField] float distance;
    public LayerMask capaJugador;
    [SerializeField] bool Patrowl=false;
    public GameObject PlayerM;
    Vector2 Enemypos;
    [SerializeField] bool seguir=false;
    [SerializeField] float speed;
    private Animator anim;
    [SerializeField] bool Atack=false;
    public GameObject AtackHit;
    public GameObject Star;
    public string orderLevel;
  
    void Start()
    {
        anim = GetComponent<Animator>();  
        orderLevel = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
        
            rchit = Physics2D.Raycast(transform.position, Vector3.right, distance, capaJugador);
            rhit = Physics2D.Raycast(transform.position, Vector3.left, distance, capaJugador);

        if (rchit == true && Patrowl == false)
        {
            anim.SetBool("Run", true);
        
            if(Atack == false)
            { 
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            }

            if(rchit == false && rhit == false)
             {
            anim.SetBool("Run", false);
              }


            if (rhit == true && Patrowl == true)
            {
                anim.SetBool("Run", true);
            if (Atack == false)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            }





        if (Mathf.Abs(transform.position.x - PlayerM.transform.position.x) < 1 && rhit || Mathf.Abs(transform.position.x - PlayerM.transform.position.x) < 1 && rchit)
        {
            anim.SetBool("Atack", true);
            Atack = true;
        }
        else
        {
            anim.SetBool("Atack", false);
            Atack =false;
        }


        
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * distance);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * distance);
    }
    private void OnDestroy()
    {
        if(SceneManager.GetActiveScene().isLoaded && gameObject.scene.isLoaded)
        Instantiate(Star, transform.position, transform.rotation);
    }

    public void TurnLeft()
    {
        Patrowl=true;
    }
    public void TurnRight()
    {
        Patrowl=false;
    }

   public void Taking()
    {
        AtackHit.SetActive(true);
    }
    public void Life()
    {
        AtackHit.SetActive(false);
    }
}
