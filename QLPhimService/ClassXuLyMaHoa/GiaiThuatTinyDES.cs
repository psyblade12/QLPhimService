using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhimService
{
    public static class GiaiThuatTinyDES
    {
        public static string ChuyenKiTuThanhNhiPhan(char kitu)
        {
            var text = kitu.ToString();
            var bytes = Encoding.UTF8.GetBytes(text);
            string ketqua = string.Join(" ", bytes.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
            return ketqua;
        }
        public static string ChuyenNhiPhanThanhKiTu(string binary)
        {
            if (string.IsNullOrEmpty(binary))
                throw new ArgumentNullException("binary");

            if ((binary.Length % 8) != 0)
                throw new ArgumentException("Phải có đúng 8 kí tự", "binary");

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < binary.Length; i += 8)
            {
                string section = binary.Substring(i, 8);
                int ascii = 0;
                try
                {
                    ascii = Convert.ToInt32(section, 2);
                }
                catch
                {
                    throw new ArgumentException("Có lỗi: " + section, "binary");
                }
                builder.Append((char)ascii);
            }
            return builder.ToString();
        }
        public static string Expand(string chuoimuonexpand)
        {
            char[] mangcharchuachuoimuonexpand = chuoimuonexpand.ToCharArray();
            string chuoiketqua = mangcharchuachuoimuonexpand[2].ToString() + mangcharchuachuoimuonexpand[3].ToString() + mangcharchuachuoimuonexpand[1].ToString() + mangcharchuachuoimuonexpand[2].ToString() + mangcharchuachuoimuonexpand[1].ToString() + mangcharchuachuoimuonexpand[0].ToString();
            return chuoiketqua;
        }
        public static string Compress(string chuoi1, string chuoi2)
        {
            string chuoimuoncompress = chuoi1 + chuoi2;
            char[] mangcharchuachuoimuoncompress = chuoimuoncompress.ToCharArray();
            string chuoiketqua = mangcharchuachuoimuoncompress[5].ToString() + mangcharchuachuoimuoncompress[1].ToString() + mangcharchuachuoimuoncompress[3].ToString() + mangcharchuachuoimuoncompress[2].ToString() + mangcharchuachuoimuoncompress[7].ToString() + mangcharchuachuoimuoncompress[0].ToString();
            return chuoiketqua;
        }
        public static string DichVong(string chuoimuondich, int solandich)
        {
            string ketqua = chuoimuondich.Substring(solandich) + chuoimuondich.Substring(0, solandich);
            return ketqua;
        }
        public static string DichVongTruoc(string chuoimuondich, int solandich)
        {
            string ketqua = chuoimuondich.Substring(chuoimuondich.Length - solandich, solandich) + chuoimuondich.Substring(0, chuoimuondich.Length - solandich);
            return ketqua;
        }
        public static char XorKiTu(char a, char b)
        {
            char ketqua = '1';
            if (a == '1' && b == '1')
            {
                ketqua = '0';
            }
            else if (a == '0' && b == '0')
            {
                ketqua = '0';
            }
            else
            {
                ketqua = '1';
            }
            return ketqua;
        }
        public static string Xor2Chuoi(string chuoi1, string chuoi2)
        {
            char[] cackitucuachuoi1 = chuoi1.ToCharArray();
            char[] cackitucuachuoi2 = chuoi2.ToCharArray();
            for (int i = 0; i < cackitucuachuoi1.Length; i++)
            {
                cackitucuachuoi1[i] = XorKiTu(cackitucuachuoi1[i], cackitucuachuoi2[i]);
            }
            string ketqua = new string(cackitucuachuoi1);
            return ketqua;
        }
        public static string[,] TaoBangSbox()
        {
            string[,] bangtra = new string[4, 16];
            bangtra[0, 0] = "1110";
            bangtra[0, 1] = "0100";
            bangtra[0, 2] = "1101";
            bangtra[0, 3] = "0001";
            bangtra[0, 4] = "0010";
            bangtra[0, 5] = "1111";
            bangtra[0, 6] = "1011";
            bangtra[0, 7] = "1000";
            bangtra[0, 8] = "0011";
            bangtra[0, 9] = "1010";
            bangtra[0, 10] = "0110";
            bangtra[0, 11] = "1100";
            bangtra[0, 12] = "0101";
            bangtra[0, 13] = "1001";
            bangtra[0, 14] = "0000";
            bangtra[0, 15] = "0111";

            bangtra[1, 0] = "0000";
            bangtra[1, 1] = "1111";
            bangtra[1, 2] = "0111";
            bangtra[1, 3] = "0100";
            bangtra[1, 4] = "1110";
            bangtra[1, 5] = "0010";
            bangtra[1, 6] = "1101";
            bangtra[1, 7] = "0001";
            bangtra[1, 8] = "1010";
            bangtra[1, 9] = "0110";
            bangtra[1, 10] = "1100";
            bangtra[1, 11] = "1011";
            bangtra[1, 12] = "1001";
            bangtra[1, 13] = "0101";
            bangtra[1, 14] = "0011";
            bangtra[1, 15] = "1000";

            bangtra[2, 0] = "0100";
            bangtra[2, 1] = "0001";
            bangtra[2, 2] = "1110";
            bangtra[2, 3] = "1000";
            bangtra[2, 4] = "1101";
            bangtra[2, 5] = "0110";
            bangtra[2, 6] = "0010";
            bangtra[2, 7] = "1011";
            bangtra[2, 8] = "1111";
            bangtra[2, 9] = "1100";
            bangtra[2, 10] = "1001";
            bangtra[2, 11] = "0111";
            bangtra[2, 12] = "0011";
            bangtra[2, 13] = "1010";
            bangtra[2, 14] = "0101";
            bangtra[2, 15] = "0000";

            bangtra[3, 0] = "1111";
            bangtra[3, 1] = "1100";
            bangtra[3, 2] = "1000";
            bangtra[3, 3] = "0010";
            bangtra[3, 4] = "0100";
            bangtra[3, 5] = "1001";
            bangtra[3, 6] = "0001";
            bangtra[3, 7] = "0111";
            bangtra[3, 8] = "0101";
            bangtra[3, 9] = "1011";
            bangtra[3, 10] = "0011";
            bangtra[3, 11] = "1110";
            bangtra[3, 12] = "1010";
            bangtra[3, 13] = "0000";
            bangtra[3, 14] = "0110";
            bangtra[3, 15] = "1101";
            return bangtra;
        }
        public static string Sbox(string chuoidauvao)
        {
            int b1b2b3b4 = Convert.ToInt32(chuoidauvao.Substring(1, 4), 2);
            int b0b5 = Convert.ToInt32(chuoidauvao.Substring(0, 1) + chuoidauvao.Substring(5, 1), 2);
            string[,] bangtra = TaoBangSbox();
            string ketqua = bangtra[b0b5, b1b2b3b4];
            return ketqua;
        }
        public static string Pbox(string chuoidauvao)
        {
            char[] mangchuachuoidauvao = chuoidauvao.ToCharArray();
            string ketqua = mangchuachuoidauvao[2].ToString() + mangchuachuoidauvao[0].ToString() + mangchuachuoidauvao[3].ToString() + mangchuachuoidauvao[1].ToString();
            return ketqua;
        }
        public static string ChuyenThanhDecima8KiTu(string chuoidecima)
        {
            string ketqua = chuoidecima;
            int demsokituconthieu = 8 - chuoidecima.Length;
            if (demsokituconthieu > 0)
            {
                ketqua = "0" + ketqua;
                if (ketqua.Length < 8)
                {
                    ketqua = ChuyenThanhDecima8KiTu(ketqua);
                }
            }
            return ketqua;
        }
        public static string ChuyenThanhDecima16KiTu(string chuoidecima)
        {
            string ketqua = chuoidecima;
            int demsokituconthieu = 16 - chuoidecima.Length;
            if (demsokituconthieu > 0)
            {
                ketqua = "0" + ketqua;
                if (ketqua.Length < 16)
                {
                    ketqua = ChuyenThanhDecima16KiTu(ketqua);
                }
            }
            return ketqua;
        }
        public static string GiaiMaTinyDES(char charcangiaima, string khoanhapvao)
        {
            char kitucangiama = charcangiaima;
            int sodecima = Convert.ToInt32(kitucangiama);
            string chuoinhiphan = Convert.ToString(sodecima, 2);
            chuoinhiphan = ChuyenThanhDecima8KiTu(chuoinhiphan);
            string L3 = chuoinhiphan.Substring(0, 4);
            string R3 = chuoinhiphan.Substring(4);
            string khoa = khoanhapvao;
            string KL3 = khoa.Substring(0, 4);
            string KR3 = khoa.Substring(4);
            string P = "";
            //Giải mã
            for (int i = 1; i <= 3; i++)
            {
                string R2 = L3;
                string KL2, KR2;
                string expandR2 = GiaiThuatTinyDES.Expand(R2);
                if (i == 2)
                {
                    KL2 = GiaiThuatTinyDES.DichVongTruoc(KL3, 2);
                    KR2 = GiaiThuatTinyDES.DichVongTruoc(KR3, 2);
                }
                else
                {
                    KL2 = GiaiThuatTinyDES.DichVongTruoc(KL3, 1);
                    KR2 = GiaiThuatTinyDES.DichVongTruoc(KR3, 1);
                }
                string K3 = GiaiThuatTinyDES.Compress(KL3, KR3);
                string xorexpandR2K3 = GiaiThuatTinyDES.Xor2Chuoi(expandR2, K3);
                string sbox = GiaiThuatTinyDES.Sbox(xorexpandR2K3);
                string F3 = GiaiThuatTinyDES.Pbox(sbox);
                string L2 = GiaiThuatTinyDES.Xor2Chuoi(R3, F3);
                P = L2 + R2;
                L3 = L2;
                R3 = R2;
                KL3 = KL2;
                KR3 = KR2;
            }
            int soketquagiaima = Convert.ToInt32(P, 2);
            char kituketqua = Convert.ToChar(soketquagiaima);
            return kituketqua.ToString();
        }
        public static string GiaiMaTinyDES2(char charcangiaima, string khoanhapvao)
        {
            char kitucangiama = charcangiaima;
            int sodecima = Convert.ToInt32(kitucangiama);
            string chuoinhiphan = Convert.ToString(sodecima, 2);
            chuoinhiphan = ChuyenThanhDecima16KiTu(chuoinhiphan);
            string tam = chuoinhiphan.Substring(8);
            chuoinhiphan = chuoinhiphan.Substring(0, 8);
            string L3 = chuoinhiphan.Substring(0, 4);
            string R3 = chuoinhiphan.Substring(4);
            string khoa = khoanhapvao;
            string KL3 = khoa.Substring(0, 4);
            string KR3 = khoa.Substring(4);
            string P = "";
            //Giải mã
            for (int i = 1; i <= 3; i++)
            {
                string R2 = L3;
                string KL2, KR2;
                string expandR2 = GiaiThuatTinyDES.Expand(R2);
                if (i == 2)
                {
                    KL2 = GiaiThuatTinyDES.DichVongTruoc(KL3, 2);
                    KR2 = GiaiThuatTinyDES.DichVongTruoc(KR3, 2);
                }
                else
                {
                    KL2 = GiaiThuatTinyDES.DichVongTruoc(KL3, 1);
                    KR2 = GiaiThuatTinyDES.DichVongTruoc(KR3, 1);
                }
                string K3 = GiaiThuatTinyDES.Compress(KL3, KR3);
                string xorexpandR2K3 = GiaiThuatTinyDES.Xor2Chuoi(expandR2, K3);
                string sbox = GiaiThuatTinyDES.Sbox(xorexpandR2K3);
                string F3 = GiaiThuatTinyDES.Pbox(sbox);
                string L2 = GiaiThuatTinyDES.Xor2Chuoi(R3, F3);
                P = L2 + R2;
                L3 = L2;
                R3 = R2;
                KL3 = KL2;
                KR3 = KR2;
            }
            string ketqua = P;
            chuoinhiphan = tam;
            L3 = chuoinhiphan.Substring(0, 4);
            R3 = chuoinhiphan.Substring(4);
            khoa = khoanhapvao;
            KL3 = khoa.Substring(0, 4);
            KR3 = khoa.Substring(4);
            P = "";
            //Giải mã
            for (int i = 1; i <= 3; i++)
            {
                string R2 = L3;
                string KL2, KR2;
                string expandR2 = GiaiThuatTinyDES.Expand(R2);
                if (i == 2)
                {
                    KL2 = GiaiThuatTinyDES.DichVongTruoc(KL3, 2);
                    KR2 = GiaiThuatTinyDES.DichVongTruoc(KR3, 2);
                }
                else
                {
                    KL2 = GiaiThuatTinyDES.DichVongTruoc(KL3, 1);
                    KR2 = GiaiThuatTinyDES.DichVongTruoc(KR3, 1);
                }
                string K3 = GiaiThuatTinyDES.Compress(KL3, KR3);
                string xorexpandR2K3 = GiaiThuatTinyDES.Xor2Chuoi(expandR2, K3);
                string sbox = GiaiThuatTinyDES.Sbox(xorexpandR2K3);
                string F3 = GiaiThuatTinyDES.Pbox(sbox);
                string L2 = GiaiThuatTinyDES.Xor2Chuoi(R3, F3);
                P = L2 + R2;
                L3 = L2;
                R3 = R2;
                KL3 = KL2;
                KR3 = KR2;
            }
            ketqua = ketqua + P;
            int soketquagiaima = Convert.ToInt32(ketqua, 2);
            char kituketqua = Convert.ToChar(soketquagiaima);
            return kituketqua.ToString();
        }
        public static string MaHoaTinyDES2(char charcanmahoa, string khoanhapvao)
        {
            char kitucanmahoa = charcanmahoa;
            int sodecima = Convert.ToInt32(charcanmahoa);
            string chuoinhiphan = Convert.ToString(sodecima, 2);
            chuoinhiphan = ChuyenThanhDecima16KiTu(chuoinhiphan);
            string tam = chuoinhiphan.Substring(8);
            chuoinhiphan = chuoinhiphan.Substring(0, 8);
            string khoa = khoanhapvao;
            string KL0 = khoa.Substring(0, 4);
            string KR0 = khoa.Substring(4);
            string L0 = chuoinhiphan.Substring(0, 4);
            string R0 = chuoinhiphan.Substring(4);
            string C = "";
            //Vòng 1
            for (int i = 1; i <= 3; i++)
            {
                string L1 = R0;
                string expandR0 = GiaiThuatTinyDES.Expand(R0);
                string KL1;
                string KR1;
                if (i == 2)
                {
                    KL1 = GiaiThuatTinyDES.DichVong(KL0, 2);
                    KR1 = GiaiThuatTinyDES.DichVong(KR0, 2);
                }
                else
                {
                    KL1 = GiaiThuatTinyDES.DichVong(KL0, 1);
                    KR1 = GiaiThuatTinyDES.DichVong(KR0, 1);
                }
                string K1 = GiaiThuatTinyDES.Compress(KL1, KR1);
                string expandR0xorK1 = GiaiThuatTinyDES.Xor2Chuoi(expandR0, K1);
                string sbox = GiaiThuatTinyDES.Sbox(expandR0xorK1);
                string F1 = GiaiThuatTinyDES.Pbox(sbox);
                string R1 = GiaiThuatTinyDES.Xor2Chuoi(L0, F1);
                L0 = L1;
                R0 = R1;
                KL0 = KL1;
                KR0 = KR1;
                C = L1 + R1;
            }
            string ketqua = C;
            chuoinhiphan = tam;
            khoa = khoanhapvao;
            KL0 = khoa.Substring(0, 4);
            KR0 = khoa.Substring(4);
            L0 = chuoinhiphan.Substring(0, 4);
            R0 = chuoinhiphan.Substring(4);
            C = "";
            //Vòng 1
            for (int i = 1; i <= 3; i++)
            {
                string L1 = R0;
                string expandR0 = GiaiThuatTinyDES.Expand(R0);
                string KL1;
                string KR1;
                if (i == 2)
                {
                    KL1 = GiaiThuatTinyDES.DichVong(KL0, 2);
                    KR1 = GiaiThuatTinyDES.DichVong(KR0, 2);
                }
                else
                {
                    KL1 = GiaiThuatTinyDES.DichVong(KL0, 1);
                    KR1 = GiaiThuatTinyDES.DichVong(KR0, 1);
                }
                string K1 = GiaiThuatTinyDES.Compress(KL1, KR1);
                string expandR0xorK1 = GiaiThuatTinyDES.Xor2Chuoi(expandR0, K1);
                string sbox = GiaiThuatTinyDES.Sbox(expandR0xorK1);
                string F1 = GiaiThuatTinyDES.Pbox(sbox);
                string R1 = GiaiThuatTinyDES.Xor2Chuoi(L0, F1);
                L0 = L1;
                R0 = R1;
                KL0 = KL1;
                KR0 = KR1;
                C = L1 + R1;
            }
            ketqua = ketqua + C;
            int soketquagiaima = Convert.ToInt32(ketqua, 2);
            char kituketqua = Convert.ToChar(soketquagiaima);
            return kituketqua.ToString();
        }
        public static string MaHoaTinyDES(char charcanmahoa, string khoanhapvao)
        {
            char kitucanmahoa = charcanmahoa;
            int sodecima = Convert.ToInt32(charcanmahoa);
            string chuoinhiphan = Convert.ToString(sodecima, 2);
            chuoinhiphan = ChuyenThanhDecima8KiTu(chuoinhiphan);
            string khoa = khoanhapvao;
            string KL0 = khoa.Substring(0, 4);
            string KR0 = khoa.Substring(4);
            string L0 = chuoinhiphan.Substring(0, 4);
            string R0 = chuoinhiphan.Substring(4);
            string C = "";
            //Vòng 1
            for (int i = 1; i <= 3; i++)
            {
                string L1 = R0;
                string expandR0 = GiaiThuatTinyDES.Expand(R0);
                string KL1;
                string KR1;
                if (i == 2)
                {
                    KL1 = GiaiThuatTinyDES.DichVong(KL0, 2);
                    KR1 = GiaiThuatTinyDES.DichVong(KR0, 2);
                }
                else
                {
                    KL1 = GiaiThuatTinyDES.DichVong(KL0, 1);
                    KR1 = GiaiThuatTinyDES.DichVong(KR0, 1);
                }
                string K1 = GiaiThuatTinyDES.Compress(KL1, KR1);
                string expandR0xorK1 = GiaiThuatTinyDES.Xor2Chuoi(expandR0, K1);
                string sbox = GiaiThuatTinyDES.Sbox(expandR0xorK1);
                string F1 = GiaiThuatTinyDES.Pbox(sbox);
                string R1 = GiaiThuatTinyDES.Xor2Chuoi(L0, F1);
                L0 = L1;
                R0 = R1;
                KL0 = KL1;
                KR0 = KR1;
                C = L1 + R1;
            }
            int soketqua = Convert.ToInt32(C, 2);
            char kituketqua = Convert.ToChar(soketqua);
            return kituketqua.ToString();
        }
        public static string MaHoaTinyDESTest(string chuoinhiphan, string khoanhapvao)
        {
            string khoa = khoanhapvao;
            string KL0 = khoa.Substring(0, 4);
            string KR0 = khoa.Substring(4);
            string L0 = chuoinhiphan.Substring(0, 4);
            string R0 = chuoinhiphan.Substring(4);
            string C = "";
            for (int i = 1; i <= 3; i++)
            {
                string L1 = R0;
                string expandR0 = GiaiThuatTinyDES.Expand(R0);
                string KL1;
                string KR1;
                if (i == 2)
                {
                    KL1 = GiaiThuatTinyDES.DichVong(KL0, 2);
                    KR1 = GiaiThuatTinyDES.DichVong(KR0, 2);
                }
                else
                {
                    KL1 = GiaiThuatTinyDES.DichVong(KL0, 1);
                    KR1 = GiaiThuatTinyDES.DichVong(KR0, 1);
                }
                string K1 = GiaiThuatTinyDES.Compress(KL1, KR1);
                string expandR0xorK1 = GiaiThuatTinyDES.Xor2Chuoi(expandR0, K1);
                string sbox = GiaiThuatTinyDES.Sbox(expandR0xorK1);
                string F1 = GiaiThuatTinyDES.Pbox(sbox);
                string R1 = GiaiThuatTinyDES.Xor2Chuoi(L0, F1);
                L0 = L1;
                R0 = R1;
                KL0 = KL1;
                KR0 = KR1;
                C = L1 + R1;
            }
            return C;
        }

        public static string GiaiMaTinyDesTest(string chuoinhiphan, string khoanhapvao)
        {
            string khoa = khoanhapvao;
            string L3 = chuoinhiphan.Substring(0, 4);
            string R3 = chuoinhiphan.Substring(4);
            string KL3 = khoa.Substring(0, 4);
            string KR3 = khoa.Substring(4);
            string P = "";
            //Giải mã
            for (int i = 1; i <= 3; i++)
            {
                string R2 = L3;
                string KL2, KR2;
                string expandR2 = GiaiThuatTinyDES.Expand(R2);
                if (i == 2)
                {
                    KL2 = GiaiThuatTinyDES.DichVongTruoc(KL3, 2);
                    KR2 = GiaiThuatTinyDES.DichVongTruoc(KR3, 2);
                }
                else
                {
                    KL2 = GiaiThuatTinyDES.DichVongTruoc(KL3, 1);
                    KR2 = GiaiThuatTinyDES.DichVongTruoc(KR3, 1);
                }
                string K3 = GiaiThuatTinyDES.Compress(KL3, KR3);
                string xorexpandR2K3 = GiaiThuatTinyDES.Xor2Chuoi(expandR2, K3);
                string sbox = GiaiThuatTinyDES.Sbox(xorexpandR2K3);
                string F3 = GiaiThuatTinyDES.Pbox(sbox);
                string L2 = GiaiThuatTinyDES.Xor2Chuoi(R3, F3);
                P = L2 + R2;
                L3 = L2;
                R3 = R2;
                KL3 = KL2;
                KR3 = KR2;
            }
            return P;
        }
    }
}
