using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] public GameObject player;
    public float speed;
    public float rotationSpeed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position, speed);
Vector3 targetDirection = player.transform.position - transform.position;
targetDirection.y = 0; // Define a componente Y para 0

Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            speed = 0;
        }
    }
    void OnCollisionExit(Collision collision){
        if(collision.gameObject.tag == "Player"){
            speed = 0.01f;
        }
    }
}
