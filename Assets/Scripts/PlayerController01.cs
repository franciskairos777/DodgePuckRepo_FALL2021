using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController01 : MonoBehaviour
{
    public int[] LottoNumbers = { 1, 2, 3, 4, 5, 6 };
    public int myNumber;
    public int score = 7;
    public float speed = 10.0f;
    public float xRange;
    public float yRange;
    public GameObject Puck;

    // Start is called before the first frame update
    void Start()
    {
        
        


        Debug.Log("Hello, World");
    }

    private void LateUpdate()
    {
        //Keep Player within xRange (Left and Right sides)
        if (transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }

        if(transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }

        //Keep Player within yRange (Left and Right sides)
        if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }

        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }

    }
    
    
    // Update is called once per frame
    void Update()
    {
        Instantiate(Puck,new Vector2(Random.Range(-xRange,xRange), Random.Range(-yRange, yRange)), Quaternion.identity);

        float moveHorizontal = Input.GetAxis("Horizontal");
        Debug.Log(moveHorizontal);

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        transform.Translate(movement * speed * Time.deltaTime);

        //if (Input.GetKeyDown(KeyCode.D)) 
        //{
        //    Debug.Log(Input.GetAxis("Horizontal"));
        //    transform.Translate(Vector2.right * speed * Time.deltaTime);
        //}

        myNumber = LottoNumbers[Random.Range(0, 5)];
        Debug.Log("My Lotto Number is: " + myNumber);

    }
}
