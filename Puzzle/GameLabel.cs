using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    class GameLabel: Label
    {
        public int ActiveButtonsCount { get; set; }

        public GameLabel():base() { }

        public void SetLabelStyles()
        {
            Dock = DockStyle.Fill;
            Size = new Size(50, 50);
            Font = new Font("Microsoft Sans Serif", 14);
            TextAlign = ContentAlignment.MiddleCenter;
        }

        public void SetNumber()
        {
            Text = ActiveButtonsCount.ToString();
        }

        public void RemoveNumbers()
        {
            Text = "";
        }

       
    }
}
