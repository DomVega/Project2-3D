using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Howtoplay : MonoBehaviour
{
    public GameObject play;

    public void ActivatePlay()
    {


        play.SetActive(true);
    }
    public void DeactivatePlay()
    {

        play.SetActive(false);

    }
    
}
