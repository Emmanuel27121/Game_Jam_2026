using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectSpikes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            GameManager.died = true;
            StartCoroutine(reloadScene());
            MovePlatformY.inputObj.Disable();
            PlayerMovement.playerControl.Disable();
        }
    }


    IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(0.4f);
        StopAllCoroutines();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
