using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MangareLevel : MonoBehaviour
{

    public string nextLevel;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
