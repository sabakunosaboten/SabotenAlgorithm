using UnityEngine;
using UnityEngine.UI;

public class ObjectInformation : MonoBehaviour
{
    int myIndex;

    public void Setup(int index)
    {
        myIndex = index;
    }
    public int GetIndex() => myIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
