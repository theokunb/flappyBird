using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] Bird _bird;
    [SerializeField] float _xOffset;

    private void Update()
    {
        transform.position = new Vector3(_bird.transform.position.x - _xOffset, transform.position.y, transform.position.z);
    }
}
