using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGrid : MonoBehaviour
{
    [SerializeField] private int _width, _heigth;
    [SerializeField] private GameObject[] _tilePrefab;
    private List<GameObject> _availablePrefabs;
    public PlayerController player;
    public Tile azulejo;
    // Start is called before the first frame update
    void Start()
    {
        _availablePrefabs = new List<GameObject>(_tilePrefab);
       GenerateGrid() ;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void GenerateGrid(){
        for(int x=0;x<_width;x++){
            for(int y=0;y<_heigth;y++){
                int randomIndex = Random.Range(0, _availablePrefabs.Count);
                var spawnedTile = Instantiate(_availablePrefabs[randomIndex],new Vector3(x*10+5,0,y*10+5),Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                azulejo = spawnedTile.gameObject.GetComponent<Tile>();
                azulejo.jogador = player;
                if(_availablePrefabs.Count == 1){
                   _availablePrefabs = new List<GameObject>(_tilePrefab);
                }
                if(randomIndex != 0){
                    _availablePrefabs.RemoveAt(randomIndex);
                }
            }
        }
    }
}
