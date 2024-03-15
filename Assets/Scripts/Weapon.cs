using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    public float demage = 1f;

    void Start() {
        Destroy(gameObject, 1);
    }

    void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * Vector3.up;
    }
}
