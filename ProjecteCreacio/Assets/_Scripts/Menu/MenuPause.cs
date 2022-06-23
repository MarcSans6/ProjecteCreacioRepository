using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject buttonPause;
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject OptionPanel;
    [SerializeField] private AudioMixer audioMixer;



    private void Start()
    {
        OptionPanel.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0f;

        buttonPause.SetActive(false);
        menuPause.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;

        buttonPause.SetActive(true);
        menuPause.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Options ()
    {
        OptionPanel.SetActive(true);
    }

    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void ChangeQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
