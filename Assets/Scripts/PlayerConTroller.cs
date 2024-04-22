﻿using System;
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
    Push _Push;
    Transform Tf_Push;
    bool canMove,isPush;
    [SerializeField] Rigidbody rb;
    private float corner = 0;
    Vector2 start, end;
    Touch touch;
    List<Vector3> listPoint = new List<Vector3>();

    Vector3 targetPosition,vtPush;

    Vector3 PointEnd;
    void Start()
    {
        _Camera = Camera.main;
        canMove = true;
    }

    void Update()
    {
        //CheckWin(Vector3.forward);
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
            if (targetPosition == Vector3.zero&&canMove)
            {
                MoveControl();
            }
            else if (PointEnd == Vector3.zero&&canMove)
            {
                MoveControl();
            }
            else return;

        }
        

        if (targetPosition != Vector3.zero)
        {
            MovePlayer(targetPosition);
            canMove = false;

            if(transform.position == targetPosition)
            {
                canMove = true;
                targetPosition = Vector3.zero;
            }
        }
        else if (PointEnd != Vector3.zero)
        {
            MovePlayer(PointEnd);
            canMove = false;
            if (transform.position == PointEnd)
            {
                canMove = true;
                PointEnd = Vector3.zero;
            }
        }
        else if (isPush)
        {
            CheckPoint(vtPush);


            CheckGround(vtPush);
            Debug.Log(vtPush);
            //CheckPoint(Vector3.forward);
            //CheckPoint(Vector3.left);
            //CheckPoint(Vector3.back);
        }
        
        
        
        

    }
    public void MoveControl()//control move of player
    {
        //cach 1
        Vector2 direction = end - start;
        if (direction.y > 0)//Up
        {
            
            AngleOfTwoVector(start, end);

            if (start.x < end.x)
            {
                if (corner <= 45f)//Forward
                {
                    
                    CheckPoint(Vector3.forward);
                    
                    CheckGround(Vector3.forward);
                    
                    //MovePlayer(PointEnd);
                }
                else if (corner > 45f)//Right
                {
                    
                    CheckGround(Vector3.right);
                    CheckPoint(Vector3.right);
                    //MovePlayer(Vector3.right);
                }

            }
            else if (start.x > end.x)
            {
                if (corner <= 45f)//forward
                {
                    CheckPoint(Vector3.forward);
                    CheckGround(Vector3.forward);
                    
                    //MovePlayer(Vector3.forward);
                }
                else if (corner > 45f)//Left
                {
                    
                    CheckPoint(Vector3.left);
                    CheckGround(Vector3.left);
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
                    CheckGround(Vector3.back);
                    CheckPoint(Vector3.back);
                    
                    //MovePlayer(Vector3.back);
                }
                else if (corner > 45f)//Right
                {
                    
                    CheckGround(Vector3.right);
                    CheckPoint(Vector3.right);
                    //MovePlayer(Vector3.right);
                }
            }
            else if (start.x > end.x)
            {
                if (corner <= 45f)//Backward
                {
                    CheckGround(Vector3.back);
                    CheckPoint(Vector3.back);
                    
                    //MovePlayer(Vector3.back);
                }
                else if (corner > 45f)//left
                {
                    CheckGround(Vector3.left);
                    CheckPoint(Vector3.left);
                    
                    //MovePlayer(Vector3.left);
                }
            }
        }
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
        for(int i = 1;i<50;i++)
        {

            //Debug.DrawLine(transform.position + directionMove * i, transform.position + directionMove * i + Vector3.down * 5f, Color.red, 3f);

            if(Physics.Raycast(transform.position +Vector3.up*2f + directionMove * i, Vector3.down, 5f, layerStack))
            {
                //targetPosition = transform.position + directionMove * i;

            }
            else
            {
                targetPosition = transform.position + directionMove * (i-1);
                //Debug.Log(targetPosition);
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
        
    }
    public void CheckGround(Vector3 directionMove)//Check Ground to player move from position next to the wall
    {
        for (int i = 1; i < 70; i++)
        {
            
            Debug.DrawLine(transform.position + directionMove * i, transform.position + directionMove * i + Vector3.down * 5f, Color.red, 3f);

            if (Physics.Raycast(transform.position + Vector3.up * 2f + directionMove * i, Vector3.down, 5f, layerGround))
            {
                PointEnd = transform.position + directionMove * (i-1);
                
                break;
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Push"))
        {
           
            isPush = true;
            Tf_Push = other.transform;
            //Tf_Push.GetComponent<Push>().CheckDirection();
            
               vtPush = other.GetComponent<Push>().directionWhenTouchPush;
                
            
            
            
            
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Push"))
        {
            isPush = false;
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Debug.DrawLine(transform.position, transform.position + Vector3.forward * 30f, Color.blue, 5f);
    //}
    //public void CheckWin(Vector3 directionMove)
    //{
    //    Debug.DrawLine(transform.position,transform.position + directionMove*30f,Color.blue,5f);
    //    if(Physics.Raycast(transform.position,directionMove , 10f, layerWin))
    //    {
    //        Debug.Log("win");
    //    }
    //}


}
