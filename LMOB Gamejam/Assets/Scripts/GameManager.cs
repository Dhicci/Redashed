using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject image;
    public GameObject player;
    public GameObject finish;
    public bool rewind = false;
    public float player_rewind_time;
    public float rewind_time;
    private float time_left = -1;
    bool k = false;
    /*int max_count = 0;
    TimeBody main;*/

    private void Update()
    {

        if (time_left >= 0)
        {
            time_left -= Time.deltaTime;
        }
        if (time_left <= 0 && k == true)
        {
            k = false;
            Continue();
        }

    }

    public void PlayerDeath()
    {
        image.SetActive(true);
        k = true;
        rewind = true;

        FindObjectOfType<AudioManager>().Play("Rewind");

        //pause all actors
        Shooter[] shooters = FindObjectsOfType<Shooter>();
        foreach (Shooter shooter in shooters)
        {
            shooter.time_out = true;
            shooter.rewind_time = rewind_time;
        }
        time_left = rewind_time;
        //Pause player controlls
        player.GetComponent<PlayerMovement>().time_out = true;

        //Rewind all timebodies
        TimeBody[] things = FindObjectsOfType<TimeBody>();
        foreach(TimeBody thing in things)
        {
            thing.StartRewind(rewind_time);
        }

        SawBladeTimeBody[] saw_things = FindObjectsOfType<SawBladeTimeBody>();
        foreach (SawBladeTimeBody thing in saw_things)
        {
            thing.StartRewind(rewind_time);
        }

        //Rewind player
        player.GetComponent<PlayerTimeBody>().TakePosition(player_rewind_time);
        finish.GetComponent<LevelComplete>().restarts += 1;
    }

    //Continue all movement
    public void Continue()
    {
        StartCoroutine(immunity());
        rewind = false;
        image.SetActive(false);
        Shooter[] shooters = FindObjectsOfType<Shooter>();
        foreach (Shooter shooter in shooters)
        {
            shooter.time_out = false;
        }

        player.GetComponent<PlayerMovement>().time_out = false;
        Time.timeScale = 0;
    }

    IEnumerator immunity()
    {
        player.tag = "Immune";
        yield return new WaitForSeconds(0.2f);
        player.tag = "Player";
    }

}
