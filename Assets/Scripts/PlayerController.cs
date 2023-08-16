using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;

    public float speed;
    public bool spc=false;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis("Jump") != 0)
        {
            Debug.Log("Space is entered");
            Debug.Log(spc);
            if (!spc)
            {
                spc = true;
                rigidbody2d.velocity = new Vector2(0f, 0f);
            }
            else {
                spc = false;
                rigidbody2d.velocity = new Vector2(speed, speed);
            }
        }
        else if (!spc && Input.GetAxis("Horizontal") > 0)   //movement in +ve x direction
        {
            rigidbody2d.velocity = new Vector2(speed, 0f);
        }
        else if (!spc && Input.GetAxis("Horizontal") < 0)   //movement in -ve x direction
        {
            rigidbody2d.velocity = new Vector2(-speed, 0f);
        }
        else if (!spc && Input.GetAxis("Vertical") > 0)   //movement in +ve y direction
        {
            rigidbody2d.velocity = new Vector2(0f, speed);
        }
        else if (!spc && Input.GetAxis("Vertical") < 0)   //movement in -ve y direction
        {
            rigidbody2d.velocity = new Vector2(0f, -speed);
        }
        else if (!spc && Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            Debug.Log("Level Complete!!!");
        }
    }
}
