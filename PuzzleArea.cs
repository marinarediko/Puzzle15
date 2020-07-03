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
        bool[] ifNumerized = new bool[15];

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
                    block.Name = "block" + blockCount.ToString();   
                    block.FlatStyle = FlatStyle.Flat;
                    block.FlatAppearance.BorderSize = 0;
                    block.Top = betweenBlocks + (block.Width + betweenBlocks) * (row - 1);
                    block.Left = betweenBlocks + (block.Width + betweenBlocks) * (col - 1);
               
                    if (blockCount < 16)
                        block.Text = RandomizeBlockNumbers();

                    block.Click += new EventHandler(Block_Click);

                    if (blockCount == 16)
                    {
                        block.Name = "EmptyBlock";
                        block.Text = "";
                        block.BackColor = Color.LightGoldenrodYellow;
                    }
                    
                    blockCount++;
                    this.Controls.Add(block);
                }
            }
        }

        private void Block_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(((PuzzleBlock)sender).Text);
            Button block = (Button)sender;
            if (IsAdjacent(block))
            {
                SwapBlocks(block);
            }
        }

        private void SwapBlocks(Button block)
        {
             Button emptyBlock = (Button)this.Controls["EmptyBlock"];
             Point oldLocation = block.Location;
             block.Location = emptyBlock.Location;
             emptyBlock.Location = oldLocation;
        }

        private bool IsAdjacent(Button block)
        {
            double a;
            double b;
            double c;
            Button emptyBlock = (Button)this.Controls["EmptyBlock"];

            a = Math.Abs(emptyBlock.Top - block.Top);
            b = Math.Abs(emptyBlock.Left - block.Left);
            c = a + b;
            if (c == betweenBlocks + block.Width)
                return true;
            else
                return false;
        }

        private string RandomizeBlockNumbers()
        {
            int blockNum;
            bool blockNumGenerated;
            Random randBlockNum = new Random();

            do
            {
                blockNumGenerated = false;
                blockNum = randBlockNum.Next(1, 16);
                if (ifNumerized[blockNum - 1] == false)
                {
                    block.Text = blockNum.ToString();
                    ifNumerized[blockNum - 1] = true;
                    blockNumGenerated = true;
                }
            }
            while (!blockNumGenerated);
            
            return blockNum.ToString();
        }

        
    }
}
