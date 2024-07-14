using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase1_2 : Fase1
{
    // Start is called before the first frame update


    void Awake()
    {
        TimeSystem.Instance.StartTimeSystemAfternoon();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
