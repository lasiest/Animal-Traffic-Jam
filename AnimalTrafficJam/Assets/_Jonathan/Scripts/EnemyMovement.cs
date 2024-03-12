using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private FOVManager fovManager;
    [SerializeField] private Animator animator;

    public Transform startPoint;
    public Transform endPoint;
    public Transform fovIdlePoint;
    public float speed = 2f;
    public float delayTime = 2f;

    private Vector3 targetPosition;
    public bool isMoving = true;

    private void Start()
    {
        targetPosition = startPoint.position;
        RotateTowards(targetPosition);

        Vector3 lookDirection = (targetPosition - transform.position).normalized;

        if (lookDirection.x > 0)
        {
            fovManager.SetStartingAngle(45f);
        }
        else if (lookDirection.x < 0)
        {
            fovManager.SetStartingAngle(225f);
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            fovManager.SetOrigin(transform.position);

            animator.SetBool("Move", true);

            if (transform.position == targetPosition)
            {
                if (targetPosition == endPoint.position)
                {
                    if (fovIdlePoint != null)
                    {
                        Vector3 fovLookDirection = (fovIdlePoint.position - transform.position).normalized;
                        RotateFOV(fovLookDirection);
                    }
                }

                StartCoroutine(WaitAndChangeTarget());
                isMoving = false;
                animator.SetBool("Move", false);                
            }
        }
    }

    private IEnumerator WaitAndChangeTarget()
    {
        yield return new WaitForSeconds(delayTime);

        if (targetPosition == startPoint.position)
        {
            targetPosition = endPoint.position;
            RotateTowards(targetPosition);
        }
        else
        {
            targetPosition = startPoint.position;
            RotateTowards(targetPosition);
        }

        isMoving = true;
    }

    private void RotateTowards(Vector3 target)
    {
        Vector3 lookDirection = (target - transform.position).normalized;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        transform.rotation = rotation;

        RotateFOV(lookDirection);
    }

    private void RotateFOV(Vector3 target)
    {
        fovManager.SetDirection(target);
    }
}
