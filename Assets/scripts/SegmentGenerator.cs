using System.Collections;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segments;
    [SerializeField] private int zPos = 50;

    void Start()
    {
        if (segments.Length == 0)
        {
            Debug.LogError("Segments array is empty!");
            return;
        }

        StartCoroutine(SegmentGenLoop());
    }

    IEnumerator SegmentGenLoop()
    {
        while (true)
        {
            SpawnSegment();
            yield return new WaitForSeconds(3);
        }
    }

    void SpawnSegment()
    {
        int segmentNum = Random.Range(0, segments.Length);
        Instantiate(segments[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);
        Debug.Log("Segment spawned at z = " + zPos);
        zPos += 50;
    }
}
