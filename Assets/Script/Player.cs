using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public float speed = 10f;

    Rigidbody2D rb;

     float movement = 0f;

    public Transform target;

    private Sprite curCharacter;

    public Sprite initialCharacter;

    private void Start() { rb = GetComponent<Rigidbody2D>();
        curCharacter = OptionSceneManager.getCurCharacter();
        if(curCharacter != null)
            transform.GetComponent<SpriteRenderer>().sprite = curCharacter;
        

        
    }

    private void Update()
    {
        movement = Input.GetAxis("Horizontal") * speed;

        
        
    }


    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    private void LateUpdate()
    {
        if (transform.position.y - target.position.y < -5)
        {
            SceneManager.LoadScene("GameOverScene");

        }
        
    }
}
