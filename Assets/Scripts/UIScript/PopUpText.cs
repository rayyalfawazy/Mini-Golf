using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpText : MonoBehaviour
{
    [SerializeField] TMP_Text popupText;
    [SerializeField] string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        popupText.transform.DOScale(Vector2.one, 1);
    }

    public void NextScene()
    {
        if (nextScene != "") 
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
