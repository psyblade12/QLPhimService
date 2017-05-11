using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLPhimService
{
    public static class GiaiThuat
    {
        public static int MaHoaBaoMatRSA(int e, int N, int M)
        {
            int C = binhphuonglientiep(M, e, N);
            return C;
        }
        public static int GiaiMaBaoMatRSA(int d, int N, int C)
        {
            int Mngang = binhphuonglientiep(C, d, N);
            return Mngang;
        }
        public static int MaHoaChungThucRSA(int d, int N, int M)
        {
            int C = binhphuonglientiep(M, d, N);
            return C;
        }
        public static int GiaiMaChungThucRSA(int e, int N, int C)
        {
            int Mngang = binhphuonglientiep(C, e, N);
            return Mngang;
        }
        public static int binhphuonglientiep(int a, int k, int m)
        {
            int p;
            if (k == 0)
            {
                return 1;
            }
            else
            {
                p = binhphuonglientiep(a, k / 2, m);
                if (k % 2 == 0)
                    return (p * p) % m;
                else
                    return (p * p * a) % m;
            }
        }
    }
}