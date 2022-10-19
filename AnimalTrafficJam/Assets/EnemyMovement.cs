using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool start;
    public Transform startPost;
    public Transform finishPost;

    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        start = true;

    }

    // Update is called once per frame
    void Update()
    {

        if(start && finishPost.position == transform.position)
        {
            start = false;
            Vector3 newRotation = new Vector3(0, 0, 180);
            transform.eulerAngles = newRotation;
        }else if(!start && startPost.position == transform.position)
        {
            start = true;
            Vector3 newRotation = new Vector3(0, 0, 0);
            transform.eulerAngles = newRotation;
        }
        if (start)
        {
            transform.position = Vector2.MoveTowards(transform.position, finishPost.position, speed * Time.deltaTime);
        }
        else if (!start)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPost.position, speed * Time.deltaTime);
        }

    }



}
