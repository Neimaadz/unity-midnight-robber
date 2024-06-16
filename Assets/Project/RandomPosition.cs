using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project
{
    public class RandomPosition
    {
        /// <summary>
        /// Randomize a game object position
        /// </summary>
        public void RandomizePosition(GameObject gameObject, float xMin, float xMax)
        {
            float randomX = Random.Range(xMin, xMax);

            // Set the new position
            Vector3 newPosition = new Vector3(randomX, -0.068f, 13.485f);
            gameObject.transform.localPosition = newPosition;

            Debug.Log("New Position: " + newPosition);
        }

        /// <summary>
        /// Randomize a game object rotation
        /// </summary>
        public void RandomizeRotation(GameObject gameObject, float xMin, float xMax)
        {
            float randomRotationX = Random.Range(0f, 360f);
            float randomRotationY = Random.Range(0f, 360f);
            float randomRotationZ = Random.Range(0f, 360f);

            // Set the new rotation
            Quaternion newRotation = Quaternion.Euler(randomRotationX, randomRotationY, randomRotationZ);
            gameObject.transform.localRotation = newRotation;

            Debug.Log("New rotation: " + newRotation);
        }


        /// <summary>
        /// Set random position of given object
        /// </summary>
        public void RandomObjectPosition(GameObject gameObject)
        {
            GlobalParams.objects.TryGetValue(gameObject.name, out List<(Vector3 position, Vector3 rotation)> values);

            int randomValue = Random.Range(0, values.Count);
            (Vector3 position, Vector3 rotation) value = values[randomValue];

            // Set the new position
            Vector3 newPosition = new Vector3(value.position.x, value.position.y, value.position.z);
            gameObject.transform.localPosition = newPosition;

            // Set the new rotation
            Quaternion newRotation = Quaternion.Euler(new Vector3(value.rotation.x, value.rotation.y, value.rotation.z));
            gameObject.transform.localRotation = newRotation;
        }
    }
}
