using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public int Level1 = 3;
    public int Level2 = 4;
    public int Level3 = 5;

    public int Mainmenu = 2;
    public GameObject Quitmenu;
    public int Deathmenu = 0;
    public int Optionmenu = 1;

    //public GameObject Dialogue;
    public int CactusDamage = 3;

    int HealthBar = 30;
    public TextMeshProUGUI displayHealth;

    public Slider SoundSlider;
    public TextMeshProUGUI Sound;

    public GameObject playerPrefab;
    private GameObject activePlayer;
    //public static GameManager instance;

    public static Menu instance;

    // Update is called once per frame

    private void Start()
    {
        Quitmenu.gameObject.SetActive(false);
        //Dialogue.gameObject.SetActive(false);
    }
    public void OnStartButton()
    {
        if (instance != null && instance != this)
        {
            Destroy(playerPrefab);
        }
        else
        {
            SceneManager.LoadScene(Level1);

            DontDestroyOnLoad(playerPrefab);
            SceneManager.activeSceneChanged += SpawnPlayerOnSceneLoad;

            instance = this;
        }

        /*SceneManager.LoadScene(Level1);
        DontDestroyOnLoad(Quitmenu);*/
    }

    private void SpawnPlayerOnSceneLoad(Scene currentScene, Scene nextScene)
    {
        if (activePlayer == null)
        {
            PlayerSpawnSpot playerSpot = FindObjectOfType<PlayerSpawnSpot>();
            GameObject newPlayer = Instantiate(playerPrefab, playerSpot.transform.position, playerSpot.transform.rotation);
            activePlayer = newPlayer;

        }
        else
        {
            return;
            /*PlayerSpawnSpot playerSpot = FindObjectOfType<PlayerSpawnSpot>();
            activePlayer.transform.position = playerSpot.transform.position;
            activePlayer.transform.rotation = playerSpot.transform.rotation;*/
        }
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

    public void OnOptionButton()
    {
        SceneManager.LoadScene(Optionmenu);
    }

    public void OnRestartButton()
    {

    }

    public void OnSoundSlider()
    {
        //Sound.GetComponent<TextMeshPro>().text = SoundSlider.value;

        SoundSlider.onValueChanged.AddListener((v) =>
        {
            Sound.text = v.ToString("0");
        });
    }
}
