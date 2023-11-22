using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoUp : MonoBehaviour
{
    public GameObject teleporter;
    public TextMeshProUGUI quantidade;
    private int Numero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int.TryParse(quantidade.text, out Numero); 
        if(Numero >= 5){
            Spawn();
            quantidade.text = "S";
        }
    }
    public void Spawn(){
        Instantiate(teleporter,new Vector3(50.98f,0.05f,43.49f),Quaternion.identity);
    }
}
