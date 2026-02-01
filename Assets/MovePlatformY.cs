using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlatformY : MonoBehaviour
{
    InputSystem_Actions inputObj;
    public bool freez = false;
    public Image button;
    Transform lockPosition;
    public float moveSpeed = 2;
    public bool goUp;
    public float min;
    public float max;
    private void Awake()
    {
        inputObj = new InputSystem_Actions();
        inputObj.Enable();
        goUp = true;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveTiles();
    }

    private void FixedUpdate()
    {
        if (inputObj.Player.Power.IsPressed())
        {
            //button.gameObject.SetActive(false);
            

        }

     }


    void moveTiles()
    {
        if(transform.position.y < max && goUp)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            if(transform.position.y >= max)
            {
                Debug.Log("Max Reached");
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


}
