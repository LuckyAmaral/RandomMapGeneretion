using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPerna : MonoBehaviour
{
    public float escalaMinimaX;
    public float escalaMaximaX;
    public float tempoEntreTrocas = 0.5f;
    private Transform objetoTransform;
    private bool emEscalaMaxima = true;
    // Start is called before the first frame update
    void Start()
    {
        objetoTransform = transform;
        escalaMinimaX = (objetoTransform.localScale.x)*(-1);
        escalaMaximaX = objetoTransform.localScale.x;
    }

    // Update is called once per frame

    void Update(){
        tempoEntreTrocas -= Time.deltaTime;
        if(tempoEntreTrocas < 0){
            emEscalaMaxima = !emEscalaMaxima;
            float novaEscalaX = emEscalaMaxima ? escalaMaximaX : escalaMinimaX;
            objetoTransform.localScale = new Vector3(novaEscalaX, objetoTransform.localScale.y, objetoTransform.localScale.z);
            tempoEntreTrocas = 0.5f;
        }  
    }
}
