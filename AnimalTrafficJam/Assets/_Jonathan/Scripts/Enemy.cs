using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private FOVManager fovManager;
    [SerializeField] private Animator animator;

    [Header("Enemy Stats")]
    public float initialStartingAngle;
    public float speed = 2f;
    public float fovRotateSpeed = 2f;
    public float delayWalkTime = 2f;
    public float delayRotateTime = 2f;

    [Header("Fill these if you want the enemy to move")]
    public Transform startPoint;
    public Transform endPoint;

    [Header("Fill this if you want to rotate FOV after the enemy stopped walking")]
    public Transform fovIdlePoint;

    [Header("Fill this if you want to rotate FOV")]
    public Transform targetRotation;    

    private Vector3 targetPosition;

    private float startAngle;
    private float endAngle;
    
    private bool isMoving = true;
    private bool isRotatingTowardsTarget = true;
    private bool isReversing = false;

    private void Start()
    {
        if (startPoint != null && endPoint != null)
        {
            targetPosition = startPoint.position;
            RotateTowards(targetPosition);            
        }

        if (targetPosition != null)
        {
            Vector3 lookDirection = targetPosition - transform.position;
            RotateFOV(lookDirection);
        }
        else
        {
            fovManager.SetStartingAngle(initialStartingAngle);
        }

        if (targetRotation != null)
        {
            startAngle = fovManager.GetStartingAngle();
            endAngle = fovManager.GetAngleFromVector(targetRotation.position - transform.position);
        }
    }

    private void Update()
    {
        if (startPoint != null & endPoint != null)
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

                    StartCoroutine(WaitAndChangeMoveTarget(startPoint, endPoint));
                    isMoving = false;
                    animator.SetBool("Move", false);
                }
            }
        }

        if (targetRotation != null)
        {
            if (isRotatingTowardsTarget)
            {
                RotateFOVSmoothly(fovRotateSpeed);

                if (fovManager.GetStartingAngle() >= endAngle && !isReversing)
                {
                    isReversing = true;
                    fovRotateSpeed *= -1;
                }
                else if (fovManager.GetStartingAngle() <= startAngle && isReversing)
                {
                    isReversing = false;
                    fovRotateSpeed *= -1;
                }
            }
        }
    }

    private IEnumerator WaitAndChangeMoveTarget(Transform startPoint, Transform endPoint)
    {
        yield return new WaitForSeconds(delayWalkTime);

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

    private void RotateFOVSmoothly(float rotateSpeed)
    {
        fovManager.SetDirectionSmoothly(rotateSpeed);
    }
}
