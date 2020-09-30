using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionSceneManager : MonoBehaviour
{

    public Button left;
    public Button right;
    public Sprite[] characters;
    private static Sprite curChar;
    public Image character;
    private static int indexPosition = 0;
    public static OptionSceneManager instance;
    public Button back;
    private AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        click = GetComponent<AudioSource>();
        left.onClick.AddListener(() => switchCharacter("left"));
        right.onClick.AddListener(() => switchCharacter("right"));
        back.onClick.AddListener(() => {
            SceneManager.LoadScene("StartScene");
            StartCoroutine(clickSoundEffect());
        });
        curChar = characters[indexPosition];
        
        
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    IEnumerator clickSoundEffect()
    {
        click.Play();
        yield return new WaitWhile(() => click.isPlaying);
    }

    private void switchCharacter(string direction)
    {
        switch (direction)
        {
            case "right":
                if (characters.Length == indexPosition + 1)
                {
                    indexPosition = 0;
                }
                else
                {
                    indexPosition++;
                }
                break;
            case "left":
                if (indexPosition == 0)
                {
                    indexPosition = characters.Length-1;
                }
                else
                {
                    indexPosition--;
                }
                break;
        }

        character.sprite = characters[indexPosition];
        curChar = characters[indexPosition];

        StartCoroutine(clickSoundEffect());

    }

    public static Sprite getCurCharacter()
    {
        return curChar;
    }
}
