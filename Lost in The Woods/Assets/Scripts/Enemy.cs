using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public GameObject player;
    public float speed;
    public int aditionalSpeed = 0;
    public float rotationSpeed;
    public float multiply = 0.008f;
    public float distance;
    private Animator enemyAnim;
    private Rigidbody durinho;
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        durinho = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if(Time.timeScale != 0){
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position, speed+(aditionalSpeed*multiply));
Vector3 targetDirection = player.transform.position - transform.position;
targetDirection.y = 0; // Define a componente Y para 0

Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        if(distance > 17.5f){
            speed = 0.1f;
        }else{
            speed = 0.03f;
        }
        if(distance > (45-(5*aditionalSpeed))){
            durinho.isKinematic = true;
        }else{
            durinho.isKinematic = false;
        }
    }   
    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "Target"){
            enemyAnim.SetBool("IsClose",true);
            speed = 0;
            multiply = 0;
        }
    }
    void OnTriggerExit(Collider collision){
        if(collision.gameObject.tag == "Target"){
            enemyAnim.SetBool("IsClose",false);
            //speed = 0.03f;
            multiply = 0.008f;
        }
    }
}
