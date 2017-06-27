using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class SettingsBox : Form
    {

        public SettingsBox()
        {
            InitializeComponent();
        }

        public void AssignDefaultSettingsToControls()
        {
            timeUpDown.Value = GameState.GameTime;
            lifesUpDown.Value = GameState.LifesCount;
        }
        public void ApplySettings()
        {
            GameState.GameTime = (int)timeUpDown.Value;
            GameState.LifesCount = (int)lifesUpDown.Value;
        }

      
    }
}
