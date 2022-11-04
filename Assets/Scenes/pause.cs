using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject pausee;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void main_menu() {
        SceneManager.LoadScene("StartMenu"); 
    }
   
    public void reset()
    {
        SceneManager.LoadScene("1lvl");
    }
    public void pause_on()
    {
        pausee.SetActive(true);
    }
    public void pause_off()
    {
        pausee.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
