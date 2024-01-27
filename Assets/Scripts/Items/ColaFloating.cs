using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaFloating : MonoBehaviour
{
    public GameObject Cola;
    private Vector3 StartingPoint;
    private Vector3 EndingPoint;
    public float MoveSpeed = 0.5f;
    public float MoveDistance = 1f;
    private bool GoToEnd = true;
    
    // Start is called before the first frame update
    void Start()
    {
        StartingPoint = transform.position;
        EndingPoint = new Vector3(StartingPoint.x,StartingPoint.y + MoveDistance,StartingPoint.z);
    }

    // Update is called once per frame
    void Update()
    {
        Floating();
    }

    public void Floating(){
        if(GoToEnd == true){
            transform.position = Vector3.MoveTowards(transform.position,EndingPoint,MoveSpeed*Time.deltaTime);
        }
        else{
            transform.position = Vector3.MoveTowards(transform.position,StartingPoint,MoveSpeed*Time.deltaTime);
        }

        if(Vector3.Distance(transform.position,EndingPoint)<0.001 && GoToEnd == true){
            GoToEnd = false;
        }
        else if(Vector3.Distance(transform.position,StartingPoint)<0.001 && GoToEnd == false){
            GoToEnd = true;
        }
    }
}