using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementType3 : MonoBehaviour
{


    public bool start;
    public Transform startPost;
    public Transform finishPost;

    public float speed;
    public float timeToWait;

    public float first_WalkDirection;
    public float first_StopDirection;
    public float last_WalkDirection;
    public float last_StopDirection;
    void Start()
    {
        start = true;
    }


    void Awake()
    {
        start = true;
    }

    void Update()
    {

        
        //Debug.Log(transform.rotation.z);

        if(start && finishPost.position == transform.position)
        {
            StartCoroutine(WaitFirstPost(first_StopDirection, first_WalkDirection, timeToWait));

        }
        else if(!start && startPost.position == transform.position)
        {
            StartCoroutine(WaitSecondPost(last_StopDirection, last_WalkDirection, timeToWait));
        }
        if (start)
        {
            transform.position = Vector2.MoveTowards(transform.position, finishPost.position, speed * Time.deltaTime);
        }
        if (!start)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPost.position, speed * Time.deltaTime);
        }

    }

    IEnumerator WaitFirstPost(float rotate1, float rotate2, float timeToWait){
        // yield return new WaitForSeconds(5);
        Vector3 firstRotation = new Vector3(0, 0, rotate1);
        transform.eulerAngles = firstRotation;
        yield return new WaitForSeconds(timeToWait);
        Vector3 LastRotation = new Vector3(0, 0, rotate2);
        transform.eulerAngles = LastRotation;
        start = false;
    }

    IEnumerator WaitSecondPost(float rotate1, float rotate2, float timeToWait){
        // yield return new WaitForSeconds(5);
        Vector3 firstRotation = new Vector3(0, 0, rotate1);
        transform.eulerAngles = firstRotation;
        yield return new WaitForSeconds(timeToWait);
        Vector3 LastRotation = new Vector3(0, 0, rotate2);
        transform.eulerAngles = LastRotation;
        start = true;
    }
}
