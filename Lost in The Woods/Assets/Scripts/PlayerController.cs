using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    private CharacterController controller;
    private Camera playerCamera;
    private Vector3 moveDirection = Vector3.zero;
    private float verticalRotation = 0.0f;
    public Vector3 teleport;
    public bool exorcizo = false;
    public float tempo = 1f;
    public float novaRotacao;
    public Enemy inimigo;
    public Image ui;
    public float mapWidth = 10.0f; // Largura do seu mapa
    public float mapHeight = 10.0f; // Altura do seu mapa
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
// Movimento do jogador
        
        float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * moveSpeed;
        moveDirection = (transform.forward * forwardSpeed) + (transform.right * sideSpeed);
        Color corAtual = ui.color;
        corAtual.a = (tempo-1f)*(-1);
        ui.color = corAtual;
        // Gravidade
        if (!controller.isGrounded)
        {
            moveDirection += Physics.gravity;
        }

        // Rotação da câmera
        if(Time.timeScale != 0){
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        transform.Rotate(0, horizontalRotation, 0);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        }

        // Movimento do jogador
        controller.Move(moveDirection * Time.deltaTime);

        if((exorcizo==true)&&(Input.GetKey(KeyCode.Space))){
            tempo -= Time.deltaTime;
            if(tempo<0){
                transform.position = teleport;
                transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y+novaRotacao,transform.rotation.z);
                tempo = 1f;
                inimigo.transform.position= new Vector3(Random.Range(0f,90f),inimigo.transform.position.y+5f,Random.Range(0f,90f));
                moveSpeed = 5f;
            }
        }
        Vector3 currentPosition = transform.position;

        // Verifica se o objeto saiu da borda direita do mapa
        if (currentPosition.x > mapWidth )
        {
            currentPosition.x = -5f;
        }
        // Verifica se o objeto saiu da borda esquerda do mapa
        else if (currentPosition.x < -5f)
        {
            currentPosition.x = mapWidth / 2;
        }

        // Verifica se o objeto saiu da borda superior do mapa
        if (currentPosition.z > mapHeight)
        {
            currentPosition.z = -5f;
        }
        // Verifica se o objeto saiu da borda inferior do mapa
        else if (currentPosition.z < -5f)
        {
            currentPosition.z = mapHeight;
        }

        // Define a nova posição do objeto
        transform.position = currentPosition;       
    }
    private void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "Evil"){
            exorcizo = true;
        }
    }
    private void OnTriggerExit(Collider collision){
        if(collision.gameObject.tag == "Evil"){
            exorcizo = false;
            tempo = 1f;
            inimigo.speed = 0.02f;
        }
    }
    void OnTriggerStay(Collider collision){
        if(exorcizo == true){
            if (Input.GetKey(KeyCode.Space))
            {
                inimigo.speed = 0.01f;
                moveSpeed = 2.5f;
            }else{
                tempo = 1f;
            }
        }
    }
}
