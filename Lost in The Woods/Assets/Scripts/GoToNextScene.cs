using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GoToNextScene: MonoBehaviour {
    public float timeToGo = 5.16f;
    public int sena = 1;
void Start(){
    StartCoroutine (NextScene());
}

void Update(){}
IEnumerator NextScene(){
    yield return new WaitForSeconds(timeToGo);
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sena);
}

}
