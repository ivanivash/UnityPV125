using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode {
    idle,
    playing,
    levelEnd
}

public class MissionDemolition : MonoBehaviour {
    static private MissionDemolition S;

    [Header("Set in Inspector")]
    public Text uitLevel;
    public Text uitShots;
    public Text uitButton;

    public Vector3 castlePos;
    public GameObject[] castles;

    [Header("set Dymically")]
    public int level;
    public int levelMax;
    public int shotsTaken;
    public GameObject castle;
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot";

    // Start is called before the first frame update
    void Start() {
        S = this;

        level = 0;
        levelMax = castles.Length;
        StartLevel();
    }

    void StartLevel () {
        if (castle != null) {
            Destroy(castle);
        }

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos) {
            Destroy(pTemp);
        }

        // створюємо новий замок
        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;
        shotsTaken = 0;

        // ставимо камеру на початкову позицію
        SwitchView("Show Both");
        ProjectileLine.S.Clear();

        // скинути ціль
        Goal.goalMet = false;

        UpdateGUI();

        mode = GameMode.playing;
    }

    void UpdateGUI() {
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;
    }


    // Update is called once per frame
    void Update() {
        UpdateGUI();

        //  перевірити завершення рівня
        if((mode == GameMode.playing) && Goal.goalMet) {
            // змінити режим щоб зупинити перевірку рівня
            mode = GameMode.levelEnd;
            // змінити маштаб
            SwitchView("Show Both");
            // розпочати новий рівень за 2 сек
            Invoke("NextLevel", 2f);
        }
    }

    void NextLevel() {
        level++;
        if(level == levelMax) {
            level = 0;
        }
        StartLevel();
    }

    public void SwitchView(string eView = "") {
        if (eView == "") {
            eView = uitButton.text;
        }
        showing = eView;
        switch (showing) {
            case "Show Slingshot":
                FollowCam.POI = null;
                uitButton.text = "Show Castle";
                break;

            case "Show Castle":
                FollowCam.POI = S.castle;
                uitButton.text = "Show Slingshot";
                break;

            case "Show Both":
                FollowCam.POI = GameObject.Find("ViewBoth");
                uitButton.text = "Show Slingshot";
                break;
        }
    }

    //  статичний метод, дозволяє з любого коду збільшити shotsTaken
    public static void ShotFired() {
        S.shotsTaken++;
    }
}