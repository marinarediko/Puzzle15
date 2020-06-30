using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle15
{
    public partial class PuzzleArea : Form
    {
        int betweenBlocks = 10;
        PuzzleBlock block;
        public PuzzleArea()
        {
            InitializeComponent();
            InitializePuzzleArea();
            InitializeBlocks();
        }

        private void InitializePuzzleArea()
        {
            this.BackColor = Color.LightGoldenrodYellow;
            this.Text = "Puzzle15";
            this.ClientSize = new Size(450, 450);         
        }

        private void InitializeBlocks()
        {
            int blockCount = 1;
            for (int row = 1; row < 5; row++)
            {
                for (int col = 1; col < 5; col++)
                {
                    block = new PuzzleBlock();               
                    block.Top = 10 + (block.Width + 10) * (row-1);
                    block.Left = 10 + (block.Width + 10) * (col-1);
                    block.Text = blockCount.ToString();
                    if (blockCount == 16)
                    {
                        block.Text = "";
                        block.BackColor = Color.LightGoldenrodYellow;
                    }
                    
                    blockCount++;
                    this.Controls.Add(block);
                }
            }
        }


    }
}
