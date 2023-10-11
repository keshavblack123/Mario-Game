using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinPowerup : BasePowerup
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start(); // call base class Start()
        this.type = PowerupType.Coin;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseScore()
    {
        GameManager.instance.IncreaseScore(1);
    }

    public override void SpawnPowerup()
    {
        spawned = true;

        // PowerupManager.instance.powerupCollected.Invoke(this);
    }

    // interface implementation
    public override void ApplyPowerup(MonoBehaviour i)
    {
        //try
        GameManager manager;
        bool result = i.TryGetComponent<GameManager>(out manager);

        if (result)
        {
            manager.IncreaseScore(1);
        }

    }

    public new void DestroyPowerup()
    {

    }
    public void GameRestart()
    {
        spawned = false;
    }
    public void Awake()
    {
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }

}
