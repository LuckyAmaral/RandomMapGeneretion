using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private int[] anglo ={0,90,270,180};
    public int rotacao;
    public bool calcular;
    [SerializeField] public bool Rodar;
    [SerializeField] GameObject[] instances;
    public List<GameObject> listaFiltrada;
    [SerializeField] public PlayerController jogador;
    public float tpXlocation;
    public float tpZlocation;
    public int randomIndex;
    // Start is called before the first frame update
    void Start()
    {
        instances = GameObject.FindGameObjectsWithTag(gameObject.tag);
        listaFiltrada = new List<GameObject>(instances);
        listaFiltrada.Remove(gameObject);
        if(Rodar == true){
            rotacao = anglo[Random.Range(0,anglo.Length)];
            Quaternion randomRotation = Quaternion.Euler(0,rotacao,0);
            transform.rotation = randomRotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tilePosition = new Vector3(transform.position.x,transform.position.y-0.1f,transform.position.z);

            // A posição do raio começa logo acima do jogador
        Vector3 rayOrigin = tilePosition + Vector3.up * 0.1f;

            // A direção do raio é para baixo
        Vector3 rayDirection = Vector3.down;
        listaFiltrada.RemoveAll(item => item == null);

        Ray ray = new Ray(rayOrigin, rayDirection);
        RaycastHit hit;
        Debug.DrawRay(rayOrigin, rayDirection * 10f, Color.red, 1f);
        if (Physics.Raycast(ray, out hit, 10f)){
            if (hit.collider.CompareTag("Preset"))
                {
                    Destroy(gameObject);
                }
        }
        if(calcular == true){
        jogador.teleport = new Vector3(listaFiltrada[randomIndex].transform.position.x, 
        jogador.transform.position.y,
        listaFiltrada[randomIndex].transform.position.z);
        //corrigir
        /*if(rotacao == 0){
            tpXlocation = jogador.transform.position.x - transform.position.x;
            tpZlocation = jogador.transform.position.z - transform.position.z;
        } else if(rotacao == 90){
            tpXlocation = jogador.transform.position.z - transform.position.z;
            tpZlocation = (jogador.transform.position.x - transform.position.x)*(-1);
        }else if(rotacao == 180){
            tpXlocation = (jogador.transform.position.x - transform.position.x)*(-1);
            tpZlocation = (jogador.transform.position.z - transform.position.z)*(-1);
        }else if(rotacao == 270){
            tpXlocation = (jogador.transform.position.z - transform.position.z)*(-1);
            tpZlocation = jogador.transform.position.x - transform.position.x;
        }*/
        }
    }
    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "Player"){
            calcular = true;
            jogador.novaRotacao = rotacao;
            randomIndex = Random.Range(0, listaFiltrada.Count);
        }
    }
    private void OnTriggerExit(Collider collision){
        if(collision.gameObject.tag == "Player"){
            calcular = false;
        }
    }
}
