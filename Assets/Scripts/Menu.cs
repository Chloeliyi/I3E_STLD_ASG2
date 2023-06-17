using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public int Level1;
    public int Mainmenu;
    public GameObject Quitmenu;

    private void Start()
    {
        Quitmenu.gameObject.SetActive(false);
    }
    public void OnStartButton()
    {
        SceneManager.LoadScene(Level1);
    }

    public void OnQuitButton()
    {
        //Application.Quit();
        Quitmenu.gameObject.SetActive(true);
    }

    public void OnYesButton()
    {
        Application.Quit();
    }

    public void OnNoButton()
    {
        Quitmenu.gameObject.SetActive(false);
    }

    public void OnReturnButton()
    {
        SceneManager.LoadScene(Mainmenu);
    }
}
