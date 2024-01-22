using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 touncPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(touncPos.x <0)
            {
                rb.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                rb.AddForce(Vector2.right * moveSpeed);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        FlipPlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            SceneManager.LoadScene(0);
        }
    }


    void FlipPlayer()
    {
        if(rb.velocity.x <-0.1f)
        {
            sp.flipX = false;
        }
        else if(rb.velocity.x > 0.1f)
        {
            sp.flipX = true;        
        }
    }
}
