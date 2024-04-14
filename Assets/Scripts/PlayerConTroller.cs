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
    private float corner = 0;
    Vector2 start, end;
    Touch touch;
    void Start()
    {
        _Camera = Camera.main;
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
           touch = Input.GetTouch(0);
        }
        switch (touch.phase)
        {
            case TouchPhase.Began:
                start = Input.mousePosition;
                break;
            case TouchPhase.Ended:
                end = Input.mousePosition;
                MoveControl();
                break;
        }
        //if(Input.GetMouseButtonDown(0))
        //{
        //    start = Input.mousePosition;

        //}
        //else if(Input.GetMouseButtonUp(0))
        //{
        //    end = Input.mousePosition;


        //}
           
           
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
                    Debug.Log("Forward");
                    MovePlayer(Vector3.forward);
                }
                else if (corner > 45f)//Right
                {
                    Debug.Log("Right");
                    MovePlayer(Vector3.right);
                }

            }
            else if (start.x > end.x)
            {
                if (corner <= 45f)//forward
                {
                    Debug.Log("Forward");
                    MovePlayer(Vector3.forward);
                }
                else if (corner > 45f)//Left
                {
                    Debug.Log("Left");
                    MovePlayer(Vector3.left);
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
                    Debug.Log("Backward");
                    MovePlayer(Vector3.back);
                }
                else if (corner > 45f)//Right
                {
                    Debug.Log("Right");
                    MovePlayer(Vector3.right);
                }
            }
            else if (start.x > end.x)
            {
                if (corner <= 45f)//Backward
                {
                    Debug.Log("Backward");
                    MovePlayer(Vector3.back);
                }
                else if (corner > 45f)//left
                {
                    Debug.Log("Left");
                    MovePlayer(Vector3.left);
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
        transform.position += newvec*Time.deltaTime*2f;
    }
    public void AngleOfTwoVector(Vector2 newStart,Vector2 newEnd) 
    {
        Vector2 pointHidden = new Vector2(newStart.x, newEnd.y);
        Vector2 sp = new Vector2((pointHidden.x - newStart.x), (pointHidden.y - newStart.y));
        Vector2 se = new Vector2((newEnd.x - newStart.x), (newEnd.y - newStart.y));
        corner = Vector2.Angle(sp, se);

    }
}
