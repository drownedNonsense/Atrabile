using UnityEngine;
using UnityEngine.InputSystem;


namespace Atrabile {
    
[RequireComponent(typeof(PlayerInput))]
public sealed class Controller : MonoBehaviour {

    /*#########*/
    /* D A T A */
    /*#########*/

        public Vector2 movement  { get; private set; }
        public Vector2 selection { get; private set; }
        public float   z         { get; private set; }

        private InputAction _aAction;
        private InputAction _bAction;
        private InputAction _xAction;
        private InputAction _yAction;
        private InputAction _zLAction;
        private InputAction _zRAction;
        private InputAction _startAction;
        private InputAction _selectAction;

        private Button _a      = new Button();
        private Button _b      = new Button();
        private Button _x      = new Button();
        private Button _y      = new Button();
        private Button _zL     = new Button();
        private Button _zR     = new Button();
        private Button _start  = new Button();
        private Button _select = new Button();

        public Button a      => this._a.Update(this._aAction);
        public Button b      => this._b.Update(this._bAction);
        public Button x      => this._x.Update(this._xAction);
        public Button y      => this._y.Update(this._yAction);
        public Button zL     => this._zL.Update(this._zLAction);
        public Button zR     => this._zR.Update(this._zRAction);
        public Button start  => this._start.Update(this._startAction);
        public Button select => this._select.Update(this._selectAction);


    /*###################*/
    /* L I F E   T I M E */
    /*###################*/

        private void Awake() {

            PlayerInput playerInput = this.GetComponent<PlayerInput>();
            
            this._aAction      = playerInput.actions["A"];
            this._bAction      = playerInput.actions["B"];
            this._xAction      = playerInput.actions["X"];
            this._yAction      = playerInput.actions["Y"];
            this._zLAction     = playerInput.actions["ZL"];
            this._zRAction     = playerInput.actions["ZR"];
            this._startAction  = playerInput.actions["Start"];
            this._selectAction = playerInput.actions["Select"];

        } // void ..

        
    /*###############################*/
    /* I M P L E M E N T A T I O N S */
    /*###############################*/

        private void OnMovement(InputValue value) =>
            this.movement = value.Get<Vector2>();

        
        private void OnCursorMovement(InputValue value) =>
            this.selection += value.Get<Vector2>();

            
        private void OnZ(InputValue value) =>
            this.z = value.Get<float>();


    /// <summary> A class that handles button input. </summary>
    public class Button : State {
        public Button Update(InputAction action) {
            this.SetState(action.IsPressed());
            return this;
        } // Button ..
    } // class ..
}} // namespace ..
