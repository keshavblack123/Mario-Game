using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventTool : MonoBehaviour
{
    public UnityEvent spawnPowerup;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnCoin()
    {

    }

    void SpawnPowerup()
    {
        GetComponent<Animator>().ResetTrigger("reset");
        spawnPowerup.Invoke();
    }
    public void IncreaseScore()
    {
        GameManager.instance.IncreaseScore(1);
    }
    public void PlayPowerupSound()
    {
        AudioSource source = this.GetComponent<AudioSource>();
        source.PlayOneShot(source.clip);
    }

    public void GameRestart()
    {
        GetComponent<Animator>().ResetTrigger("spawned");
        GetComponent<Animator>().SetTrigger("reset");
    }
    public void Awake()
    {
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }
}
