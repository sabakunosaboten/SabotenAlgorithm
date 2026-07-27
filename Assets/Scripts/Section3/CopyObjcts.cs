using UnityEngine;

public class CopyObjcts : MonoBehaviour
{
    [SerializeField] GameObject card;
    [SerializeField] float distant = 5f;
    [SerializeField] float positionX = 0f;
    [SerializeField] float positionY = 0f;
    [SerializeField] int row;
    [SerializeField] int col;
    
    public int mySpriteIndex=-1;

    public GameObject[] cardInstance{get;private set;}

    void Awake()
    {
        cardInstance = new GameObject[row * col];
        for(int i=0;i< row ; i++)
        {
            for(int j = 0; j < col; j++)
            {
                GameObject instance = Instantiate(card);
                instance.transform.position = new Vector2(positionX+j*distant,positionY-i*distant);
                mySpriteIndex = i*col + j;
                cardInstance[i*col + j] = instance;
                int localindex=i*col + j;
                instance.GetComponent<ObjectInformation>().Setup(localindex);
            }
        }
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
