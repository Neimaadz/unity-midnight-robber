using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Project
{
    public class DisplayMessage
    {
        /// <summary>
        /// Display temporary a message for a given duration
        /// </summary>
        /// <param name="textMesh">the reference of the UI text.</param>
        /// <param name="message">the message to display.</param>
        /// <param name="displayDuration">the duration to display the message.</param>
        public IEnumerator DisplayAndHideMessage(TextMeshProUGUI textMesh, string message, float displayDuration)
        {
            // Set the text and make it visible
            textMesh.text = message;
            textMesh.gameObject.SetActive(true);

            // Wait for the specified duration
            yield return new WaitForSeconds(displayDuration);

            // Hide the text
            textMesh.gameObject.SetActive(false);
        }
    }
}
