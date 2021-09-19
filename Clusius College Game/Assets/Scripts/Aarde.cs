using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aarde : MonoBehaviour
{
    Collider col;
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
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
                }
            }
        }
    }
}
