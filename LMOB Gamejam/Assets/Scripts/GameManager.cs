using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject image;
    public GameObject player;
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

        //pause all actors
        Shooter[] shooters = FindObjectsOfType<Shooter>();
        foreach (Shooter shooter in shooters)
        {
            shooter.time_out = true;
        }
        time_left = rewind_time;
        //Pause player controlls
        player.GetComponent<PlayerMovement>().time_out = true;

        //Rewind all timebodies
        TimeBody[] things = FindObjectsOfType<TimeBody>();
        foreach(TimeBody thing in things)
        {
            thing.StartRewind(rewind_time);
            /*if(thing.pointsInTime.Count * Time.fixedDeltaTime > rewind_time)
            {
                thing.destroy_after = true;
            }*/
        }

        //Rewind player
        player.GetComponent<PlayerTimeBody>().TakePosition(player_rewind_time);
    }

    //Continue all movement
    public void Continue()
    {
        rewind = false;
        Debug.Log("shooting and player moving");
        image.SetActive(false);
        Shooter[] shooters = FindObjectsOfType<Shooter>();
        foreach (Shooter shooter in shooters)
        {
            shooter.time_out = false;
        }

        player.GetComponent<PlayerMovement>().time_out = false;
    }

}
