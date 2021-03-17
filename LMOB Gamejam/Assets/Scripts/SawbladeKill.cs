using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawbladeKill : MonoBehaviour
{

    GameObject game_manager;

    private void Start()
    {
        game_manager = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Kill player
        if (collision.gameObject.tag == "Player")
        {
            if (game_manager.GetComponent<GameManager>().rewind == false)
            {
                game_manager.GetComponent<GameManager>().PlayerDeath();
            }
        }
    }
}
