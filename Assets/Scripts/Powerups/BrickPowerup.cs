using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPowerup : MonoBehaviour, IPowerupController
{
    public Animator powerupAnimator;
    public BasePowerup powerup;
    public bool isBreakable = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!powerup.hasSpawned)
            {
                this.GetComponent<SpriteRenderer>().enabled = true;
                this.GetComponent<Animator>().SetTrigger("bounce");
                powerupAnimator.SetTrigger("spawned");

                if (!isBreakable)
                {
                    this.GetComponent<Animator>().SetTrigger("spawned");
                }
            }
            else
            {
                if (isBreakable)
                {
                    this.GetComponent<Animator>().SetTrigger("bounce");
                }
            }
        }
    }

    public void Disable()
    {

    }
    public void GameRestart()
    {
        this.GetComponent<Animator>().SetTrigger("reset");

    }
    public void Awake()
    {
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }

}
