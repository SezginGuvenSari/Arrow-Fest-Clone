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
    public int Choose,Number;
    public bool isDecrease = false;
    public int speed;
    public Rigidbody rb;
   


    void Update()
    {
        Move();
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


    public void LogicalChoose()
    {
        // 1-Addition
        // 2-Subtraction
        // 3-Multiplication
        // 4-Division

        switch (Choose)
        {
            case 1:
                CreateArrow();
                break;

            case 2:
                DestroyArrow();
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }

    void CreateArrow()
    {
        for (int i = 0; i < Number; i++)
        {
            GameObject g = Instantiate(arrowPrefab, parent);
            arrows.Add(g);
            g.transform.localPosition = Vector3.zero;
        }
        isDecrease = false;
        Diz();
    }


    void DestroyArrow()
    {
      
        for (int i = 0; i < Number; i++)
        {
            GameObject g = arrows[arrows.Count - 1];
            arrows.RemoveAt(arrows.Count - 1);
            Destroy(g);
        }
        Diz();
    }

    private void Move()
    {
        rb.velocity = Vector3.forward * speed * Time.deltaTime;
    }
}
