using UnityEngine;
public class SpawnManager : MonoBehaviour
{
public GameObject objectToSpawn;
private PlacementIndicator PlaceIndicate;
void Start()
{
PlaceIndicate = FindObjectOfType<PlacementIndicator>();
}
// Update is called once per frame
void Update()
{

if (Input.touchCount > 0 &&

Input.touches[0].phase == TouchPhase.Began)
{
showobject();
}
}
void showobject()
{
GameObject obj = Instantiate(objectToSpawn,
PlaceIndicate.transform.position,
PlaceIndicate.transform.rotation);
}
}