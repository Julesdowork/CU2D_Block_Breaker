using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Range(0.25f, 4f)] [SerializeField] float gameSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = gameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
