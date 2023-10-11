using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public AudioClip coinCollected;
    public AudioSource coinAudio;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayCoinSound()
    {
        coinAudio.PlayOneShot(coinCollected);
    }
}
