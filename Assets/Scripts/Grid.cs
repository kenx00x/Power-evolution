using UnityEngine;
public class Grid : MonoBehaviour
{
    public float size = 1f;
    public float xmin = -5f;
    public float xmax = 5f;
    public float zmin = -5f;
    public float zmax = 5f;
    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;
        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);
        Vector3 result = new Vector3(
            (float)xCount * size,
            (float)yCount * size,
            (float)zCount * size);
        result += transform.position;
        return result;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = xmin; x <= xmax; x += size)
        {
            for (float z = zmin; z <= zmax; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }
}