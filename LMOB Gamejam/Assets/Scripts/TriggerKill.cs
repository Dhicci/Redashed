using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKill : MonoBehaviour
{

    public GameObject game_manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Kill player
        if (collision.gameObject.tag == "Player")
        {
            game_manager.GetComponent<GameManager>().PlayerDeath();
        }
    }

}
