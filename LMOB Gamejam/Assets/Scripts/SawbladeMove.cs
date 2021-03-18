using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawbladeMove : MonoBehaviour
{

    public GameObject destination;
    public float speed;
    Vector3 start_pos;
    bool going = true;
    // Start is called before the first frame update
    void Start()
    {
        start_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (destination)
        {
            if (going == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, destination.transform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, start_pos, speed * Time.deltaTime);
            }
            if (transform.position == destination.transform.position && going == true)
            {
                going = false;
            }
            if (transform.position == start_pos && going == false)
            {
                going = true;
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
#if UNITY_EDITOR
        Gizmos.color = Color.red;

        //Draw the suspension
        Gizmos.DrawLine(transform.position, destination.transform.position);
#endif
    }
}
