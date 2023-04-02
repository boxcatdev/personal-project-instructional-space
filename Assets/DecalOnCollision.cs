using UnityEngine;

public class DecalOnCollision : MonoBehaviour
{
    public GameObject decalPrefab; // The decal prefab to instantiate on collision
    public float yOffset; // The offset to apply to the y-axis to prevent Z-fighting with the ceiling

    private void OnParticleCollision(GameObject other)
    {
        // Check if the particle collided with the ceiling
        //if (other.tag == "Ceiling")
        //{
        // Instantiate the decal at the collision point with a random rotation
        Debug.Log("hit something");
            Vector3 collisionPoint = transform.position;
            Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            GameObject decal = Instantiate(decalPrefab, new Vector3(collisionPoint.x, collisionPoint.y + yOffset, collisionPoint.z), randomRotation);

            // Parent the decal to the ceiling
            decal.transform.parent = other.transform;
        //}
    }
}
