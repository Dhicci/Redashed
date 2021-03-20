using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKill : MonoBehaviour
{

    float timer = 0f;
    float immune_time = 0.1f;
    bool immune = true;
    GameObject game_manager;

    private void Start()
    {
        game_manager = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= immune_time)
        {
            immune = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //Kill player
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<AudioSource>().Play();
            if (game_manager.GetComponent<GameManager>().rewind == false)
            {
                game_manager.GetComponent<GameManager>().PlayerDeath();
            }
        }

        if ((collision.gameObject.tag == "Shooter" && immune) || collision.gameObject.tag == "Player")
        {
        }
        else
        {
            StartCoroutine(BellTolls());
        }
    }

    IEnumerator BellTolls()
    {
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

}
