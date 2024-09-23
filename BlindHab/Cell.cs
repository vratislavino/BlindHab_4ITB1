using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlindHab
{
    public partial class Cell : UserControl
    {
        CellType cellType;
        public event Action<Cell> MoveReqested;

        public CellType CellType
        {
            get { return cellType; }
            set
            {
                cellType = value;
                switch (cellType)
                {
                    case CellType.Empty:
                        BackColor = Color.White;
                        break;
                    case CellType.Wall:
                        BackColor = Color.Black;
                        break;
                    case CellType.Kfc:
                        BackColor = Color.Red;
                        break;
                    case CellType.Hab:
                        BackColor = Color.Green;
                        break;
                }
            }
        }

        public Cell()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void Cell_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if(CellType == CellType.Wall)
                {
                    MoveReqested?.Invoke(this);
                }
            }
        }
    }

    public enum CellType
    {
        Empty,
        Wall, 
        Kfc,
        Hab//ik
    }
}
