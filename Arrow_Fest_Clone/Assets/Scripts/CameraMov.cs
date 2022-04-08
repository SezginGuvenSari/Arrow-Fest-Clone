using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    public Transform target;
    public float lerpValue;
    public Vector3 offset;


    private void LateUpdate()
    {
        Vector3 desPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, desPos, lerpValue);
    }
}
