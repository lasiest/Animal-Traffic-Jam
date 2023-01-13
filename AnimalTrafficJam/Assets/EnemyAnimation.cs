using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public GameObject gameObjectToFollow;
    public GameObject thisGameObject;
    public Animator animator;
    public bool sameLocation;

    // Update is called once per frame
    void Update()
    {

        if(gameObjectToFollow.transform.position == transform.position){
            animator.SetBool("Move", false);
        }else{
            animator.SetBool("Move", true);
        }

        if(gameObjectToFollow.transform.rotation.z < 0){
            thisGameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }else if(gameObjectToFollow.transform.rotation.z > 0){
            thisGameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        transform.position = Vector3.MoveTowards(transform.position, gameObjectToFollow.transform.position, 0.1f);

    }
}
