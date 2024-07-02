using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Manager : MonoBehaviour
{
    #region Singelton
    public static Scene_Manager instance;

    private void Awake()
    {
        if (instance != null)
            Debug.LogWarning("There exists more than one Scene Manager!!");
        else instance = this;
    }
    #endregion


    public Image transition;

    void Start()
    {
        Color c = transition.color;
        c.a = 0;
        transition.color = c;
        transition.gameObject.SetActive(false);
    }

    public void ChangeScene(string scene)
    {
        transition.gameObject.SetActive(true);
        StartCoroutine(FadeIn(scene));
    }

    public void ChangeSceneDirectly(string scene)
    {

        SceneManager.LoadScene(scene);
    }

    IEnumerator FadeIn(string scene)
    {
        float alpha = 0;
        Color newColor = transition.color;
        while (alpha < 1)
        {
            alpha += 0.1f;
            newColor.a = alpha;
            transition.color = newColor;
            yield return new WaitForSeconds(0.1f);
        }

        SceneManager.LoadScene(scene);
    }
}
