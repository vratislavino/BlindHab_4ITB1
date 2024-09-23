namespace BlindHab
{
    public partial class Form1 : Form
    {
        Cell[,] cells;
        const int size = 10;
        Random generator = new Random();

        Queue<Tuple<Action<Cell>, Cell>> queue = new Queue<Tuple<Action<Cell>, Cell>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGrid();
            GetRandomEmptyCell().CellType = CellType.Kfc;
            GetRandomEmptyCell().CellType = CellType.Hab;
        }

        private void InitializeGrid()
        {
            cells = new Cell[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    cells[i, j] = new Cell();
                    cells[i, j].CellType = GetRandomCellType();
                    cells[i, j].Location =
                        new Point(i * cells[i, j].Width, j * cells[i, j].Height);
                    cells[i, j].MoveReqested += OnMoveRequested;
                    panel1.Controls.Add(cells[i, j]);
                }
            }
        }

        private void OnMoveRequested(Cell cell)
        {
            queue.Enqueue(new Tuple<Action<Cell>, Cell>(RemoveWall, cell));
        }

        private void RemoveWall(Cell cell)
        {
            // najít empty cell a udìlat z ní wall
            // vzít cell a udìlat z Wall Empty
        }

        private CellType GetRandomCellType()
        {
            return generator.NextDouble() < 0.5f ? CellType.Empty : CellType.Wall;
        }

        private Cell GetRandomEmptyCell()
        {
            while (true)
            {
                int x = generator.Next(size);
                int y = generator.Next(size);
                if (cells[x, y].CellType == CellType.Empty)
                {
                    return cells[x, y];
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(queue.Count > 0)
            {
                var action = queue.Dequeue();
                action.Item1(action.Item2);
            }
        }
    }
}
