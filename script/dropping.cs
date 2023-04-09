using UnityEngine;

public class dropping : MonoBehaviour
{
   public GameObject cubePrefab;
    public GameObject spawnOnTopOf;
    public PhysicMaterial cubePhysicMaterial;

    public void Spawn()
    {
        Vector3 spawnPos = spawnOnTopOf.transform.position + new Vector3(0f, spawnOnTopOf.transform.localScale.y * 0.5f + 50f, 0f);

        for (int i = 0; i < 10; i++)
        {
            Vector3 pos = spawnPos + new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
            Quaternion rot = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
            GameObject cube = Instantiate(cubePrefab, pos, rot);
            //cube.GetComponent<Collider>().material = cubePhysicMaterial; 
            //cube.GetComponent<Rigidbody>().AddForce(Vector3.down * 10f, ForceMode.Impulse);
        }
    }
}