using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

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
        public IActionResult Traingle(int height)
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
        public IActionResult Pyramid(int size)
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

        [HttpGet("circle/{radius}/{x}/{y}")]
        public IActionResult Circle(int radius, int x, int y)
        {
            Bitmap bitmap = new Bitmap(200, 200);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                Pen pen = new Pen(Color.Black, 2);
                DrawCircle(g, pen, x, x, radius);
                MemoryStream ms = new MemoryStream();
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] bytes = ms.ToArray();
                return File(bytes, "image/png");
            }
        }

        [HttpGet("arrow/{n}")]
        public IActionResult GetArrow(int n)
        {
            string dotPattern = "";

            // Upper part of the arrow
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i + 1; j++)
                {
                    dotPattern += " ";

                }
                for (int j = 1; j <= i; j++)
                {
                    dotPattern += ".";

                }

                // Add spaces before and after rectangle to align it in the middle
                int spacesBefore = (n - i + 1) - 1; // Spaces before rectangle
                int spacesAfter = (n - i + 1) - 1; // Spaces after rectangle

                for (int j = 1; j <= spacesBefore; j++)
                {
                    dotPattern += " ";

                }

                // Rectangle part
                if (i == 2 * n / 2) // Only middle row
                {
                    int width = 10; // Width of the rectangle

                    for (int j = 1; j <= width; j++)
                    {
                        dotPattern += ".";

                    }
                }
                else // Empty rows
                {
                    for (int j = 1; j <= spacesAfter + 1; j++)
                    {
                        dotPattern += " ";

                    }
                }

                Console.WriteLine();
            }

            // Lower part of the arrow
            for (int i = n - 1; i >= 1; i--)
            {
                for (int j = 1; j <= n - i + 1; j++)
                {
                    dotPattern += " ";

                }
                for (int j = 1; j <= i; j++)
                {
                    dotPattern += ".";

                }
                dotPattern += "\n";
            }
            return Ok(dotPattern);

        }



        private void DrawCircle(Graphics g, Pen pen, int x, int y, int radius)
        {
            float[] dashPattern = new float[] { 1f, 4f };
            pen.DashPattern = dashPattern;
            pen.EndCap = LineCap.Custom;
            pen.CustomEndCap = new CustomLineCap(null, new GraphicsPath(new PointF[] { new PointF(0, 0), new PointF(-2, 2), new PointF(2, 2), new PointF(0, 0) }, new byte[] { 0, 1, 1, 1 }));
            int rectX = x - radius;
            int rectY = y - radius;
            g.DrawEllipse(pen, rectX, rectY, radius * 2, radius * 2);
        }

    }

}        
    