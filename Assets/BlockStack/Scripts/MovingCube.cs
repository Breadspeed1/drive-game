using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour {
    public static MovingCube currentCube { get; private set; }

    private void OnEnable() {
        currentCube = this;
    }
    
    [SerializeField] private float moveSpeed = 1f;
    
    // Update is called once per frame
    void Update() {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }

    public void stop() {
        moveSpeed = 0f;
    }
}
