using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{

    public GameObject tutoPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenTuto()
    {
        tutoPanel.SetActive(true);
    }

    public void CloseTuto()
    {
        tutoPanel.SetActive(false);
    }
}
