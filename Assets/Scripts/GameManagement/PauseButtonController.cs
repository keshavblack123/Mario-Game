
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonController : MonoBehaviour, IInteractiveButton
{
    private bool isPaused = false;
    public Sprite pauseIcon;
    public Sprite playIcon;
    private Image image;
    public GameObject pausePanel;
    public AudioSource backgroundAudio;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClick()
    {
        Time.timeScale = isPaused ? 1.0f : 0.0f;
        isPaused = !isPaused;
        if (isPaused)
        {
            image.sprite = playIcon;
            pausePanel.SetActive(true);
            PlayPauseSound();
            backgroundAudio.Pause();
        }
        else
        {
            image.sprite = pauseIcon;
            pausePanel.SetActive(false);
            backgroundAudio.UnPause();

        }
    }
    public void PlayPauseSound()
    {
        AudioSource source = this.GetComponent<AudioSource>();
        source.PlayOneShot(source.clip);
    }
}
