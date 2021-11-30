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
        if (Input.GetKeyDown(KeyCode.Space) && ani.GetBool("IsGrounded"))
        {
            ani.SetTrigger("Jump");
            ani.SetBool("IsGrounded",false);
            ani.SetBool("IsFalling", false);
            Vector2 dirSalto = new Vector2(0f, 1f);
            rb.AddForce(dirSalto * fuerza, ForceMode2D.Impulse);
            
        }

        if (rb.velocity.y < 0.15f)
        {
            ani.SetBool("IsFalling", true);
        }

        //Vector3 rayOrigin = transform.position + new Vector3(0.7f, 2.8f, 0f);
        Vector3 rayOrigin = transform.position + new Vector3(0f, 0f, 0f);
        Debug.DrawRay(rayOrigin, Vector3.down * groundDist, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, groundDist);
        // If it hits something...
        if (hit.collider != null)
        {
            ani.SetBool("IsFalling", false);
            ani.SetBool("IsGrounded", true);

            print("Estoy chocando con " + hit.collider.name);

        }
        else
        {
            ani.SetBool("IsGrounded", false);
        }
    }

}

