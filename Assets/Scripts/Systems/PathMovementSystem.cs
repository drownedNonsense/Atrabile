using UnityEngine;
using Atrabile.Archetypes;
using Atrabile.Data;
using Atrabile.Singletons;


namespace Atrabile.Systems {

[RequireComponent(typeof(PathFollowerArchetype))]
/// <summary> Handles the entity's movement along a path. </summary>
public sealed class PathMovementSystem : System<PathFollowerArchetype> {

    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Update() {
            if (!GameVariables.gamePaused) {
                if (this.archetype.data.movementDirection != Sign.zero) {
                    
                    Vector3 posititonOffset = this.archetype
                        .data
                        .nextNode
                        .position - this.transform.position;

                    this.archetype
                        .movementData
                        .acceleration = Vector3.ClampMagnitude(
                            posititonOffset,
                            this.archetype.movementData.speed / Time.deltaTime
                        ); // ClampMagnitude()
                } // if ..

                if (this.archetype.data.hasReachedTheNextNode)
                    switch ((byte)this.archetype.data.movementDirection) {
                        case (Sign.POS) : {

                            switch (this.archetype.data.mode) {
                                case (PathFollowerData.Mode.Loop) : {

                                    this.archetype.data.currentNodeIndex++;
                                    this.archetype.data.movementDirection = this.archetype.data.isAtTheEnd
                                        ? !this.archetype.data.movementDirection
                                        :  this.archetype.data.movementDirection;

                                    break;

                                } case (PathFollowerData.Mode.MoveOnce) : {

                                    this.archetype.data.currentNodeIndex++;
                                    this.archetype.data.movementDirection = this.archetype.data.isAtTheEnd
                                        ? Sign.zero
                                        : this.archetype.data.movementDirection;

                                    break;

                                } // case ..
                            } // switch ..

                            break;

                        } case (Sign.NEG) : {

                            switch (this.archetype.data.mode) {
                                case (PathFollowerData.Mode.Loop) : {

                                    this.archetype.data.currentNodeIndex--;
                                    this.archetype.data.movementDirection = this.archetype.data.isAtTheEnd
                                        ? !this.archetype.data.movementDirection
                                        :  this.archetype.data.movementDirection;

                                    break;

                                } case (PathFollowerData.Mode.MoveOnce) : {

                                    this.archetype.data.currentNodeIndex--;
                                    this.archetype.data.movementDirection = this.archetype.data.isAtTheEnd
                                        ? Sign.zero
                                        : this.archetype.data.movementDirection;

                                    break;

                                } // case ..
                            } // switch ..

                            break;
                            
                        } // case ..
                    } // switch ..
            } // if ..
        } // void ..
}} // namespace ..
