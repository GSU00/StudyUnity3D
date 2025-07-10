using System.Collections;
using TMPro;
using UnityEngine;
using static HanoiTower;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3,  Lv2, Lv3 };
    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefabs;
    public BoardBar[] bars; // L(0), C(1), R(2)

    public TextMeshProUGUI countTextUI;

    public static bool isSelected;
    public static GameObject selectedDonut;
    public static BoardBar currBar;
    public static int moveCount;

    private IEnumerator Start()
    {
        countTextUI.text = moveCount.ToString();

        for (int i = 1; i <= (int)hanoiLevel; i++)
        {
            GameObject donut = Instantiate(donutPrefabs[(int)hanoiLevel - i]);
            donut.transform.position = new Vector3( -5f, 5f, 0f);

            bars[0].PushDonut(donut);

            yield return new WaitForSeconds(1f);
        }

        moveCount = 0;
        countTextUI.text = moveCount.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currBar.barStack.Push(selectedDonut);

            isSelected = false;
            selectedDonut = null;
        }

        countTextUI.text = moveCount.ToString();
    }
}
