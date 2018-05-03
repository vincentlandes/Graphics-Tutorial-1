using System;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using System.IO;

namespace Template {

class Game
{
	// member variables
	public Surface screen;
        int offsetx = 200;
        int offsety = 50;
        float a = .5f;
        Surface map;
        float[,] h;
	// initialize
	public void Init()
	{
            map = new Surface("D:/Documents/Visual Studio Projects/Graphics Tutorial 1/heightmap.png");
            h = new float[128, 128];
            for (int y = 0; y < 128; y++) for (int x = 0; x < 128; x++)
                    h[x, y] = ((float)(map.pixels[x + y * 128] & 255)) / 256;

            for (int i = 0; i < 127; i++)
            {
                for (int j = 0; j < 127; j++)
                {
                    //driehoek met pos x en y >> i j
                    //driehoek heeft hoogte z die in h is opgeslagen op pos h[i,j]
                }
            }
        }
	// tick: renders one frame
	public void Tick()
	{
		screen.Clear( 0 );
		screen.Print( "hello world", 2, 2, 0xffffff );
        screen.Line(2, 20, 160, 20, 0xff0000);
            a += 1f / 30;
            Ex3(a);
	}
    
    void Ex3(float a)
        {



            // top-left corner
            float x1 = -1, y1 = 1.0f;
            float rx1 = (float)(x1 * Math.Cos(a) - y1 * Math.Sin(a));
            float ry1 = (float)(x1 * Math.Sin(a) + y1 * Math.Cos(a));

            // top-right corner
            float x2 = 1, y2 = 1.0f;
            float rx2 = (float)(x2 * Math.Cos(a) - y2 * Math.Sin(a));
            float ry2 = (float)(x2 * Math.Sin(a) + y2 * Math.Cos(a));

            // bottom-right corner
            float x3 = 1, y3 = -1.0f;
            float rx3 = (float)(x3 * Math.Cos(a) - y3 * Math.Sin(a));
            float ry3 = (float)(x3 * Math.Sin(a) + y3 * Math.Cos(a));

            // bottom-left corner
            float x4 = -1, y4 = -1.0f;
            float rx4 = (float)(x4 * Math.Cos(a) - y4 * Math.Sin(a));
            float ry4 = (float)(x4 * Math.Sin(a) + y4 * Math.Cos(a));

            int cubesizex = screen.width/10;
            int cubesizey = screen.height / 10;
            int offset = screen.width/2 - 100;

            screen.Line(offset + (int)(rx1 * cubesizex), offset + (int)(ry1 * cubesizey), offset + (int)(rx2 * cubesizex), offset + (int)(ry2 * cubesizey), 0xff0000);
            screen.Line(offset + (int)(rx2 * cubesizex), offset + (int)(ry2 * cubesizey), offset + (int)(rx3 * cubesizex), offset + (int)(ry3 * cubesizey), 0x0000ff);
            screen.Line(offset + (int)(rx3 * cubesizex), offset + (int)(ry3 * cubesizey), offset + (int)(rx4 * cubesizex), offset + (int)(ry4 * cubesizey), 0xff00ff);
            screen.Line(offset + (int)(rx4 * cubesizex), offset + (int)(ry4 * cubesizey), offset + (int)(rx1 * cubesizex), offset + (int)(ry1 * cubesizey), 0xffff00);
        }

    void Ex1()
        {
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    int location = x + (y + offsety) * screen.width + offsetx;
                    //int pixel = screen.pixels[location];
                    screen.pixels[location] = CreateColor(x, y, 0);
                }
            }
        }

    int CreateColor(int red, int green, int blue)
        {
            return (red << 16) + (green << 8) + blue;
        }
    
    public void RenderGL()
        {
            GL.Color3(1.0f, 0.0f, 0.0f);

            /*var M = Matrix4.CreatePerspectiveFieldOfView(1.6f, 1.3f, .1f, 1000);
            GL.LoadMatrix(ref M);
            GL.Translate(0, 0, -1);
            GL.Rotate(110, 1, 0, 0);
            GL.Rotate(a * 180 / Math.PI, 0, 0, 1);            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex3(-0.5f, -0.5f, 0);
            GL.Vertex3(0.5f, -0.5f, 0);
            GL.Vertex3(-0.5f, 0.5f, 0);
            */

            GL.Vertex3(-0.5f, -0.5f, 0);
            GL.Vertex3(0.5f, -0.5f, 0);
            GL.Vertex3(-0.5f, 0.5f, 0);



            GL.End(); 
        }

    }

} // namespace Template