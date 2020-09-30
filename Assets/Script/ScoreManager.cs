using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    private static float scoreValue = 0f;
        Text score;
    public Transform player;
    public Rigidbody2D doodle;
    private float startPosition = -1.5f;
    private bool updateFlag = false;

    public static ScoreManager instance;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        
        
    }

    void Awake()
    { 
        DontDestroyOnLoad(transform.gameObject);      
    }

    // Update is called once per frame
    void Update()
    {
        if(doodle.velocity.y < 0 && updateFlag)
        {  
            scoreValue = player.position.y - startPosition;
            //startPosition = player.position.y;
            updateFlag = false;
        }

        if(doodle.velocity.y > 0)
        {
            updateFlag = true;
        }
        
        score.text = "Score : " + Mathf.RoundToInt(scoreValue);
        
    }

    public static float getScoreValue()
    {
        return scoreValue;
    }

    
}
