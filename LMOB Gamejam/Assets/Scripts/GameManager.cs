using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public bool rewind = false;
    public float rewind_time;
    private float time_left = -1;
    bool k = false;
    int max_count = 0;
    TimeBody main;

    private void Update()
    {
        if (time_left >= 0)
        {
            time_left -= Time.deltaTime;
            if (main.isRewinding == false)
            {
                Continue();
                time_left = -1;
            }
        }
        if (time_left <= 0 && k == true)
        {
            k = false;
            Debug.Log("yep");
            Continue();
        }

    }

    public void PlayerDeath()
    {
        
        k = true;
        Debug.Log("l");
        rewind = true;
        //Rewind all timebodies
        TimeBody[] things = FindObjectsOfType<TimeBody>();
        foreach(TimeBody thing in things)
        {
            thing.StartRewind();
            if (thing.pointsInTime.Count > max_count)
            {
                max_count = thing.pointsInTime.Count;
                main = thing;
            }

        }
        foreach (TimeBody thing in things)
        {
            if (thing.pointsInTime.Count < max_count)
            {
                thing.destroy_after = true;
            }
        }

        //Rewind player
        player.GetComponent<PlayerTimeBody>().TakePosition(max_count * Time.fixedDeltaTime);

        //pause all actors
        Shooter[] shooters = FindObjectsOfType<Shooter>();
        foreach(Shooter shooter in shooters)
        {
            shooter.time_out = true;
        }
        time_left = rewind_time;
        //Pause player controlls
        player.GetComponent<PlayerMovement>().time_out = true;

    }

    //Continue all movement
    public void Continue()
    {
        Debug.Log("continue");
        Shooter[] shooters = FindObjectsOfType<Shooter>();
        foreach (Shooter shooter in shooters)
        {
            shooter.time_out = false;
        }

        player.GetComponent<PlayerMovement>().time_out = false;
    }

}
