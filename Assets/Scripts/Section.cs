using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering;

public class Section : MonoBehaviour {

    public int _sectionNumber;

    private Portal[] _portals;
    private Renderer[] _renderers;
    private bool _isActive;
    

    void Start() {

    }

    void Update() {

    }

    public void initializeSection(Player player) {
        
        // Initialize properties
        _portals = GetComponentsInChildren<Portal>();
        _renderers = GetComponentsInChildren<Renderer>();

        // Set stencil ref for this section
        foreach (Renderer renderer in _renderers) {
            renderer.material.SetInt("_StencilRef", _sectionNumber);
        }

        // Initialize portals
        foreach (Portal portal in _portals) {
            portal.initializePortal(player);
        }

        // Deactivate by default
        deactivateSection();
    }

    public void activateSection() {

        // Activate portals
        foreach (Portal portal in _portals) {
            portal.activatePortal();
        }

        // Activate materials
        foreach (Renderer renderer in _renderers) {
            renderer.material.SetInt("_StencilComp", (int) CompareFunction.Always);
        }

        // Set to active
        _isActive = true;
    }

    public void deactivateSection() {

        // Deactivate portals
        foreach (Portal portal in _portals) {
            portal.deactivatePortal();
        }

        // Deactivate materials
        foreach (Renderer renderer in _renderers) {
            renderer.material.SetInt("_StencilComp", (int) CompareFunction.Equal);
        }

        // Set to inactive
        _isActive = false;
    }

    public int getId() {
        return _sectionNumber;
    }

    public bool isActive() {
        return _isActive;
    }


}
