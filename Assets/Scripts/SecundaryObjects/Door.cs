using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    public int Cont;
    [SerializeField] float NextLevel;
    [SerializeField] bool Passing=false;
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (Cont)
        {
                case 1:
                animator.SetInteger("Next", 1);
                Passing = true;
                break;
        }

        if (Passing)
        {
            NextLevel += Time.deltaTime;
            if(NextLevel > 1)
            {
                animator.SetInteger("Next", 2);
                Passing = false;
                NextLevel = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Cont += 1;
        }
    }

    public void Passed()
    {
        Cont += 1;
    }
}
