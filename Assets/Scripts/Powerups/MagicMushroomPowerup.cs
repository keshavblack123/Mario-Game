
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MagicMushroomPowerup : BasePowerup
{
    // setup this object's type
    // instantiate variables
    private Vector3 originalPosition;
    protected override void Start()
    {
        base.Start(); // call base class Start()
        this.type = PowerupType.MagicMushroom;
        rigidBody.bodyType = RigidbodyType2D.Static;
        GetComponent<BoxCollider2D>().enabled = false;
        originalPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && spawned)
        {
            // TODO: do something when colliding with Player
            gameObject.SetActive(false);
            // then destroy powerup (optional)
            // DestroyPowerup();

        }
        else if (col.gameObject.layer == 10) // else if hitting Pipe, flip travel direction
        {
            if (spawned)
            {
                goRight = !goRight;
                rigidBody.AddForce(Vector2.right * 3 * (goRight ? 1 : -1), ForceMode2D.Impulse);

            }
        }
    }

    // interface implementation
    public override void SpawnPowerup()
    {
        spawned = true;
        StartCoroutine(EnablePowerup());
        rigidBody.AddForce(Vector2.right * 3, ForceMode2D.Impulse); // move to the right
    }


    // interface implementation
    public override void ApplyPowerup(MonoBehaviour i)
    {
        // TODO: do something with the object

    }

    IEnumerator EnablePowerup()
    {
        rigidBody.bodyType = RigidbodyType2D.Dynamic;
        GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForFixedUpdate();
    }
    public void GameRestart()
    {
        spawned = false;
        gameObject.SetActive(true);
        rigidBody.bodyType = RigidbodyType2D.Static;
        GetComponent<BoxCollider2D>().enabled = false;
        gameObject.transform.position = originalPosition;

    }
    public void Awake()
    {
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }

}