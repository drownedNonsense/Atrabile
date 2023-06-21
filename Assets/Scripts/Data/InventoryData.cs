using System.Collections.Generic;
using UnityEngine;


namespace Atrabile.Data {
public sealed class InventoryData : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/

        /// <summary> The amount of supply in the inventory. </summary>
        public int supply = 0;

        /// <summary> An array of meaningful items origin. </summary>
        public List<string> storyDriveOrigins = new List<string>();

}} // namespace ..
