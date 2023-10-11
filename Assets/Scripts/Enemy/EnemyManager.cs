using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameRestart()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<EnemyMovement>().GameRestart();
            child.GetComponent<BoxCollider2D>().enabled = true;
            child.GetComponent<EdgeCollider2D>().enabled = true;
        }
    }

    void Awake()
    {
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }
}
