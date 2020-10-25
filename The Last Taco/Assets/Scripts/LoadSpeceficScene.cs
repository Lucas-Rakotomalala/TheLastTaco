using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpeceficScene : MonoBehaviour
{
    public string sceneName;
    public Animator fadeSystem;

    private void Awake() 
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collission)
    {
        if(collission.CompareTag("Player"))
        {
            StartCoroutine(loadNextScene());
        }
    }

    public IEnumerator loadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
