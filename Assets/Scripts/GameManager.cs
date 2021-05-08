using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour
{
    public Vector3 PlayerPosition;
    public float speed;
    public Transform LeftBoard, RightBoard;
    public int FeverCount = 0;
    public bool InFever = false;
    public Snake snake;

    public int LevelNumber;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerPosition = new Vector3(PlayerPosition.x, PlayerPosition.y, PlayerPosition.z  + speed);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(LevelNumber);
    }

    public void StartFever()
    {
        StartCoroutine(Fever());
    }
    
    public IEnumerator Fever()
    {
        InFever = true;
        speed *= 3;
        snake.Fever = true;
        snake.fev.enabled = true;
        snake.def.enabled = false;
        GameObject[] body = GameObject.FindGameObjectsWithTag("Body");
        for (int i = 0; i < body.Length; i++)
            body[i].GetComponent<SnakeBody>().FeverMultiplier = 3;
        yield return new WaitForSeconds(5);
        snake.Fever = false;
        snake.fev.enabled = false;
        snake.def.enabled = true;
        for (int i = 0; i < body.Length; i++)
            body[i].GetComponent<SnakeBody>().FeverMultiplier = 1;
        speed /= 3;
        yield return new WaitForSeconds(0.5f);
        InFever = false;
        
        yield break;
    }

    public void StartCrystalStreak()
    {
        StartCoroutine(CrystalStreak());
    }

    public IEnumerator CrystalStreak()
    {
        yield return new WaitForSeconds(2);
        FeverCount = 0;
        yield break;
    }
}
