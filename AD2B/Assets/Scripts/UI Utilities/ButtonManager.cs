using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    private string _url;
    private GameObject _fadeOutImage;
    public float timeToFadeOut;
    public Color toggleColor;

    void Start () {
        _fadeOutImage = GameObject.Find ("FadeToBlack");
    }

    public void OpenURL (string _url) {
        Application.OpenURL (_url);
    }

    public void ChangeToggleColor (string className) {
        if (GetComponent<Toggle> ().isOn) {
            GetComponent<Image> ().color = toggleColor;
            PlayerData.charClass = className;
        } else {
            GetComponent<Image> ().color = Color.white;
        }
    }

    public void QuitGame () {
        Application.Quit ();
    }

    public void ChangeScene (string sceneName) {
        StartCoroutine ("FadeToBlack", sceneName);
    }

    IEnumerator FadeToBlack (string sceneName) {
        CanvasGroup canvas = _fadeOutImage.GetComponent<CanvasGroup> ();
        while (canvas.alpha < 1) {
            canvas.alpha += Time.deltaTime / timeToFadeOut;
            yield return null;
        }
        SceneManager.LoadScene (sceneName);
    }
}