using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float xMin;
    [SerializeField] float xMax;
    void Update()
    {
        
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, xMin, xMax), transform.position.y, transform.position.z);
    }
    
}
