using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Transform playerTransform;
    private void Update()
    {
        transform.position = playerTransform.position + Vector3.forward * -10f;
    }
}
