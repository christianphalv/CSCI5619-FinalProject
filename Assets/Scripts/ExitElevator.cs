using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitElevator : MonoBehaviour
{
    [SerializeField] private GameObject elevator;
  
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("MainCamera") || other.CompareTag("Player")){
                Debug.Log("deactivate elevator");
                elevator.SetActive(false);
        }            
    }
}
