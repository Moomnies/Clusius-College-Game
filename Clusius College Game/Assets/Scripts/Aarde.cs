using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aarde : MonoBehaviour
{
    Collider col;
    public Camera mainCamera;
    public bool holdsShuffol;
    public bool holdsSeed;
    public bool dirtHasSeed;
    public GameObject hole;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
        hole = GameObject.Find("Hole");
        holdsShuffol = true;
    }

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
                    Debug.Log("aarde is geklikt");

                    if (holdsShuffol && dirtHasSeed == false)
                    {
                        Debug.Log("aarde is gegraven");
                        hole.active = false;
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
                        Debug.Log("gat is dicht is dicht");
                        hole.active = true;
                    }
                }
            }
        }
    }
}
