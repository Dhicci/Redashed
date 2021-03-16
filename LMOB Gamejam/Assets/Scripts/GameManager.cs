using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public bool rewind = false;
    public float rewind_time;
    private float time_left;
    bool k = false;

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
        time_left = rewind_time;
        k = true;
        Debug.Log("l");
        rewind = true;
        //Rewind all timebodies
        TimeBody[] things = FindObjectsOfType<TimeBody>();
        foreach(TimeBody thing in things)
        {
            thing.StartRewind();
        }
        //pause all actors
        Shooter[] shooters = FindObjectsOfType<Shooter>();
        foreach(Shooter shooter in shooters)
        {
            shooter.time_out = true;
        }
        //Pause player controlls
        //player.GetComponent<PlayerMovement>().time_out = true;

    }

    //Continue all movement
    public void Continue()
    {
        Debug.Log("AAAAAAAAAAA");
        Shooter[] shooters = FindObjectsOfType<Shooter>();
        foreach (Shooter shooter in shooters)
        {
            shooter.time_out = false;
        }

        //player.GetComponent<PlayerMovement>().time_out = false;
    }

}
