using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    public List<GameObject> arrows = new List<GameObject>();

    public float distance;
    public float minX = -2, maxX = 2;
    public LayerMask layerMask;
    public GameObject arrowPrefab;
    public Transform parent;


    void Start()
    {

    }


    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            GetRay();
        }

    }

    void MoveArrow(Transform objectArrow, float degree)
    {
        Vector3 pos = Vector3.zero;
        pos.x = Mathf.Cos(degree * Mathf.Deg2Rad);
        pos.y = Mathf.Sin(degree * Mathf.Deg2Rad);
        objectArrow.localPosition = pos * distance;

    }
    void Diz()
    {
        float angle = 1f;
        float arrowCount = arrows.Count;

        angle = 360 / arrowCount;

        for (int i = 0; i < arrowCount; i++)
        {
            MoveArrow(arrows[i].transform, i * angle);
        }


    }


    void GetRay()
    {
        Vector3 mousPos = Input.mousePosition;
        mousPos.z = Camera.main.transform.position.z;

        Ray ray = Camera.main.ScreenPointToRay(mousPos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            Vector3 mouse = hit.point;
            mouse.x = Mathf.Clamp(mouse.x, minX, maxX);

            distance = mouse.x;

            Diz();

        }



    }
}
