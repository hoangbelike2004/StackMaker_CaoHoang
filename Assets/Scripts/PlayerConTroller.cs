using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MoveDirection
{
    Right,
    Left,
    Backward,
    Forward,
}
public class PlayerConTroller : MonoBehaviour
{
    [SerializeField] private Camera _Camera;
    [SerializeField] private LayerMask layerStack;
    [SerializeField] private LayerMask layerGround;
    [SerializeField] private float moveSpeed= 10f;
    private float corner = 0;
    Vector2 start, end;
    Touch touch;
    List<Vector3> listPoint = new List<Vector3>();

    Vector3 targetPosition;

    Vector3 PointEnd;
    void Start()
    {
        _Camera = Camera.main;
    }

    void Update()
    {
        
        //if (Input.touchCount > 0)
        //{
        //    touch = Input.GetTouch(0);
        //}
        //switch (touch.phase)
        //{
        //    case TouchPhase.Began:
        //        start = Input.mousePosition;
        //        break;
        //    case TouchPhase.Ended:
        //        end = Input.mousePosition;
        //        MoveControl();
        //        break;
        //}
        if (Input.GetMouseButtonDown(0))
        {
            start = Input.mousePosition;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            end = Input.mousePosition;
            if (targetPosition == Vector3.zero)
            {
                MoveControl();
            }
            else return;
            

        }

        if (targetPosition != Vector3.zero)
        {
            MovePlayer(targetPosition);
            if(transform.position == targetPosition)
            {
                targetPosition = Vector3.zero;
            }
        }

    }
    public void MoveControl()
    {
        //cach 1
        Vector2 direction = end - start;
        if (direction.y > 0)//Up
        {
            Debug.Log("up");
            AngleOfTwoVector(start, end);

            if (start.x < end.x)
            {
                if (corner <= 45f)//Forward
                {
                    CheckPoint(Vector3.forward);
                    Debug.Log("Forward");
                    //MovePlayer(PointEnd);
                }
                else if (corner > 45f)//Right
                {
                    Debug.Log("Right");
                    CheckPoint(Vector3.right);
                    //MovePlayer(Vector3.right);
                }

            }
            else if (start.x > end.x)
            {
                if (corner <= 45f)//forward
                {
                    CheckPoint(Vector3.forward);
                    Debug.Log("Forward");
                    //MovePlayer(Vector3.forward);
                }
                else if (corner > 45f)//Left
                {
                    Debug.Log("Left");
                    CheckPoint(Vector3.left);
                    //MovePlayer(Vector3.left);
                }
            }
        }
        if (direction.y < 0)//down
        {
            AngleOfTwoVector(start, end);
            if (start.x < end.x)
            {
                if (corner <= 45f)//Backward
                {
                    CheckPoint(Vector3.back);
                    Debug.Log("Backward");
                    //MovePlayer(Vector3.back);
                }
                else if (corner > 45f)//Right
                {
                    Debug.Log("Right");
                    CheckPoint(Vector3.right);
                    //MovePlayer(Vector3.right);
                }
            }
            else if (start.x > end.x)
            {
                if (corner <= 45f)//Backward
                {
                    CheckPoint(Vector3.back);
                    Debug.Log("Backward");
                    //MovePlayer(Vector3.back);
                }
                else if (corner > 45f)//left
                {
                    CheckPoint(Vector3.left);
                    Debug.Log("Left");
                    //MovePlayer(Vector3.left);
                }
            }
        }
    }
    public void MoveControl2()
    {
        AngleOfTwoVector(start, end);
        Debug.Log("corner: "+corner);
    }
    public void MovePlayer(Vector3 newvec)
    {
        transform.position = Vector3.MoveTowards(transform.position, newvec, moveSpeed*Time.deltaTime);
        
    }
    
    public void AngleOfTwoVector(Vector2 newStart,Vector2 newEnd) 
    {
        Vector2 pointHidden = new Vector2(newStart.x, newEnd.y);
        Vector2 sp = new Vector2((pointHidden.x - newStart.x), (pointHidden.y - newStart.y));
        Vector2 se = new Vector2((newEnd.x - newStart.x), (newEnd.y - newStart.y));
        corner = Vector2.Angle(sp, se);

    }
    public void CheckPoint(Vector3 directionMove)
    {
        for(int i = 1;i<20;i++)
        {

            Debug.DrawLine(transform.position + directionMove * i, transform.position + directionMove * i + Vector3.down * 5f, Color.red, 3f);

            if(Physics.Raycast(transform.position +Vector3.up*2f + directionMove * i, Vector3.down, 5f, layerStack))
            {
                var savePoint = transform.position + directionMove * i;
                listPoint.Add(savePoint);
            }
            else
            {
                targetPosition = transform.position + directionMove * (i - 1);
                break;
            }
           
            //Ray ray = new Ray(new Vector3(transform.position.x, 3f, transform.position.z) + directionMove * i, Vector3.down);
            //Debug.Log(ray.origin);
            //if (Physics.Raycast(ray, out hit, 10f, layerStack))
            //{
            //    var savePointStack = hit.collider.transform.position;//hit.collidder.transform.position
            //    savePointStack.y = 0;
            //    listPoint.Add(savePointStack);
            //    PointEnd = listPoint[listPoint.Count - 1];
            //    listPoint.Clear();


            //    if (Physics.Raycast(ray, out hit, 10f, layerGround))
            //    {
            //        PointEnd = listPoint[listPoint.Count - 1];
            //        listPoint.Clear();
            //        Debug.Log(PointEnd);
            //        break;
            //    }

            //}
        }
        PointEnd = listPoint[listPoint.Count - 1];
        listPoint.Clear();

    }

}
