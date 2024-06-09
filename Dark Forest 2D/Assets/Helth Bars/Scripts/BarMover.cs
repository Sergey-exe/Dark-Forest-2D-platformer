using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMover : MonoBehaviour
{
    [SerializeField] private Transform _essenceTransform;
    [SerializeField] private float _barForce;

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, _essenceTransform.position, _barForce * Time.deltaTime);
    }
}
