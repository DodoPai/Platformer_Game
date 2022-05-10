using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidBody;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if(isFacingRight())
        {
            myRigidBody.velocity = new Vector2(moveSpeed,0f);

        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed,0f);
        }
        
    }

    bool isFacingRight()
    {
        return transform.localScale.x>0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2 (-(Mathf.Sign(myRigidBody.velocity.x)),1f);
    }






}
