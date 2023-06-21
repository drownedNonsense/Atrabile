using UnityEngine;
using Atrabile.Archetypes;
using Atrabile.Singletons;


namespace Atrabile.Systems {

/// <summary> Handles entity's movement. </summary>
[RequireComponent(typeof(MovingEntityArchetype))]
public class MovementSystem : System<MovingEntityArchetype> {

    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Update() {
            if (!GameVariables.gamePaused) {

                this.transform.position += this.archetype.data.acceleration * Time.deltaTime;
                
                if (this.archetype.data.acceleration.sqrMagnitude > 0f) {
                    if (!this.archetype.audioSource.isPlaying) this.archetype.audioSource.Play();
                } else this.archetype.audioSource.Stop();
            } // if ..
        } // void ..
}} // namespace ..
