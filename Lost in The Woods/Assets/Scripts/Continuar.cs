using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continuar : MonoBehaviour
{
    public GameObject textPagina;
    // Start is called before the first frame update
    void Start()
    {
        textPagina.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Continue(){
        Time.timeScale = 1;
        textPagina.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
