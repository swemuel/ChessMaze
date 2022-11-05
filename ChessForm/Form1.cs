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
            clickedCell = new int[startRow, startCol];

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
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int pieceCol = getCol(sender);
            int pieceRow = getRow(sender);
            int[,] pieceCell = new int[,] { { pieceCol }, { pieceRow } };
            clickedCell = pieceCell;
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
        }
    }
}
