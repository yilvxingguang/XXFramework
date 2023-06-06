using Internals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        using (var unzip = new Unzip("./test.zip"))
        {
            unzip.ExtractToDirectory("./test");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
