using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public AudioClip explosion;
    private AudioSource AudioSource;
    private CameraShake cm;
    public float Timer=3;
    [SerializeField] bool Ativate=false;
    private Animator am;
    
    [SerializeField] float radio;
    [SerializeField] float FuerzaExplosion;
    void Start()
    {
        cm = GameObject.Find("Camera").GetComponent<CameraShake>();
        am = GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();
        StartCoroutine(Explot());
        
    }

    // Update is called once per frame
    void Update()
    {
       
            
        
       
    }

    IEnumerator Explot()
    {
        
        yield return new WaitForSeconds(3);
        am.SetBool("Explot", true);
        cm.Shake();
        Explosion();
       
    }

    public void Destroy()
    {
       
       Destroy(this.gameObject);
    }

    public void Explosion()
    {
        AudioSource.PlayOneShot(explosion, 1.0f);

        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radio);
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in objects)
        {
            
        }

        foreach (Collider2D collisionador in objetos)
        {
            if(collisionador.CompareTag("Enemy"))
            {
                Destroy(collisionador.gameObject);
            }

            Rigidbody2D rb2D = collisionador.GetComponent<Rigidbody2D>();
            if(rb2D != null)
            {
                Vector2 direccion = collisionador.transform.position - transform.position;
                float distancia= 1 + direccion.magnitude;
                float fuerzaFinal = FuerzaExplosion / distancia;
                rb2D.AddForce(direccion * fuerzaFinal);
            }
        }

   
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }


}
