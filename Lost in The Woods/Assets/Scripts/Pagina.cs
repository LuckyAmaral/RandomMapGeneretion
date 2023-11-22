using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pagina : MonoBehaviour
{
    public TextMeshProUGUI quantidade;
    public string Backstorie;
    private int Numero;
    public Enemy inimigo;
    public GameObject final;
    public GameObject textPagina;
    public TextMeshProUGUI valor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int.TryParse(quantidade.text, out Numero); 
    }
    void OnTriggerStay(Collider collision){
        if(collision.gameObject.tag == "Player"){
            if(Input.GetKey(KeyCode.E)){
                Destroy(gameObject);
                inimigo.aditionalSpeed++;
                Numero++;
                quantidade.text = Numero.ToString();
                Time.timeScale = 0;
                textPagina.SetActive(true);
                valor.text = Backstorie;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        } 
    }
}
