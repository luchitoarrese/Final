using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class WhalePatrowl : MonoBehaviour
{
    [SerializeField] float speed;
    private float axisX, axisY;
    private Rigidbody body;
    [SerializeField] int rutina;
    [SerializeField] int direccion;
    [SerializeField] float cronometro;
    RaycastHit2D lefthit;
    RaycastHit2D righthit;
    public LayerMask capaBomb;
    [SerializeField] float longitud;
    [SerializeField] bool detected=false;
    [SerializeField] bool left, right;
    private Animator am;
    public GameObject SPlayer;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        am = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Runner();
        lefthit = Physics2D.Raycast(transform.position, Vector3.left, capaBomb);


        righthit = Physics2D.Raycast(transform.position, Vector3.right, capaBomb);

        if(lefthit==true && left== true)
        {     
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);   
            
        }
        
        if(righthit==true && right== true)
        {        
                 transform.Translate(Vector3.right * speed * Time.deltaTime);
                 transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * longitud);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * longitud);
    }


    public void Runner()
    {
        cronometro += 1 * Time.deltaTime;
        if(cronometro >= 2)
        {
         rutina = Random.Range(0, 2);
            cronometro = 0;
        }
        
        switch (rutina)
        {
            case 0:
                am.SetBool("Runner", false);
                
                break;
            case 1:
                direccion = Random.Range(0, 2);
                rutina++;
                break;
            case 2:

                switch (direccion)
                {
                    case 0:
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        transform.Translate(Vector3.right * speed * Time.deltaTime);
                        left=false;
                        right=true;
                        break;
                    case 1:
                        transform.rotation = Quaternion.Euler(0, 180, 0);                 
                        transform.Translate(Vector3.right * speed * Time.deltaTime);
                        left = true;
                        right = false;
                        break;

                }
                am.SetBool("Runner", true);
                break;
        }
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bomb"))
        {

            am.SetBool("Eating", true);
            Destroy(collision.gameObject);

        }
    }

    public void Pased()
    {
        am.SetBool("Eating", false);
    }

}


