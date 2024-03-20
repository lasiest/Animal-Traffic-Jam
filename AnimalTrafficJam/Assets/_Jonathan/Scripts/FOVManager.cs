using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVManager : MonoBehaviour
{
    [SerializeField] private playerController playerController;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float fovRadius = 90f;
    [SerializeField] private float viewDistance = 10f;

    private Mesh mesh;
    private Vector3 origin;
    private float startingAngle;

    private void Start()
    {
        CreateFOVMesh();
    }

    private void LateUpdate()
    {
        SetFOVMesh();
    }

    private void CreateFOVMesh()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void SetFOVMesh()
    {
        int rayCount = 50;
        float currentAngle = startingAngle;
        float angleIncrease = fovRadius / rayCount;

        // segitiga
        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;

            RaycastHit2D raycastHit2d = Physics2D.Raycast(origin, GetVectorFromAngle(currentAngle), viewDistance, layerMask);

            if (raycastHit2d.collider == null)
            {
                vertex = origin + GetVectorFromAngle(currentAngle) * viewDistance;
            }
            else
            {
                if (raycastHit2d.collider.gameObject.CompareTag("Player"))
                {
                    playerController.playerCaught = true;
                }
                vertex = raycastHit2d.point;
            }            

            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            currentAngle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
    }

    private Vector3 GetVectorFromAngle(float angle)
    {
        float angleRadius = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRadius), Mathf.Sin(angleRadius));
    }

    public float GetAngleFromVector(Vector3 direction)
    {
        direction = direction.normalized;
        float temp = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (temp < 0)
        {
            temp += 360;
        }

        return temp;
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetDirection(Vector3 direction)
    {      
        startingAngle = GetAngleFromVector(direction) + fovRadius / 2f;
    }

    public void SetDirectionSmoothly(float rotateSpeed)
    {
        startingAngle += Time.deltaTime * rotateSpeed;
    }

    public float GetStartingAngle()
    {
        return startingAngle;
    }

    public void SetStartingAngle(float angle)
    {
        startingAngle = angle;
    }
}
