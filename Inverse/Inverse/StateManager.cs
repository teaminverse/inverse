//StateManager Class

using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace AIE {
	//Generic State Class
	public abstract class State {

		//!---VARIABLES---!
		bool bReleased = false;

		//!---CONSTRUCTORS---!
		public State() { }

		//!---METHODS---!
		public abstract void Draw(SpriteBatch sb);
		public abstract void Update(ContentManager Content, GameTime gameTime);
		public abstract void CleanUp();
		public bool CheckEscape() {
			if (Keyboard.GetState().IsKeyDown(Keys.Escape) || 
				GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
				GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
			{
				if (!bReleased) { bReleased = true; }
			}
			else if (Keyboard.GetState().IsKeyUp(Keys.Escape) && 
				GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Released && 
				GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Released && 
				bReleased)
			{
				bReleased = false;
				return true;
			}
			return false;
		}
	}

	//State Manager
	public static class StateManager {
		static String sCurrent;
		static private string sKey;

		static Dictionary<String, State> dGameStates;
		static List<State> lStateStack;
		static List<StateEvents> lStateEvents;

		static public int GameStatesCount { get { return dGameStates.Count; } }
		static public String GameStateNames { get {
				String s = "";
				for (int i = 0; i < dGameStates.Count; i++){
					if (i != 0) { s += ":"; }
					if (dGameStates.Keys.ElementAt<String>(i).ToString().Length > 4)
					{
						s += dGameStates.Keys.ElementAt<String>(i).ToString().Substring(0, 4);
					}
					else
					{
						s += dGameStates.Keys.ElementAt<String>(i).ToString();
					}
				}
				return s;
			} 
		}
		static public int StateStackCount { get { return lStateStack.Count; } }
		static public String StateStackCurrent { get { return sCurrent; } }

		static public State GetState(String s_Key){
			if (dGameStates.ContainsKey(s_Key)){
				return dGameStates[s_Key];
			}
			return null;
		}
		enum StateCommands { CHANGE, PUSH, POP, SET }

		struct StateEvents
		{
			//!---VARIABLES---!
			public string name;
			public StateCommands cmd;

			//!---CONSTRUCTORS---!
			public StateEvents(string name, StateCommands cmd) {
				this.name = name;
				this.cmd = cmd;
			}
		}

		//!---CONSTRUCTORS---!
		static StateManager() {
			dGameStates = new Dictionary<String, State>();
			lStateStack = new List<State>();
			lStateEvents = new List<StateEvents>();
		}

		//!---METHODS---!
		public static void Draw(SpriteBatch sb) {
			foreach (State sState in lStateStack)
				sState.Draw(sb);
		}
		public static void Update(ContentManager Content, GameTime gameTime) {
			ProcessStateEvents();
			if (sKey != null) {
				dGameStates[sKey].CleanUp();
				dGameStates.Remove(sKey);
				sKey = null;
			}
			//  Only Updates the top item
			if (lStateStack.Count > 0)
				lStateStack[lStateStack.Count - 1].Update(Content, gameTime);
		}

		//  State Changing Commands
		public static void CreateState(String s_Key, State s_State) {
			dGameStates[s_Key] = s_State;
		}
		public static bool RemoveState(String s_Key) {
			dGameStates[s_Key].CleanUp();
			return dGameStates.Remove(s_Key);
		}
		public static bool RemoveNextUpdate(String s_Key) {
			sKey = s_Key;
			return true;
		}
		public static void ChangeState(String s_Key) {
			lStateEvents.Add(new StateEvents(s_Key, StateCommands.CHANGE));
		}
		public static void PushState(String s_Key) {
			lStateEvents.Add(new StateEvents(s_Key, StateCommands.PUSH));
		}
		public static void PopState() {
			lStateEvents.Add(new StateEvents("", StateCommands.POP));
		}
		public static void SetState(String s_Key) {
			lStateEvents.Add(new StateEvents(s_Key, StateCommands.SET));
		}

		public static bool HasState(String s_Key) {
			return dGameStates.ContainsKey(s_Key);
		}

		static void ProcessStateEvents() {
			foreach (StateEvents e in lStateEvents) {
				switch (e.cmd) {
				case StateCommands.CHANGE:
					if (lStateStack.Count > 0)
						lStateStack.RemoveAt(lStateStack.Count - 1);
					if (dGameStates.ContainsKey(e.name)){
						lStateStack.Add(dGameStates[e.name]);
						sCurrent = e.name;
					}
					break;
				case StateCommands.PUSH: 
					if (dGameStates.ContainsKey(e.name)) {
						lStateStack.Add(dGameStates[e.name]);
						sCurrent = e.name;
					}
					break;
				case StateCommands.POP:
					if (lStateStack.Count > 0) {
						lStateStack.RemoveAt(lStateStack.Count - 1);
						sCurrent = "NULL";
					}
					break;
				case StateCommands.SET:
					lStateStack.Clear();
					lStateStack.Add(dGameStates[e.name]);
					sCurrent = e.name;
					break;
				}
			}
			lStateEvents.Clear();
		}
	}
}
