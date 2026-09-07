using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class managerscript : MonoBehaviour
{
    [SerializeField]
    private InputAction esc;
    [SerializeField]
    private TMP_Text scoretext;
    [SerializeField]
    private GameObject lose;
    [SerializeField]
    private GameObject pauseP;
    [SerializeField]
    private Slider slidermusic;
    [SerializeField]
    private Slider slidereffects;
    [SerializeField]
    private int score;
    public static managerscript instance;
    [SerializeField]
    private AudioMixer mixer;
    [SerializeField]
    private GameObject menu;
    private bool pause = false;
    public static bool startgames = false;
    private void OnEnable()
    {
        esc.Enable();
    }
    private void OnDisable()
    {
        esc.Disable();
    }
    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        slidermusic.value = PlayerPrefs.GetFloat("Music", 1f);
       slidereffects.value = PlayerPrefs.GetFloat("Effects", 1f);

        slidermusic.onValueChanged.AddListener(musicscale);
        slidereffects.onValueChanged.AddListener(effectsscale);

        if (startgames == true)
        {
            menu.SetActive(false);
            startgame();
            startgames = false;
        }
       else
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
    public void musicscale(float volumen)
    {
      float volumeDB = volumen == 0 ? -80f: Mathf.Log10(volumen) * 20f;
        mixer.SetFloat("Music", volumeDB);

        PlayerPrefs.SetFloat("Music", volumen);
    }
    public void effectsscale(float volumen)
    {
        float volumeDB = volumen == 0 ? -80f : Mathf.Log10(volumen) * 20f;
        mixer.SetFloat("Effects", volumeDB);
        PlayerPrefs.SetFloat("Effects", volumen);
    }

    public void gameover()
    {
        lose.SetActive(true);
    }
    public void reloadmenu()
    {
        SceneManager.LoadScene(0);
    }    
    public void addscore(int scores)
    {
        score += scores ;
        scoretext.text = "Score: " + score.ToString();
    }
    public void startgame()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void resetlevel()
    {
        startgames = true;
        SceneManager.LoadScene(0);
    }
    public void modesecure()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void exit()
    {
        Application.Quit();
    }
    public void Pause()
    {
        if (pause == false)
        {
            go();
        }
        else
        {
            
            Time.timeScale = 0f;
            pauseP.SetActive(true);
        }
    }

    public void go()
    {
            pause = false;
            Time.timeScale = 1f;
            pauseP.SetActive(false);

    }
    void Update()
    {
        if (esc.triggered)
        {
            Pause();
            pause = true;
        }
    }
}
