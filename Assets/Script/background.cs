using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class background : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {

            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
        

    }
}
