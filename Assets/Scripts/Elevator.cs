using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    [SerializeField] private GameObject frontWall;

    private Vector3 elevatorClosedPos;
    private Vector3 elevatorOpenPos;
    private float duration = 1.0f;
    private float elevatorWaitTime = 4f;
    [SerializeField] private GameObject exitElevator;

    void Awake(){

        
    }

    // Start is called before the first frame update
    void Start()
    {
        elevatorClosedPos = new Vector3(0, 0, -0.625f);
        elevatorOpenPos = new Vector3(-1.45f, 0, -0.625f);
        
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("MainCamera") || other.CompareTag("Player")){
            Scene currentScene = SceneManager.GetActiveScene();            
            if(currentScene.buildIndex < SceneManager.sceneCountInBuildSettings){
                DontDestroyOnLoad(this.gameObject);
                StartCoroutine(MoveElevatorDoor(currentScene.buildIndex + 1));
                exitElevator.SetActive(true);
            }            
        }
    }

    IEnumerator MoveElevatorDoor(int index){
        frontWall.SetActive(true);
        frontWall.transform.localPosition = elevatorOpenPos;
        float time = 0;

        while (time < duration)
        {
            frontWall.transform.localPosition = Vector3.Lerp(elevatorOpenPos, elevatorClosedPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        frontWall.transform.localPosition = elevatorClosedPos;
        SceneManager.LoadScene(index);

        //if(index == 1){
           // Debug.Log("SET NEW PARENT");
            //SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetSceneByBuildIndex(index));
            //this.transform.SetParent(GameObject.Find("ImpossibleSpace").transform.GetChild(0).transform);
       // }
        // else if(index == 2){
        //     Debug.Log("SET NEW PARENT");
        //     SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
        //     this.transform.SetParent(GameObject.Find("Level_2_1").transform);
        // }
        
        StartCoroutine(ElevatorWaitTime());
       // StartCoroutine(OpenElevator());
    }

    IEnumerator OpenElevator(){
        frontWall.transform.localPosition = elevatorClosedPos;
        float time = 0;

        while (time < duration)
        {
            frontWall.transform.localPosition = Vector3.Lerp(elevatorClosedPos, elevatorOpenPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        frontWall.transform.localPosition = elevatorOpenPos;
        frontWall.SetActive(false);
       // this.gameObject.SetActive(false);
    }

    IEnumerator ElevatorWaitTime(){
        yield return new WaitForSeconds(elevatorWaitTime);
        StartCoroutine(OpenElevator());
    }

}
