using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public FOVManager fovManager;
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
    public Transform startPointFovIdlePoint;
    public Transform endPointFovIdlePoint;

    [Header("Fill this if you want to rotate FOV")]
    public float targetAngle;    

    private Vector3 targetPosition;

    private float startAngle;
    private float endAngle;
    
    private bool isMoving = true;
    private bool isReversing = false;

    private void Start()
    {
        if (startPoint != null && endPoint != null)
        {
            targetPosition = startPoint.position;
            RotateTowards(targetPosition);
        }

        if (!Equals(targetPosition, new Vector3(0f, 0f, 0f)))
        {
            Vector3 lookDirection = targetPosition - transform.position;
            RotateFOV(lookDirection);
        }
        else
        {
            fovManager.SetStartingAngle(initialStartingAngle);
        }

        if (targetAngle != 0)
        {
            startAngle = initialStartingAngle;
            endAngle = targetAngle;

            fovManager.SetStartingAngle(startAngle);
        }
        else
        {
            fovManager.SetStartingAngle(initialStartingAngle);
        }

        fovManager.SetOrigin(transform.position);
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
                    // Kalau enemy sudah sampai ke end point
                    if (targetPosition == endPoint.position)
                    {
                        if (startPointFovIdlePoint != null)
                        {
                            Vector3 fovLookDirection = (startPointFovIdlePoint.position - transform.position).normalized;

                            RotateFOV(fovLookDirection);

                            if (fovManager.GetAngleFromVector(fovLookDirection) > 90)
                            {
                                transform.rotation = Quaternion.Euler(0, 180, 0);
                            }
                        }
                    }

                    // Kalau enemy sudah balik lagi ke start point
                    else if (targetPosition == startPoint.position)
                    {
                        if (endPointFovIdlePoint != null)
                        {
                            Vector3 fovLookDirection = (endPointFovIdlePoint.position - transform.position).normalized;
                            RotateFOV(fovLookDirection);

                            if (fovManager.GetAngleFromVector(fovLookDirection) > 90)
                            {
                                transform.rotation = Quaternion.Euler(0, 180, 0);
                            }
                        }
                    }

                    StartCoroutine(WaitAndChangeMoveTarget(startPoint, endPoint));
                    isMoving = false;
                    animator.SetBool("Move", false);
                }
            }
        }

        if (targetAngle != 0)
        {
            RotateFOVSmoothly(fovRotateSpeed);

            // startAngle harus lebih kecil dari endAngle
            if (targetAngle >= 0)
            {
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
            
            // startAngle harus lebih besar dari endAngle
            else
            {
                if (fovManager.GetStartingAngle() <= endAngle && !isReversing)
                {
                    isReversing = true;
                    fovRotateSpeed *= -1;
                }
                else if (fovManager.GetStartingAngle() >= startAngle && isReversing)
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

        Debug.Log(gameObject.name + " changing target");

        if (targetPosition == startPoint.position)
        {
            targetPosition = endPoint.position;

            Vector3 direction = (targetPosition - startPoint.position).normalized;
            if (direction.y == 0)
            {
                RotateTowards(targetPosition);
            }
            else
            {
                RotateFOV(direction);
            }
        }
        else
        {
            targetPosition = startPoint.position;

            Vector3 direction = (targetPosition - endPoint.position).normalized;
            if (direction.y == 0)
            {
                RotateTowards(targetPosition);
            }
            else
            {
                RotateFOV(direction);
            }
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
