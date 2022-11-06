using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessForm
{
    public partial class Form1 : Form
    {
        public int[,] clickedCell { get; set; }
        public GameController Controller;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BoardTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BoardTable_Click(object sender, EventArgs e)
        {

        }

        public void Start(int startCol, int startRow, int endCol, int endRow)
        {
            clickedCell = new int[1,2] { { startRow, startCol } };

            UpdateMoveCount(0);

            foreach (Control control in BoardTable.Controls)
            {
                PictureBox piece = control as PictureBox;

                if (this.BoardTable.GetRow(piece) == startRow && this.BoardTable.GetColumn(piece) == startCol)
                {
                    piece.BackColor = Color.AliceBlue;
                }
                else if (this.BoardTable.GetRow(piece) == endRow && this.BoardTable.GetColumn(piece) == endCol)
                {
                    piece.BackColor = Color.Orange;
                }
                else
                {
                    piece.BackColor = Color.FromArgb(200, 230, 255);
                }
            }
            Trace.WriteLine("Cell " + clickedCell.ToString());
        }

        public void NextMove(int[,] prevCell)
        {
            foreach (Control control in BoardTable.Controls)
            {
                PictureBox piece = control as PictureBox;
                if (BoardTable.GetRow(piece) == clickedCell[0,0] && BoardTable.GetColumn(piece) == clickedCell[0, 1])
                {
                    piece.BackColor = Color.AliceBlue;
                }
                else if (BoardTable.GetRow(piece) == prevCell[0, 0] && BoardTable.GetColumn(piece) == prevCell[0, 1])
                {
                    piece.BackColor = Color.FromArgb( 200, 230, 255 );
                }
            }
        }

        public void UpdateMoveCount(int moveCount)
        {
            MovesLabel.Text = moveCount.ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int pieceCol = getCol(sender);
            int pieceRow = getRow(sender);
            clickedCell = new int[1, 2] { { pieceRow, pieceCol } }; ;
            Controller.NextMove();
        }

        private int getCol(object sender)
        {
            PictureBox clickedPiece = sender as PictureBox;
            int pieceCol = this.BoardTable.GetColumn(clickedPiece);
            Trace.WriteLine("Piece Column: " + pieceCol.ToString());

            return pieceCol;
        }

        private int getRow(object sender)
        {
            PictureBox clickedPiece = sender as PictureBox;
            int pieceRow = this.BoardTable.GetRow(clickedPiece);
            Trace.WriteLine("Piece Row: " + pieceRow.ToString());

            return pieceRow;
        }

        public void SetController(GameController controller)
        {
            Controller = controller;
        }

        private void start_game_Click(object sender, EventArgs e)
        {
            Controller.Go();
            Button button = sender as Button;
            button.Text = "Reset";
        }

        public void EndGame()
        {
            EndMessage.Text = "Maze Complete!";
        }
    }
}
