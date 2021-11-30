using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator ani;
    [SerializeField] float fuerza;
    [SerializeField] float groundDist;
    // Start is called before the first frame update
    void Start()
    {
        fuerza = 400f;
        groundDist = 0.15f;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Salto();
    }

    void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetTrigger("Jump");
            ani.SetBool("IsGrounded",false);
            ani.SetBool("IsFalling", false);
            Vector2 dirSalto = new Vector2(0f, 1f);
            rb.AddForce(dirSalto * fuerza);
            ani.SetBool("IsFalling", true);
        }
    }
}
