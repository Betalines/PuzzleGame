using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public delegate void StateChangedHandler(Object sender, GameButton.ButtonState state);
    public delegate void AddRemoveButtonHandler(Object sender, int buttonNumber, bool add);

    public class GameButton: Button
    {
        public enum ButtonState { Active, Inactive, Black, Yellow, White, Red};
        public event StateChangedHandler stateChanged;
        public event AddRemoveButtonHandler addRemoveButton;
        
        public ButtonState State { get; set; }
        public bool ActiveInGame { get; set; }
       
        public GameButton(): base() { }

        public void SetButtonStyles(Color backColor, string text)
        {
            BackColor = backColor;
            Dock = DockStyle.Fill;
            Text = text;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Microsoft Sans Serif", 16);
            State = ButtonState.Inactive;
        }

        public void SetButtonEvents()
        {
            MouseEnter += GameButton_MouseEnter;
            MouseLeave += GameButton_MouseLeave;
            MouseDown += GameButton_MouseDown;
        }

        public void ChangeState(Color color, ButtonState state, string text = "")
        {
            BackColor = color;
            //if (Text != "YES") 
            Text = text;
            State = state;
        }

        public void GameButton_MouseEnter(Object sender, EventArgs e)
        {
            if (GameState.EditMode) return;

            GameButton button = sender as GameButton;
            if (button.State == ButtonState.Active || button.State == ButtonState.Inactive)
                ChangeState(Color.Yellow, ButtonState.Yellow);
        }

        public void GameButton_MouseLeave(Object sender, EventArgs e)
        {
            if (GameState.EditMode) return;

            GameButton button = sender as GameButton;
            if (button.State == ButtonState.Yellow)
                ChangeState(Color.RoyalBlue, ButtonState.Active, "?");
        }

        public void GameButton_MouseDown(Object sender, MouseEventArgs e)
        {
            GameButton button = sender as GameButton;

            if(GameState.EditMode)
            {
                if (e.Button == MouseButtons.Left)
                {
                    ChangeState(Color.Black, ButtonState.Black);
                    addRemoveButton(this, TabIndex, true);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    ChangeState(Color.White, ButtonState.White);
                    addRemoveButton(this, TabIndex, false);
                }
                return;
            }

            if ((button.State != ButtonState.Yellow && button.State != ButtonState.White) || !GameState.ActiveGame) return;
            else if(e.Button == MouseButtons.Left)
            {
                if (button.ActiveInGame)
                    ChangeState(Color.Black, ButtonState.Black);
                else
                {
                    ChangeState(Color.Red, ButtonState.Red);
                    Task.Run(() => { Thread.Sleep(500); ChangeState(Color.RoyalBlue, ButtonState.Active, "?"); });
                }
            }
            else if (e.Button == MouseButtons.Right)
                ChangeState(Color.White, ButtonState.White);

            stateChanged(this, State);
        }

    }
}
