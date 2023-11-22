using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cutscene;
    public PlayableDirector timeline;
    public GameObject inimigo;
    void Start()
    {
        timeline = cutscene.GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "Target"){
            timeline.Play();
            StartCoroutine(Restart());
            inimigo.transform.position= new Vector3(-10,-10,-10);
        }
    }
    IEnumerator Restart(){
        yield return new WaitForSeconds(2.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
