using System.Collections;
using UnityEngine;

public class Scaner : MonoBehaviour
{
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _ignoreMask;
    [SerializeField] private int _rays;
    [SerializeField] private float _distance;
    [SerializeField] private float _angle;
    [SerializeField] private Transform _rayPoint;

    private int _invert = 1;

    public void RayDirectionFlip()
    {
        _invert *= -1;
    }

    private bool GetRay(Vector2 direction)
    {
        bool result = false;

        RaycastHit2D hit = Physics2D.Raycast(_rayPoint.position, direction, _distance, ~_ignoreMask);

        if (hit.collider != null)
        {
            if (CheckObject(hit.collider.gameObject))
            {
                result = true;
                Debug.DrawLine(_rayPoint.position, hit.point, Color.green);
            }
            else
            {
                Debug.DrawLine(_rayPoint.position, hit.point, Color.blue);
            }
        }
        else
        {
            Debug.DrawRay(_rayPoint.position, direction * _distance, Color.red);
        }
        return result;
    }

    private bool CheckObject(GameObject @object)
    {
        if (((1 << @object.layer) & _targetMask) != 0)
        {
            return true;
        }

        return false;
    }

    public bool Scan()
    {
        bool hit = false;
        float graph = 0;

        for (int i = 0; i < _rays; i++)
        {
            var x = Mathf.Sin(graph);
            var y = Mathf.Cos(graph);

            graph += _angle * Mathf.Deg2Rad / _rays * _invert;

            if (x != 0)
            {
                if (GetRay(_rayPoint.TransformDirection(new Vector3(y, -x, 0)))) 
                    hit = true;
            }

            if (GetRay(_rayPoint.TransformDirection(new Vector3(y, x, 0))))
                hit = true;
        }

        return hit;
    }
}