using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    public float playerSpeed = 2000f;

    ScoreLogic addToScore;

    void Start()
    {
        hideMouseCursor();
    }

    
    void Update()
    {
        movePLayerToMousePosition();
    }

    void movePLayerToMousePosition()
    {
        var tempMousePosition = Input.mousePosition;
        tempMousePosition.z = transform.position.z - Camera.main.transform.position.z;
        tempMousePosition = Camera.main.ScreenToWorldPoint(tempMousePosition);
        transform.position = Vector3.MoveTowards(transform.position, tempMousePosition, playerSpeed * Time.deltaTime);
    }

    void hideMouseCursor()
    {
        Cursor.visible = false;
    }

    void OnCollisionEnter2D(Collision2D tempCollision)
    {
        if(tempCollision.gameObject.tag == "Collectable")
        {
            callAddToScoreScript();

            Destroy(tempCollision.gameObject);
        }

        if(tempCollision.gameObject.tag == "BadCollectable")
        {
            resetGame();
        }
    }

    void callAddToScoreScript()
    {
        addToScore = GameObject.FindGameObjectWithTag("GUI").GetComponent<ScoreLogic>();
        addToScore.addToScoreVOID();
    }

    void resetGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
