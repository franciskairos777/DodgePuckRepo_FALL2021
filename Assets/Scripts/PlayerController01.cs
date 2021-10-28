using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController01 : MonoBehaviour
{
    public int[] LottoNumbers = { 1, 2, 3, 4, 5, 6 };
    public int myNumber;
  //public int score;
    public float speed;
    public float xRange;
    public float yRange;
    public GameObject Puck;
    public GameObject Blocky;
    public GameObject scoreText;
    public GameObject gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Blocky, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
      //Score = 0;


        Debug.Log("Hello, World");
    }

    void LateUpdate()
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
        //Instantiate(Puck,new Vector2(Random.Range(-xRange,xRange), Random.Range(-yRange, yRange)), Quaternion.identity);

        //count how many enemies there are in the scene
        GameObject[] puckArray;
        puckArray = GameObject.FindGameObjectsWithTag("Puck");
        Debug.Log("Puck Count: " + puckArray.Length);

      
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        print("moveHorizontal value: " + moveHorizontal);
        Debug.Log(moveHorizontal);

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxisRaw("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
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

   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Blocky"))
            
        {
            Debug.Log("Hit Blocky!");
            Destroy(other.gameObject);
            Instantiate(Blocky, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
            Instantiate(Puck, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
            //score += 5;
            //Debug.Log("Your Score: " + score); 
            scoreText.GetComponent<ScoreKeeper>().scoreValue += 5;
            scoreText.GetComponent<ScoreKeeper>().UpdateScore();
        }

        if (other.gameObject.CompareTag("Puck")) 
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Game Over");
        }
    
    
    
    }

    public void NewGame() 
    {
        Debug.Log("It's a new game!");
        //Destroy all Pucks
        GameObject[] allPucks = GameObject.FindGameObjectsWithTag("Puck");
        foreach (GameObject dude in allPucks)
            GameObject.Destroy(dude);
        //Destroy all Blocky's
        GameObject[] allBlockys = GameObject.FindGameObjectsWithTag("Blocky");
        foreach (GameObject dude in allBlockys)
            GameObject.Destroy(dude);

        transform.position = new Vector2(0, 0);
        Instantiate(Blocky, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
        Instantiate(Puck, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
        gameOverText.SetActive(false);
        Time.timeScale = 1;

        //Set score to zero
        scoreText.GetComponent<ScoreKeeper>().scoreValue = 0;
        scoreText.GetComponent<ScoreKeeper>().UpdateScore();
        Debug.Log("score: " + scoreText.GetComponent<ScoreKeeper>().scoreValue);
    }


}
