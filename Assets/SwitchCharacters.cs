using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacters : MonoBehaviour
{
    public bool switched;


    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerMovement.playerControl.Player.Interact.triggered)
        {
            Debug.Log("E has been Pressedl");
        }
    }


 
    

}
