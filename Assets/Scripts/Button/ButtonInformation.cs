using UnityEngine;
using UnityEngine.UI;

public class ButtonInformation : MonoBehaviour
{
    public int buttonIndex { get; private set; }
    public Button Btn { get; private set; }

    public void Setup(int index)
    {
        buttonIndex = index;
        Btn = GetComponent<Button>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
