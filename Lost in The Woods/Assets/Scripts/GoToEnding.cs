using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GoToEnding: MonoBehaviour {
void Start(){
}

void Update(){}

private void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "Target"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
