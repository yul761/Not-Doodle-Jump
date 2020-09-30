using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public Button btn;
    private AudioSource start;
    Button Target;
    // Start is called before the first frame update
    void Start()
    {
        Target = btn.GetComponent<Button>();
        start = GetComponent<AudioSource>();
        Target.onClick.AddListener(SceneChange);

        Debug.Log(Target.name);
        
    }



    IEnumerator soundEffect()
    {
        start.Play();
        yield return new WaitWhile(() => start.isPlaying);
        if(Target.name == "Play") { SceneManager.LoadScene("MainScene"); }
        else if(Target.name == "Option") { SceneManager.LoadScene("OptionScene"); }
        
    }

    void SceneChange()
    {

        StartCoroutine(soundEffect());
    }
}
