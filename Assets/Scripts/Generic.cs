using System;
using UnityEngine;


namespace Atrabile {

    /// <summary> A class that handles values that may be null. </summary>
    public class Option<T> where T : class {

        private T       value = default;
        private Func<T> init  = default;
        private T       defaultValue => this.init == null ? default(T) : this.init();

        public static Option<T> None()             => new Option<T>();
        public static Option<T> Some(T value)      => new Option<T>(value);
        public static Option<T> Some(Func<T> init) => new Option<T>(init);

        public bool isNull => this.value == null;

        private Option() {}
        private Option(Func<T> init) => this.init  = init;
        private Option(T value)      => this.value = value;
        private Option(T value, Func<T> init) {
            this.value = value;
            this.init  = init;
        } // Option ..


        public static implicit operator Option<T>(T x) => new Option<T>(x);
        public static implicit operator T(Option<T> x) {
            if (x.value == null) x.value = x.defaultValue;
            return x.value;
        } // T ..


        public void SetNone()        => this.value = this.defaultValue;
        public void SetSome(T value) => this.value = value;

    } // class ..


    [System.Serializable]
    public class Sign {

        [field: SerializeField] private byte sign = Sign.ZERO;

        public const byte ZERO = 0b00;
        public const byte NEG  = 0b01;
        public const byte POS  = 0b11;
        public static Sign zero => new Sign(Sign.ZERO);
        public static Sign pos  => new Sign(Sign.POS);
        public static Sign neg  => new Sign(Sign.NEG);

        public bool isNull => this.sign == Sign.ZERO;
        public bool isPos  => this.sign == Sign.POS;
        public bool isNeg  => this.sign == Sign.NEG;

        public static implicit operator int(Sign x) => x.sign switch {
            Sign.POS =>  1,
            Sign.NEG => -1,
            _        =>  0,
        }; // switch ..

        public static implicit operator float(Sign x) => x.sign switch {
            Sign.POS =>  1,
            Sign.NEG => -1,
            _        =>  0,
        }; // switch ..
        
        public static implicit operator Sign(int x) {
            if (x == 0)     return Sign.zero;
            else if (x < 0) return Sign.neg;
            else            return Sign.pos;
        } // Sign ..

        public static implicit operator Sign(float x) {
            if (Mathf.Approximately(x, 0f)) return Sign.zero;
            else if (float.IsNegative(x))   return Sign.neg;
            else                            return Sign.pos;
        } // Sign ..

        public static implicit operator byte(Sign x) => x.sign;
        public static Sign operator !(Sign x)        => x.sign switch {
            Sign.POS => Sign.neg,
            Sign.NEG => Sign.pos,
            _        => Sign.zero,
        }; // Sign ..

        private Sign(byte x) => this.sign = x;
    } // class ..


    [System.Serializable]
    /// <summary> A class that handles states. </summary>
    public class State {

        [field: SerializeField] protected byte state = State.NONE;
        public const byte NONE    = 0b000;
        public const byte SOME    = State.ENABLED | State.ENTER;
        public const byte ENABLED = 0b001;
        public const byte ENTER   = 0b010;
        public const byte EXIT    = 0b100;
        public static State none    => new State(State.NONE);
        public static State some    => new State(State.SOME);
        public static State enabled => new State(State.ENABLED);
        public static State enter   => new State(State.ENTER);
        public static State exit    => new State(State.EXIT);

        /// <summary> Is always true when the state is disabled. </summary>
        public bool isNone => this.state == State.NONE;

        /// <summary> Is always true when the state is or will be enabled. </summary>
        public bool isSome => (this.state & State.SOME) != State.NONE;

        /// <summary> Is always true when the state is enabled. </summary>
        public bool isEnabled => (this.state & State.ENABLED) == State.ENABLED;

        /// <summary> Is only true on the first frame the state is enabled. </summary>
        public bool stateEnter => (this.state & State.ENTER) == State.ENTER;

        /// <summary> Is only true on the last frame the state is enabled. </summary>
        public bool stateExit => (this.state & State.EXIT) == State.EXIT;

        /// <summary> Sets the state. </summary>
        public void SetState(bool state) {
            if (state) this.Set();
            else       this.UnSet();
        } // void ..

        /// <summary> Starts enabling the state. </summary>
        public void Set() => this.state = this.isNone switch {
            true  => State.ENTER,
            false => State.ENABLED,
        }; // void ..

        /// <summary> Stops enabling the state. </summary>
        public void UnSet() => this.state = this.isSome switch {
            true  => State.EXIT,
            false => State.NONE,
        }; // void ..

        /// <summary> Toggles the current state. </summary>
        public void Toggle() => this.SetState(this.isNone);

        public State() {}
        public State(byte state) : this () => this.state = state;

        public static implicit operator bool(State x) => x.isSome;
        public static implicit operator byte(State x) => x.state;
        public static implicit operator State(byte x) => new State(x);
        public static implicit operator State(bool x) => x switch {
            true  => new State(State.SOME),
            false => new State(State.NONE),
        }; // Input ..
    } // class ..


    /// <summary> An enumerator for plane constraints. </summary>
    public enum Constraint { None, Horizontal, Vertical }

    /// <summary> An enumerator that represents logic gates. </summary>
    public enum LogicGate { And, NAnd, Or, NOr, XOr }


public static class Generic {

    public const int OBSTACLE_LAYER          = 8;
    public const int INTERACTABLE_LAYER      = 9;
    public const int OBSTACLE_LAYER_MASK     = 1 << Generic.OBSTACLE_LAYER;
    public const int INTERACTABLE_LAYER_MASK = 1 << Generic.INTERACTABLE_LAYER;
    public enum Interaction {
        Next   = 4,
        Unlock = 3,
        Open   = 2,
        Toggle = 1,
        None   = 0,
    } // enum ..
}} // namespace ..
