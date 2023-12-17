using System;

class Program
{
    static void Main()
    {
        // Data barang
        string[] kodeItem = { "1", "2", "3", "4", "5" };
        string[] namaItem = { "Table", "Paper", "Envelopes", "Computer", "Book Cases" };
        double[] hargaItem = { 1000000, 50000, 15000, 7000000, 150000 };
        string[] discount = { "10%", "", "10%", "15%", "5%" };

        // Menampilkan header tabel
        Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-10} {4,-15} {5,-15}", "Kode Item", "Nama Item", "Harga", "Discount", "Nominal Diskon", "Harga Setelah Diskon");
        Console.WriteLine(new string('-', 80));

        // Menampilkan data barang
        for (int i = 0; i < kodeItem.Length; i++)
        {
            double diskon = 0;
            double hargaSetelahDiskon = 0;

            if (!string.IsNullOrEmpty(discount[i]))
            {
                diskon = Convert.ToDouble(discount[i].TrimEnd('%')) / 100;
                hargaSetelahDiskon = hargaItem[i] - (hargaItem[i] * diskon);
            }

            Console.WriteLine("{0,-10} {1,-15} {2,-15:C} {3,-10} {4,-15:C} {5,-15:C}", kodeItem[i], namaItem[i], hargaItem[i], discount[i], hargaItem[i] * diskon, hargaSetelahDiskon);
        }

        // Meminta pengguna memasukkan kode item
        Console.Write("Masukkan kode item yang diinginkan: ");
        string kodeInput = Console.ReadLine();

        // Mencari indeks item berdasarkan kode input
        int indeksItem = Array.IndexOf(kodeItem, kodeInput);

        // Menampilkan hasil jika kode input valid
        if (indeksItem != -1)
        {
            Console.WriteLine("\nAnda memilih item: {0} - {1}", kodeItem[indeksItem], namaItem[indeksItem]);
            Console.WriteLine("Harga Setelah Diskon: {0:C}", HitungHargaSetelahDiskon(hargaItem[indeksItem], discount[indeksItem]));
        }
        else
        {
            Console.WriteLine("\nKode item tidak valid.");
        }
    }

    // Fungsi untuk menghitung harga setelah diskon
    static double HitungHargaSetelahDiskon(double harga, string discount)
    {
        double diskon = 0;

        if (!string.IsNullOrEmpty(discount))
        {
            diskon = Convert.ToDouble(discount.TrimEnd('%')) / 100;
        }

        return harga - (harga * diskon);
    }
}
