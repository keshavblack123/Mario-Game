using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour
{
    private float goombaPositionX;

    // Start is called before the first frame update
    void Start()
    {
        // goombaBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<EdgeCollider2D>().enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<EdgeCollider2D>().enabled = false;
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            transform.position += new Vector3(0.0f, -0.3f, 0.0f);
            this.GetComponent<Animator>().SetTrigger("killed");
        }
    }

    void DisableGoomba()
    {
        gameObject.SetActive(false);
    }

    void PlayGoombaStomp()
    {
        AudioSource source = this.GetComponent<AudioSource>();
        source.PlayOneShot(source.clip);
    }
}
