using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBoxPowerupController : MonoBehaviour, IPowerupController
{
    public Animator powerupAnimator;
    public BasePowerup powerup; // reference to this question box's powerup
    private Animator boxAnimator;
    private Rigidbody2D boxBody;
    void Start()
    {
        boxAnimator = GetComponent<Animator>();
        boxBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        boxAnimator.ResetTrigger("reset");
        if (other.gameObject.tag == "Player" && !powerup.hasSpawned)
        {
            // show disabled sprite
            boxAnimator.SetTrigger("spawned");
            // spawn the powerup
            powerupAnimator.SetTrigger("spawned");
        }
    }

    // used by animator
    public void Disable()
    {
        boxBody.bodyType = RigidbodyType2D.Static;
        transform.localPosition = new Vector3(0, 0, 0);
    }

    public void GameRestart()
    {
        boxBody.bodyType = RigidbodyType2D.Dynamic;
        boxAnimator.ResetTrigger("spawned");
        boxAnimator.SetTrigger("reset");
    }
    public void Awake()
    {
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }

}