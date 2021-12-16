using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateElevator : MonoBehaviour
{
    [SerializeField] private GameObject elevator;
    [SerializeField] private Section thisSection;
    
    // Start is called before the first frame update
    void Update(){
        if(thisSection._isActive){
            elevator.SetActive(true);
        }
        else{
            elevator.SetActive(false);
        }
        
    }
}
