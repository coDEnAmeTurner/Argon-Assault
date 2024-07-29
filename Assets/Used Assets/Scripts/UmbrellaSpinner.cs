using System.Collections;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class UmbrellaSpinner : MonoBehaviour
{
    const int surrCount = 8;

    const int centIdx = 0;

    GameObject umbrella;
    GameObject center;
    ArrayList surrounders;

    [SerializeField] float eulerAngle = 15f;

    private void Awake() {
        umbrella = gameObject;
        center = umbrella.transform.GetChild(centIdx).gameObject;
        surrounders = new ArrayList(surrCount);
        for (int i = 1; i <= 8; i++) {
            surrounders.Add(umbrella.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (center) {
            foreach (GameObject surrounder in surrounders) {
                if (surrounder) {
                    UnityEngine.Vector3 originalVector = surrounder.transform.position - center.transform.position;
                    UnityEngine.Vector3 offset = UnityEngine.Quaternion.Euler(0, 0, eulerAngle * Time.deltaTime) * originalVector;
                    UnityEngine.Vector3 rotatedVector = center.transform.position + offset;

                    surrounder.transform.position = rotatedVector;

                }
            }

        }
        
    }
}
