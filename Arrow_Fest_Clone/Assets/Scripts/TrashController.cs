using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    public int TrashChoose, TrashNumber;
    ArrowController arrowController;
    TrashManager trashManager;
    private void Awake()
    {
        arrowController = FindObjectOfType<ArrowController>();
        trashManager = GetComponentInParent<TrashManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InfoChoose();
            StartCoroutine(Delay());


        }



    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }

    void InfoChoose()
    {
        trashManager.ParentChoose = TrashChoose;
        trashManager.ParentNum = TrashNumber;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
        arrowController.LogicalChoose();

    }


}
