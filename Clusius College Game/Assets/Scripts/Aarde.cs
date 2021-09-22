using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aarde : MonoBehaviour
{
    [SerializeField] Collider col;
    [SerializeField] Camera mainCamera;
    [SerializeField] bool holdsShuffol = true;
    [SerializeField] bool holdsSeed;
    [SerializeField] bool dirtHasSeed;
    [SerializeField] GameObject hole;
    [SerializeField] Vector2 tempClickpunt;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            Vector3 clickpunt = touch.position;
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(clickpunt);

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Player")
            {
                if (touch.phase == TouchPhase.Began)
                {
                    tempClickpunt = touch.position;
                    Debug.Log("aarde is geklikt");

                    if (holdsShuffol && dirtHasSeed == false)
                    {
                        Debug.Log("aarde is gegraven");
                        hole.SetActive(false);
                        holdsShuffol = false;
                        holdsSeed = true;
                    } 
                    else if (holdsSeed && dirtHasSeed == false)
                    {
                        Debug.Log("aarde heeft zaadje");
                        holdsShuffol = true;
                        holdsSeed = false;
                        dirtHasSeed = true;
                    }
                    else if (holdsShuffol && dirtHasSeed == true)
                    {
                       /* Debug.Log("gat is dicht is dicht");
                        hole.SetActive(true);*/
                    }
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    if (holdsShuffol && dirtHasSeed == true)
                    {
                        if (Vector2.Distance(tempClickpunt,touch.position) > 15) 
                        {
                            Debug.Log("gat is dicht is dicht");
                            hole.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
