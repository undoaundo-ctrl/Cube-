using System;
using System.Runtime.InteropServices;

unsafe class Program
{
    [DllImport("rot")]
    static extern void rotate3(float* p, float* m);

    static void Main()
    {
        const int W = 80, H = 40;
        float[,] v = {
            {-1,-1,-1},{1,-1,-1},{1,1,-1},{-1,1,-1},
            {-1,-1, 1},{1,-1, 1},{1,1, 1},{-1,1, 1}
        };
        int[,] e = {
            {0,1},{1,2},{2,3},{3,0},{4,5},{5,6},{6,7},{7,4},
            {0,4},{1,5},{2,6},{3,7}
        };

        Console.CursorVisible = false;
        Console.Clear();
        float a = 0, b = 0;

        while (!Console.KeyAvailable)
        {
            float ca = MathF.Cos(a), sa = MathF.Sin(a);
            float cb = MathF.Cos(b), sb = MathF.Sin(b);
            float* m = stackalloc float[9] {
                cb, sa*sb, ca*sb,
                0,  ca,   -sa,
               -sb, sa*cb, ca*cb
            };

            float[] px = new float[8], py = new float[8];
            for (int i = 0; i < 8; i++)
            {
                float* p = stackalloc float[3] { v[i,0], v[i,1], v[i,2] };
                rotate3(p, m);
                float d = 1f / (p[2] + 4f);
                px[i] = W / 2 + p[0] * d * 60;
                py[i] = H / 2 + p[1] * d * 30;
            }

            char[,] buf = new char[H, W];
            for (int y = 0; y < H; y++)
                for (int x = 0; x < W; x++) buf[y, x] = ' ';

            for (int k = 0; k < 12; k++)
                for (int t = 0; t <= 60; t++)
                {
                    float f = t / 60f;
                    int x = (int)(px[e[k,0]] + (px[e[k,1]] - px[e[k,0]]) * f);
                    int y = (int)(py[e[k,0]] + (py[e[k,1]] - py[e[k,0]]) * f);
                    if (x >= 0 && x < W && y >= 0 && y < H) buf[y, x] = '#';
                }

            Console.SetCursorPosition(0, 0);
            var sbd = new System.Text.StringBuilder();
            for (int y = 0; y < H; y++)
            {
                for (int x = 0; x < W; x++) sbd.Append(buf[y, x]);
                sbd.Append('\n');
            }
            Console.Write(sbd.ToString());

            a += 0.04f; b += 0.03f;
            System.Threading.Thread.Sleep(30);
        }
        Console.CursorVisible = true;
    }
}
