using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public Text startin, finishPosition;
    public Image[] maps;
    public Image mainMenu, carSelect, trackMenu, inGamePauseMenu, duringGame, raceEnd;
    public GameObject[] AIWaypoints, AICars, Players, DeadEnds;
    public Color[] AIColors;
    bool isShowingStartin = false;
    float timeRaceStarted;
    public int aiFinishedAlready = 0;
    public Sprite[] carSprites;
    public Texture[] carTextures;
    public Material carMaterial;
    public Image carImage;
    private int carIndex = 0;

    int chosenTrack = 0;

    void Awake() {
        instance = this;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (isShowingStartin) {
            if (Time.realtimeSinceStartup - timeRaceStarted > 0.0f && Time.realtimeSinceStartup - timeRaceStarted < 1.0f)
                startin.text = "Start in 3";
            if (Time.realtimeSinceStartup - timeRaceStarted > 1.0f && Time.realtimeSinceStartup - timeRaceStarted < 2.0f)
                startin.text = "Start in 2";
            if (Time.realtimeSinceStartup - timeRaceStarted > 2.0f && Time.realtimeSinceStartup - timeRaceStarted < 3.0f)
                startin.text = "Start in 1";
            if (Time.realtimeSinceStartup - timeRaceStarted > 3.0f) {
                StartCoroutine("cGo");
                isShowingStartin = false;
                Time.timeScale = 1;
            }
        }
    }

    public void PickATrack(int trackNo) {
        maps[chosenTrack].gameObject.SetActive(false);
        chosenTrack = trackNo;
        maps[chosenTrack].gameObject.SetActive(true);
    }

    public void SelectTrackMenu() {
        carSelect.gameObject.SetActive(false);
        trackMenu.gameObject.SetActive(true);
    }

    public void SelectCarSelectMenu(){
        mainMenu.gameObject.SetActive(false);
        carSelect.gameObject.SetActive(true);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void StartRace() {
        AIWaypoints[chosenTrack].SetActive(true);
        DeadEnds[chosenTrack].SetActive(true);
        AICars[chosenTrack].SetActive(true);
        Players[chosenTrack].SetActive(true);
        trackMenu.gameObject.SetActive(false);
        duringGame.gameObject.SetActive(true);
        timeRaceStarted = Time.realtimeSinceStartup;
        isShowingStartin = true;
        Time.timeScale = 0;
        aiFinishedAlready = 0;

    }

    public void InGamePause() {
        Time.timeScale = 0;
        inGamePauseMenu.gameObject.SetActive(true);
        duringGame.gameObject.SetActive(false);
    }

    public void ResumeRace() {
        Time.timeScale = 1;
        inGamePauseMenu.gameObject.SetActive(false);
        duringGame.gameObject.SetActive(true);
    }

    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    IEnumerator cGo() {
        startin.text = "GO !";
        yield return new WaitForSeconds(0.5f);
        startin.text = " ";
    }

    public void PlayerFinishedRace() {
        finishPosition.text = "Position : " + (int)(aiFinishedAlready + 1);
        raceEnd.gameObject.SetActive(true);

        AIWaypoints[chosenTrack].SetActive(false);
        DeadEnds[chosenTrack].SetActive(false);
        AICars[chosenTrack].SetActive(false);
        Players[chosenTrack].SetActive(false);
        duringGame.gameObject.SetActive(false);

    }

    public void Continue() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void ChangeCarUp() {
        carIndex++;
        if (carIndex > 4) {
            carIndex = 0;
        }
        carImage.sprite = carSprites[carIndex];
        carMaterial.mainTexture = carTextures[carIndex];
    }

    public void ChangeCarDown() {
        carIndex--;
        if (carIndex < 0) {
            carIndex = 4;
        }
        carImage.sprite = carSprites[carIndex];
        carMaterial.mainTexture = carTextures[carIndex];
    }


}
