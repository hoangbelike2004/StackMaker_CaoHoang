using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private LayerMask Player;
    [SerializeField] private LayerMask Ground;
    public Vector3 directionWhenTouchPush;

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position + Vector3.up * 2.6f, transform.position + Vector3.up * 2.5f + Vector3.right,Color.red,2f);
        Debug.DrawLine(transform.position + Vector3.up * 2.5f, transform.position + Vector3.up * 2.5f + Vector3.back, Color.red, 2f);
    }
    
    public void CheckDirection()
    {
        if(Physics.Raycast(transform.position, Vector3.right, 2f, Ground))
        {
            
        }
        else if (Physics.Raycast(transform.position, Vector3.right, 2f, Player))
            {
               
            }
            else
            {
                directionWhenTouchPush = Vector3.right;
            }
        

        if (Physics.Raycast(transform.position, Vector3.left, 2f, Ground))
        {
            
        }
        else if (Physics.Raycast(transform.position, Vector3.left, 2f, Player))
            {
               
            }
            else
            {
                directionWhenTouchPush = Vector3.left;
            }
        

        if (Physics.Raycast(transform.position , Vector3.back, 2f, Ground))
        {
            
        }
        else if (Physics.Raycast(transform.position , Vector3.back, 2f, Player))
            {
                
            }
            else
            {
                directionWhenTouchPush = Vector3.back;
            }
        


        if (Physics.Raycast(transform.position , Vector3.forward, 2f, Ground))
        {
            
        }
        else if (Physics.Raycast(transform.position , Vector3.forward, 2f, Player))
        {
                
        }
        else
        {
                directionWhenTouchPush = Vector3.forward;
        }
        
    }
}
