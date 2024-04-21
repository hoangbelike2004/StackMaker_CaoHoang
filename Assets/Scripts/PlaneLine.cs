using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneLine : MonoBehaviour
{
    [SerializeField] private GameObject PlaneActive;
    [SerializeField] private LayerMask Player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlaneActive.SetActive(true);
            //Invoke(nameof(ActivePlane), .05f);
        }
    }

    private void ActivePlane()
    {
        PlaneActive.SetActive(true);
    }
    //private IEnumerator Start()
    //{
    //    while (true) {
    //        StartCoroutine(PlaneAticve());
    //        yield return null;
    //    }
    //}
    //IEnumerator PlaneAticve() {
    //    Ray ray = new Ray(transform.position, Vector3.up);
    //    RaycastHit hit;
    //    Debug.DrawRay(transform.position, Vector3.up * 2f, Color.red, 3f);
    //    if (Physics.Raycast(transform.position, transform.position + Vector3.up * 2f, Player))
    //    {
    //        Debug.Log("Cham");
    //        PlaneActive.SetActive(true);
    //    }
    //    yield return null;
    //}
}
