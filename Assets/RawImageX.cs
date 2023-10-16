using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawImageX : MonoBehaviour
{
    [SerializeField] RawImage a;
    Texture b;
    // Start is called before the first frame update
    void Start()
    {
        b = a.texture;
        a.texture = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fallaste()
    {
        a.texture = b;
    }

    public void reinicio()
    {
        a.texture = null;
    }
}
