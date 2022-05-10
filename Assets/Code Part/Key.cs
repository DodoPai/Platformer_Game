using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isFollowing;

    public float followSpeed;

    public Transform followTarget; //anahtarın takip etmesi gereken mesafe için.
    
    void Start()
    {
        
    }

  
    void Update()
    {
        if(isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position,followSpeed *Time.deltaTime);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Hero")
        {
            if(!isFollowing)
            {
                hero thePlayer = FindObjectOfType<hero>();
                followTarget = thePlayer.keyFollowPoint;
                isFollowing = true;
            }
        }
    }
}
