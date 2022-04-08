using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    public int ParentNum, ParentChoose;
    ArrowController arrowController;

    private void Awake()
    {
        arrowController = FindObjectOfType<ArrowController>();
    }
    void Update()
    {
        InfoItems();
    }



    void InfoItems()
    {
        arrowController.Choose = ParentChoose;
        arrowController.Number = ParentNum;

    }
}
