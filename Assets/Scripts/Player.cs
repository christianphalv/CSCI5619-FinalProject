using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Vector3 _previousPosition;
    private Vector3 _velocity;
    
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
    void Start() {
        _previousPosition = this.transform.position;
        _velocity = Vector3.zero;
    }

    void Update() {
        _velocity = this.transform.position - _previousPosition;
        _previousPosition = this.transform.position;
    }

    public Vector3 getVelocity() {
        return _velocity;
    }
}
