using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;

namespace Puzzle
{
    public partial class Game : Form
    {
        private const int defaultLifesCount = 3;
        private const int defaultTime = 10;
        private const int interval = 1000;
        private const int boardSize = 4;
        private const int bonus = 50;
        private const int winningBonus = 500;

        GameButton[,] gameButtons = new GameButton[boardSize, boardSize];
        List<int> buttonNumbers = new List<int>();
        GameLabel[] topLabels = new GameLabel[boardSize];
        GameLabel[] leftLabels = new GameLabel[boardSize];
        int activeButtonsCount;
        bool existEditModeButtons;
        System.Timers.Timer updateBarTimer;

        public Game()
        {
            InitializeComponent();
            CreateBoard();
        }

        public void CreateBoard()
        {
            GameState.ActiveGame = false;
            GameState.EditMode = false;
            updateBarTimer = new System.Timers.Timer(defaultTime*100);
            updateBarTimer.Elapsed += UpdateBarTime_Elapsed;

            GameState.GameTime = defaultTime;
            GameState.LifesCount = defaultLifesCount;
            settingsBox.AssignDefaultSettingsToControls();
            GameState.Score = 0;
            SetGameState();
            
            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                {
                    GameButton button = new GameButton();
                    button.SetButtonStyles(Color.RoyalBlue, "?");
                    button.SetButtonEvents();
                    button.TabIndex = i * boardSize + j;
                    button.ActiveInGame = false;
                    gameButtons[i, j] = button;
                    boardPanel.Controls.Add(button, i + 1, j + 1);
                    button.stateChanged += Button_StateChanged;
                    button.addRemoveButton += Button_AddRemoveButton;
                }

            CreateLabels();
        }

        public void CreateLabels()
        {
            for (int i = 0; i < boardSize; i++)
            {
                topLabels[i] = new GameLabel();
                topLabels[i].SetLabelStyles();
                topLabels[i].ActiveButtonsCount = 0;
                boardPanel.Controls.Add(topLabels[i], i + 1, 0);

                leftLabels[i] = new GameLabel();
                leftLabels[i].SetLabelStyles();
                leftLabels[i].ActiveButtonsCount = 0;
                boardPanel.Controls.Add(leftLabels[i], 0, i + 1);
            }
        }

        public void RecreateBoard()
        {
            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                {
                    GameButton button = gameButtons[i, j];
                    button.SetButtonStyles(Color.RoyalBlue, "?");
                    button.State = GameButton.ButtonState.Active;
                    button.ActiveInGame = false;
                }
        }

        public void RecreateLabels()
        {
            for (int i = 0; i < boardSize; i++)
            {
                topLabels[i].ActiveButtonsCount = 0;
                leftLabels[i].ActiveButtonsCount = 0;
            }
        }

        public void SetGameState()
        {
            existEditModeButtons = false;
            GameState.ClickedCorrectButtons = 0;
            GameState.LeftLifesCount = GameState.LifesCount;
            UpdateStatusLabels();
            UpdateBarTimeSettings();
        }

        public void UpdateStatusLabels()
        {
            scoreLabel.Text = "Score: " + GameState.Score.ToString();
            lifeLabel.Text = "Lifes: " + GameState.LeftLifesCount.ToString();
        }

        public void ShowLabelNumbers()
        {
            for (int i = 0; i < boardSize; i++)
            {
                topLabels[i].SetNumber();
                leftLabels[i].SetNumber();
            }
        }

        public void RemoveLabelNumbers()
        {
            for (int i = 0; i < boardSize; i++)
            {
                topLabels[i].RemoveNumbers();
                leftLabels[i].RemoveNumbers();
            }
        }

        public void RandActiveButtons()
        {
            Random random = new Random();

            activeButtonsCount = random.Next(boardSize, boardSize * boardSize);
            buttonNumbers = Enumerable.Range(0, boardSize * boardSize).OrderBy(x => random.Next()).Take(activeButtonsCount).ToList();
        }

        public void PlaceButtonsOnBoard()
        {
            activeButtonsCount = buttonNumbers.Count;
            for (int i = 0; i < buttonNumbers.Count; i++)
            {
                int row = buttonNumbers[i] / boardSize;
                int column = buttonNumbers[i] % boardSize;
                gameButtons[row, column].ActiveInGame = true;

                topLabels[row].ActiveButtonsCount++;
                leftLabels[column].ActiveButtonsCount++;
            }

            // potem out
            /*for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                {
                    if (gameButtons[i, j].ActiveInGame)
                        gameButtons[i, j].Text = "YES";
                }*/
        }

        public void UpdateBarTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            progressBarTime.PerformStep();
            if (progressBarTime.Value == 0)
                GameOver();
        }

        public void GameOver()
        {
            updateBarTimer.Stop();
            MessageBox.Show("Your final score is: " + GameState.Score.ToString(), "Congratulations!", MessageBoxButtons.OK);
            GameState.Score = 0;
            GameState.ActiveGame = false;
        }

        public void Button_AddRemoveButton(object sender, int buttonNumber, bool add)
        {
            if (add)
                buttonNumbers.Add(buttonNumber);
            else
                buttonNumbers.Remove(buttonNumber);
        }

        public void Button_StateChanged(object sender, GameButton.ButtonState state)
        {
            if(state == GameButton.ButtonState.Black)
            {
                GameState.ClickedCorrectButtons++;
                GameState.Score += bonus;
                scoreLabel.Text = "Score: " + GameState.Score.ToString();
            }
            else if(state == GameButton.ButtonState.Red)
            {
                GameState.LeftLifesCount--;
                lifeLabel.Text = "Lifes: " + GameState.LeftLifesCount.ToString();
            }

            if (GameState.ClickedCorrectButtons == activeButtonsCount)
            {
                GameState.Score += winningBonus;
                StartNewGame();
            }
           
            if (GameState.LeftLifesCount == 0)
                GameOver();
        }

        public void UpdateBarTimeSettings()
        {
            updateBarTimer.Interval = GameState.GameTime * 100;
            progressBarTime.Maximum = GameState.GameTime * 100;
            progressBarTime.Value = progressBarTime.Maximum;
            progressBarTime.Step = -progressBarTime.Maximum / 10;
        }
        
        public void ChangeButtonsLayout()
        {
            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    gameButtons[i, j].SetButtonStyles(Color.White, "");
        }

        public void ChangeParametersToEditMode()
        {
            updateBarTimer.Stop();

            gameMode.Checked = false;
            editMode.Checked = true;

            NewGame.Enabled = false;
            setings.Enabled = false;
            open.Enabled = false;
            save.Enabled = true;

            GameState.EditMode = true;
            existEditModeButtons = true;
            menuStrip.BackColor = Color.Gold;
            buttonNumbers.Clear();
        }

        public void ChangeParametersToGameMode()
        {
            gameMode.Checked = true;
            editMode.Checked = false;

            menuStrip.BackColor = SystemColors.Control;
            NewGame.Enabled = true;
            setings.Enabled = true;
            open.Enabled = true;
            save.Enabled = false;

            GameState.EditMode = false;
        }

        private void editMode_Click(object sender, EventArgs e)
        {
            ChangeParametersToEditMode();
            RemoveLabelNumbers();
            ChangeButtonsLayout();
        }

        private void gameMode_Click(object sender, EventArgs e)
        {
            ChangeParametersToGameMode();
            GameState.Score = 0;
            UpdateStatusLabels();
            StartNewGame();
        }
        public void StartNewGame()
        {
            RecreateBoard();
            RecreateLabels();
            if (!existEditModeButtons || buttonNumbers.Count == 0)
                RandActiveButtons();
            PlaceButtonsOnBoard();
            ShowLabelNumbers();
            SetGameState();
            GameState.ActiveGame = true;
            updateBarTimer.Enabled = true;
        }

        public void newGame_Click(Object sender, EventArgs e)
        {
            GameState.Score = 0;
            StartNewGame();
        }

        public void setings_Click(object sender, EventArgs e)
        {
            updateBarTimer.Stop();

            if (settingsBox.ShowDialog() == DialogResult.OK)
            {
                settingsBox.ApplySettings();
                GameState.LeftLifesCount = GameState.LifesCount;
                UpdateBarTimeSettings();
                UpdateStatusLabels();
            }
            updateBarTimer.Enabled = true;
        }
    
        private void open_Click(object sender, EventArgs e)
        {
            updateBarTimer.Stop();

            var openDialog = new OpenFileDialog();
            openDialog.Filter = @"PuzzleGame files (*.pg) | *.pg";
            openDialog.Title = "Select a PuzzleGame file";

            if(openDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openDialog.FileName, FileMode.Open);
                XmlSerializer xs = new XmlSerializer(typeof(List<int>));
                buttonNumbers = (List<int>)xs.Deserialize(fs);
                fs.Close();
            }

            existEditModeButtons = true;
            GameState.Score = 0;
            StartNewGame();
        }

        public void save_Click(object sender, EventArgs e)
        {
            updateBarTimer.Stop();

            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = @"PuzzleGame files (*.pg) | *.pg";
            saveDialog.Title = "Save a PuzzleGame file";
            saveDialog.AddExtension = true;
        
            if (saveDialog.ShowDialog() == DialogResult.OK && saveDialog.FileName != "")
            {
                FileStream fs = new FileStream(saveDialog.FileName, FileMode.Create);
                XmlSerializer xs = new XmlSerializer(typeof(List<int>));
                xs.Serialize(fs, buttonNumbers);
                fs.Close();
            }
        }

        public void Game_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.YesNo))
                e.Cancel = true;
        }
    }
}
