using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public Button target;
    private float scoreValue = 0;

    public Text scoreText;

    private AudioSource gameOver;

    public AudioSource restartSoundEffect;

    Button btn;

    private Sprite curChara;

    public Image player;
    
    // Start is called before the first frame update
    void Start()
    {
        btn = target.GetComponent<Button>();
        btn.onClick.AddListener(restart);
        scoreValue = Mathf.RoundToInt(ScoreManager.getScoreValue());
        scoreText.text = "Score : " + scoreValue;
        gameOver = GetComponent<AudioSource>();
        gameOver.Play();

        curChara = OptionSceneManager.getCurCharacter();
        if (curChara != null)
            player.sprite = curChara;
    }

    
    private void restart()
    {
        
        StartCoroutine(soundEffect());
    }

    IEnumerator soundEffect()
    {
        restartSoundEffect.Play();
        yield return new WaitWhile(() => restartSoundEffect.isPlaying);
        if(btn.name == "Restart")
            SceneManager.LoadScene("MainScene");
        else if(btn.name == "Option")
            SceneManager.LoadScene("OptionScene");
    }
}
