using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ColliderHandle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float levelDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.gameObject.name}+{other.gameObject.name   }");
        StartCrashSequence();
    }
    void StartCrashSequence()
    {
        crashVFX.Play();
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        GetComponentInChildren<MeshRenderer>().enabled = false;

        Invoke("ReloadLevel", levelDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //GetActiveScene(): Hàm này trả về Scene hiện tại mà người chơi đang chơi trong game
        //buildIndex:  trả về chỉ số (index) của Scene 
        SceneManager.LoadScene(currentSceneIndex);
    }


}
