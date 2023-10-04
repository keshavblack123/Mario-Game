using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public Animator coinAnimator;
    public AudioClip coinCollected;
    public Animator boxAnimator;
    public AudioSource coinAudio;

    [System.NonSerialized]
    public int score = 0; // we don't want this to show up in the inspector


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
