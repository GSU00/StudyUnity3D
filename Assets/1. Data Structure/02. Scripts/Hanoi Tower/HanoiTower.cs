using System.Collections;
using UnityEngine;
using static HanoiTower;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3,  Lv2, Lv3 };
    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefabs;
    public BoardBar[] bars; // L(0), C(1), R(2)

    public static bool isSelected;
    public static GameObject selectedDonut;

    private IEnumerator Start()
    {
        for (int i = 1; i <= (int)hanoiLevel; i++)
        {
            GameObject donut = Instantiate(donutPrefabs[(int)hanoiLevel - i]);
            donut.transform.position = new Vector3( -5f, 5f, 0f);

            bars[0].PushDonut(donut);

            yield return new WaitForSeconds(1f);
        }
    }
}
