using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{   public Web Web;
    public static Main instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this; 
        Web = GetComponent<Web>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
