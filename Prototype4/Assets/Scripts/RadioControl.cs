using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class RadioControl : MonoBehaviour
{
    public AudioPlayer radio;

    private bool playRadio = false;

    private int currentSong = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (playRadio)
            {
                RadioInterface("Off");
            }

            else
            {
                RadioInterface("On");
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            RadioInterface("Skip");
        }
    }

    void RadioInterface(string input)
    {
        
    }
}
