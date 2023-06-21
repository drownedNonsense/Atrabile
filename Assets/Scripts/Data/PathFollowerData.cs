using UnityEngine;


namespace Atrabile.Data {
public class PathFollowerData : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/
    
        /// <summary> An array of nodes that are part of a path. </summary>
        public Transform[] nodes = null;

        /// <summary> Delay between nodes. </summary>
        public float delay = 0f;

        /// <summary> Time remaining before moving to the next node. </summary>
        public float coolDown { get; private set; } = 0f;

        /// <summary> Is true when the entity can move to the next node. </summary>
        public bool isReady => float.IsNegative(this.coolDown) && this.hasReachedTheNextNode;

        /// <summary> Makes the entity loop through all of its node until false. </summary>
        public Mode mode = Mode.Loop;
        public enum Mode { Loop, MoveOnce, KeepMoving }

        /// <summary> Indicates the entity's direction in the array of nodes. </summary>
        public Sign movementDirection = Sign.zero;

        /// <summary> Points at the index of the current node path. </summary>
        public int currentNodeIndex = 0;

        /// <summary> Points at the next path node if it exists. </summary>
        public Transform nextNode { get {
            if (this.nodes != null)
                return (byte)this.movementDirection switch {
                    Sign.POS => this.nodes[this.currentNodeIndex + 1],
                    Sign.NEG => this.nodes[this.currentNodeIndex - 1],
                    _        => this.transform,
                }; // switch ..
            else return this.transform;
        }} // Transform ..

        /// <summary> Is true when the entity has reached the last path node. </summary>
        public bool isAtTheEnd => (byte)this.movementDirection switch {
            Sign.POS => this.currentNodeIndex == this.nodes.Length - 1,
            Sign.NEG => this.currentNodeIndex == 0,
            _        => false,
        }; // switch ..

        /// <summary> Is true when the entity is at the next path node position. </summary>
        public bool hasReachedTheNextNode =>
            (this.nextNode.position - this.transform.position).sqrMagnitude < 1f;

}} // namespace ..
