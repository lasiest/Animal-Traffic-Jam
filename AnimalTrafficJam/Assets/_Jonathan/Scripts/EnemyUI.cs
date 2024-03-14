using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private float[] thresholds;
    private Enemy enemy;

    private void Awake()
    {
        enemy = gameObject.GetComponent<Enemy>();
    }

    private void Update()
    {
        switch (thresholds.Length)
        {
            case 1:
                if (enemy.targetAngle < 0)
                {
                    if (IsLessThan(enemy.fovManager.GetStartingAngle(), thresholds[^2]))
                    {
                        enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                }
                else
                {
                    if (!IsLessThan(enemy.fovManager.GetStartingAngle(), thresholds[^2]))
                    {
                        enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                }
                break;

            case 2:
                if (IsBetween(enemy.fovManager.GetStartingAngle(), thresholds[^1], thresholds[^2]))
                {
                    enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                break;
        }
    }

    private bool IsLessThan(float a, float b)
    {
        return a < b;
    }

    private bool IsBetween(float x, float a, float b)
    {
        return x > a && x < b;
    }
}
