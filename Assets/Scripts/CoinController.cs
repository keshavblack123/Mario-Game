using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public Animator coinAnimator;
    public AudioClip coinCollected;
    // public AudioSource coinAudio;
    public Animator boxAnimator;
    public AudioSource coinAudio;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coinAnimator.SetTrigger("hitTheBox");
            boxAnimator.SetTrigger("hitTheBox");
        }
    }
    void PlayCoinSound()
    {
        coinAudio.PlayOneShot(coinCollected);
    }
}
