using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [Range(0, 10)][SerializeField] float speed; 
    private float axisX, axisY;
    [Range(0, 10)][SerializeField] float Jump;
    private Rigidbody2D rb;
    [SerializeField] bool Scaner=true;
    private Animator an;
    public GameObject Bombprefab;
    public Transform spawn;
    [SerializeField] int points;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    [SerializeField] bool pass=true;
    public GameObject OpenDoor;
    private string resetLevel;
    public string nextLevel;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        resetLevel = SceneManager.GetActiveScene().name;
    }

    
    void Update()
    {
        if (pass)
        {


            axisX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(axisX * speed, rb.velocity.y);
            if (axisX > 0) transform.localScale = new Vector2(1, 1);
            else if (axisX < 0) transform.localScale = new Vector2(-1, 1);
            if (axisX != 0) an.SetBool("Running", true);
            else if (axisX == 0) an.SetBool("Running", false);
            if (Input.GetKeyDown(KeyCode.W) && Scaner == true)
            {
                rb.AddForce(new Vector2(0, Jump), ForceMode2D.Impulse);
                Scaner = false;
                an.SetBool("Jumping", true);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject bomb = Instantiate(Bombprefab, new Vector2(spawn.transform.position.x, spawn.transform.position.y + 0.3f), transform.rotation);
            }

            switch (points)
            {
                case 1:
                    star1.SetActive(true); break;
                case 2:
                    star2.SetActive(true); break;
                case 3:
                    star3.SetActive(true);
                    OpenDoor.SetActive(true);
                    break;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            Scaner = true;
            an.SetBool("Jumping", false);
        }
        if(collision.CompareTag("Door"))
        {
            an.SetBool("Enter", true);
            an.SetBool("Jumping", false);
            an.SetBool("Running", false);
            pass = false;
            speed = 0;
        }

      if(collision.CompareTag("EnemyArea"))
        {
            an.SetBool("Death", true);
        }
      if(collision.CompareTag("Cannon"))
        {
            an.SetBool("Death", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);
            points += 1;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(resetLevel);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
