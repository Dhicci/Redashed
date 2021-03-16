using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKill : MonoBehaviour
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
            Debug.Log("moi");
            game_manager.GetComponent<GameManager>().PlayerDeath();
        }
        Destroy(gameObject);
    }

}
