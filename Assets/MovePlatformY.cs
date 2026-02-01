using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;

public class MovePlatformY : MonoBehaviour
{
    public static InputSystem_Actions inputObj;
    public static bool freez = false;
    public Image button;
    public float moveSpeed = 2;
    public bool goUp;
    public float min;
    public float max;
    public static bool move = true;
    float timer = 3f;
    bool hasStartedFreeze = false;
    private void Awake()
    {
        inputObj = new InputSystem_Actions();
        inputObj.Enable();
        goUp = true;

    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        if (freez && !hasStartedFreeze)
        {
            hasStartedFreeze = true;
            move = false;
            StartCoroutine(freezePlatform());
        }

        if (move)
        {
            moveTiles();
        }

    }


    void moveTiles()
    {
        if(transform.position.y < max && goUp)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            if(transform.position.y >= max)
            {
                //Debug.Log("Max Reached");
                goUp = false;
            }
            
        }
        else if(goUp == false)
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            if(transform.position.y <= min)
            {
                goUp = true;
            }
        }
        //if(transform.position)
    }

    IEnumerator freezePlatform()
    {
        button.gameObject.GetComponent<OnScreenButton>().enabled = false;
        button.gameObject.GetComponent<Image>().color = Color.black;
        yield return new WaitForSeconds(timer);
        button.gameObject.GetComponent<Image>().color = Color.white;
        button.gameObject.GetComponent<OnScreenButton>().enabled = true;
        freez = false;
        move = true;
        hasStartedFreeze = false;
    }


}
