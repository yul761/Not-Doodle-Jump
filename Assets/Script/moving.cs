using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public float speed = 5f;

    public Transform cam;

    Vector3 bound;

    // Start is called before the first frame update
    void Start()
    {
        bound = Camera.main.WorldToScreenPoint(cam.position);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime*speed, transform.position.y, transform.position.z);
        
    }

    private void LateUpdate()
    {
        //left -6.6; righ 6.6
        if(transform.position.x > 6.6)
        {
            speed = -5;
        }
        else if (transform.position.x <= -6.6)
        {
            speed = 5;
        }
    }
}
