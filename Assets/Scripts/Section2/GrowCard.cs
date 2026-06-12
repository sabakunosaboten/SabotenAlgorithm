using UnityEngine;

public class GrowCard : MonoBehaviour
{
    bool isGrowing;
    [SerializeField] GameObject growSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        growSprite.SetActive(false);
        isGrowing=false;
    }
    public void Grow()
    {
        if (isGrowing == false)
        {
            growSprite.SetActive(true);
            isGrowing = true;
        }
        else
        {
            growSprite.SetActive(false);
            isGrowing = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
