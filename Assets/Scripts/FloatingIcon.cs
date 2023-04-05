using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingIcon : MonoBehaviour
{
    [SerializeField] Transform rotatingTransform;
    public float rotateSpeed = 1f;

    private void Start()
    {

    }

    private void Update()
    {
        rotatingTransform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
