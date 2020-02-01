using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMesh textMesh = this.GetComponent<TextMesh>();
        textMesh.text = Global.EndGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
