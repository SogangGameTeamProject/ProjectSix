using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMovement : MonoBehaviour
{
    //���̵� ó��
    public void OnSceneMove(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    //���� ����ó�� �Լ�
    public void OnCloseGame()
    {
        Application.Quit();
    }
    //�˾� Open
    public void OnOpenPopupPanel(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
    //�˾� Close
    public void OnClosePopupPanel(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}
