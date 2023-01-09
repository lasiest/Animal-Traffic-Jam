using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementType2 : MonoBehaviour
{
    public Vector3 rotation1;
    public Vector3 rotation2;

    public float speed;

    public float maxRotate1 = 0.5f;
    public float maxRotate2 = -0.5f;

    public bool toogle;

    void Awake()
    {
        toogle = true;
    }

    void Update()
    {

        Debug.Log(transform.localRotation.z);

        if(transform.localRotation.z >= maxRotate1)
        {
            toogle = false;
        }else if(transform.localRotation.z <= maxRotate2)
        {
            toogle = true;
        }

        if (toogle)
        {
            transform.Rotate(rotation1 * speed * Time.deltaTime);
        }
        else if (!toogle)
        {
            transform.Rotate(rotation2 * speed * Time.deltaTime);
        }
    }
}
