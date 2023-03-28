using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;

namespace BrailleApi.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class DotPatternController : ControllerBase
    {
        [HttpGet("rectangle/{width}/{height}")]
        public IActionResult Rectangle(int width, int height)
        {
            string dotPattern = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    dotPattern += ".   ";
                }
                dotPattern += "\n";
            }
            return Ok(dotPattern);
        }
        [HttpGet("traingle/{height}")]
        public IActionResult traingle(int height)
        {
            string dotPattern = "";
            for (int i = 1; i <= height; i++)
            {
                for (int j = 1; j <= height - i; j++)
                {
                    dotPattern += " ";
                }
                for (int k = 1; k <= i; k++)
                {
                    dotPattern += ". ";
                }
                dotPattern += "\n";

            }
            return Ok(dotPattern);
        }
        [HttpGet("pyramid/{size}")]
        public IActionResult pyramid(int size)
        {
            string dotPattern = "";

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    dotPattern += " ";

                }
                for (int j = 0; j < i * 2 + 1; j++)
                {
                    dotPattern += ".";

                }
                dotPattern += "\n";
            }
            return Ok(dotPattern);
        }
        [HttpGet("X_mark/{size}")]
        public IActionResult X_mark(int size)
        {
            string dotPattern = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j || i == size - j - 1)
                    {
                        dotPattern += ".";
                    }
                    else
                    {
                        dotPattern += " ";
                    }
                }
                dotPattern += "\n";
            }
            return Ok(dotPattern);
        }
        [HttpGet("hexagon/{size}")]
        public IActionResult hexagon(int size)
        {
            string dotPattern = "";
            for (int row = 0; row < size * 2; row++)
            {
                int spaces = Math.Abs(size - row);
                int asterisks = size * 4 - spaces * 2;

                for (int i = 0; i < spaces; i++)
                {
                    dotPattern += " ";

                }
                for (int i = 0; i < asterisks; i++)
                {
                    if (i == 0 || i == asterisks - 1)
                    {
                        dotPattern += ".";

                    }
                    else if (row == 0 || row == size * 2 - 1)
                    {
                        dotPattern += ".";

                    }
                    else
                    {
                        dotPattern += " ";

                    }
                }

                dotPattern += "\n";
            }
        
            return Ok(dotPattern);
        }
        [HttpGet("diamond/{size}")]
        public IActionResult diamond(int size)
        {
            string dotPattern = "";


            int numRows = (size * 2) - 1;
            int numCols = (size * 2) - 1;

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    int rowOffset = Math.Abs(i - (numRows / 2));
                    int colOffset = Math.Abs(j - (numCols / 2));

                    if (rowOffset + colOffset == (numRows / 2))
                    {
                        dotPattern += ".";


                    }
                    else
                    {
                        dotPattern += " ";


                    }
                }
                dotPattern += "\n";
            }
            return Ok(dotPattern);
        }

        [HttpGet("heart/{size}")]
        public IActionResult heart(int size)
        {
            string dotPattern = "";

            for (int i = size / 2; i <= size; i += 2)
            {
                for (int j = 1; j <= size - i; j += 2)
                {
                    dotPattern += " ";

                }

                for (int j = 1; j <= i; j++)
                {
                    dotPattern += ".";

                }

                for (int j = 1; j <= size - i; j++)
                {
                    dotPattern += " ";

                }

                for (int j = 1; j <= i; j++)
                {
                    dotPattern += ".";

                }

                dotPattern += " ";

            }

            for (int i = size; i >= 1; i--)
            {
                for (int j = i; j < size; j++)
                {
                    dotPattern += " ";

                }

                for (int j = 1; j <= (i * 2) - 1; j++)
                {
                    dotPattern += ".";

                }
                dotPattern += " ";

            }
            return Ok(dotPattern);
        }

        [HttpGet("Christmas_tree/{height}")]
        public IActionResult Christmas_tree(int height)
        {
            string dotPattern = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height - i - 1; j++)
                {
                    dotPattern += " ";

                }
                for (int j = 0; j < i * 2 + 1; j++)
                {
                    dotPattern += ".";

                }
                dotPattern += "\n";
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < height - 2; j++)
                {
                    dotPattern += " ";

                }

                dotPattern += "...\n";

            }
            return Ok(dotPattern);
        }


        [HttpGet("circle/{radius}/{resolution}")]
        public IActionResult GetCircle(int radius, int resolution)
        {
            string dotPattern = "";
            double step = 2 * Math.PI / resolution;
            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    double distance = Math.Sqrt(x * x + y * y);
                    if (Math.Abs(distance - radius) < step / 2)
                    {
                        dotPattern += ".";
                    }
                    else
                    {
                        dotPattern += " ";
                    }
                }
                dotPattern += "\n";
            }
            return Ok(dotPattern);
        }

    }
}