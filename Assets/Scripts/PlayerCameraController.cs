using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> cameras;


    private void ChangeCamera(int index)
    {
        foreach (CinemachineVirtualCamera cam in cameras) 
        {
            cam.Priority = 0;
        }
        cameras[index].Priority = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraTrigger1"))
        {
            ChangeCamera(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraTrigger1"))
        {
            ChangeCamera(0);
        }
    }
}
