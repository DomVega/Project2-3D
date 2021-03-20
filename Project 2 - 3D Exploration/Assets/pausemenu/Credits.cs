using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Credits : MonoBehaviour
{
    public GameObject credit;

    public void ActivateCredit()
    {


        credit.SetActive(true);
    }
    public void DeactivateCredit()
    {

        credit.SetActive(false);

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
