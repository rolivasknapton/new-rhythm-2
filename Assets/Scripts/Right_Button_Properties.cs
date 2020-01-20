﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Button_Properties : songInput
{
    private bool notes_onscreen;

    // Start is called before the first frame update
    

    // Update is called once per frame
    public override void Find_Touch_Position()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            //this is a way to draw lines
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            Debug.DrawLine(Vector3.zero, touchPosition, Color.red);

            //possibly a way to see the mulitpile touchpositions?
            string touchpos = "" + touchPosition + i;
            Debug.Log(touchpos);


            //&& touchPosition.y <= -3

            if (Input.GetTouch(i).phase == TouchPhase.Began && touchPosition.x >= 0 )
            {
                this.GetComponent<Renderer>().material.color = Color.blue;
                pressed_r = true;
            }

            else
            {
                this.GetComponent<Renderer>().material.color = Color.white;
                pressed_r = false;
            }

            


        }
    }
    public override void Find_First()
    {
       

        GameObject[] gameObjects_R;
        gameObjects_R = GameObject.FindGameObjectsWithTag("MusicNote_R");
        //print(gameObjects_R.Length);
        if (gameObjects_R.Length >= 1)
        {
            notes_onscreen = true;
        }
        else
        {
            notes_onscreen = false;
        }
        if (notes_onscreen)
        {
            ///this conflicts with the other scripte 
            MakeTopNoteSelectable(gameObjects_R[0]);
        }
    }
    public override void MakeTopNoteSelectable(GameObject first_R)
    {
        first_R.GetComponent<Renderer>().material.color = Color.red;
        NoteScipt nrScript = first_R.GetComponent<NoteScipt>();

        nrScript.overLap = false;
    }
    public override void OnMouseDown()
    {


       
        pressed_r = true;
        


    }
}
