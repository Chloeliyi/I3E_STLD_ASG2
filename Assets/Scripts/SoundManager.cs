using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Class to control sound
/// </summary>
public class SoundManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip gunsound;
    public AudioClip Walksound;
    public AudioClip Cannonsound;
    public AudioClip Deathsound;

    public static SoundManager instance;
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    private void Awake()
    {

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PLaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    /*[SerializeField] Slider BGMSlider;
    public TextMeshProUGUI BGM;

    [SerializeField] Slider SFXSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = BGMSlider.value;
        Save();
    }

    private void Load()
    {
        BGMSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("MusicVolume", BGMSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSoundSlider()
    {
        //Sound.GetComponent<TextMeshPro>().text = SoundSlider.value;

        BGMSlider.onValueChanged.AddListener((v) =>
        {
            BGM.text = v.ToString("0");
        });
    }*/
}
