using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addsubtractmoney : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            cam.GetComponent<playerMoney>().addMoney(100);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            cam.GetComponent<playerMoney>().subtractMoney(100);
        }
    }
}
