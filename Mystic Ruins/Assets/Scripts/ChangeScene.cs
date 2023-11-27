using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ToTitleScene()
    {
        SceneManager.LoadScene("Park_TitleScene");
    }

    public void ToEnd()
    {
        Application.Quit();
        Debug.Log("���� ����");
    }
}
