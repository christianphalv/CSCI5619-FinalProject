using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public ImpossibleSpaceManager _impossibleSpaceManager;
    public Section _nextSection;

    private Player _player;
    private Section _section;
    private Renderer _renderer;

    void Start() {

    }

    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Player>()) {
            if (Vector3.Dot(_player.getVelocity().normalized, this.transform.up) < 0) {
                _impossibleSpaceManager.changeSection(_nextSection);
            }
        }
    }

    private void OnTriggerStay(Collider other) {
        
    }

    private void OnDestroy() {
        
    }

    public void initializePortal(Player player) {

        // Initialize properties
        _section = GetComponentInParent<Section>();
        _renderer = GetComponent<Renderer>();
        _player = player;

        // Set stencil reference for next section
        _renderer.material.SetInt("_StencilRef", _nextSection.getId());
    }

    public void activatePortal() {

        // Enable renderer
        GetComponent<Renderer>().enabled = true;

        // Enable rigidbody
        GetComponent<Rigidbody>().detectCollisions = true;
        
    }

    public void deactivatePortal() {

        // Disable renderer
        GetComponent<Renderer>().enabled = false;

        // Disable rigidbody
        GetComponent<Rigidbody>().detectCollisions = false;
    }
}
