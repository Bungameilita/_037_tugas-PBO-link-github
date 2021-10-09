using System;

class Program {
  public static void Main (string[] args) {
    var pegawai = new KomisiKaryawan("Sue", "Jones",
    "222-22-2222", 10000.00M, .06M);
    Console.WriteLine( "Informasi karyawan diperoleh dengan properti dan metode: \n");
    Console.WriteLine($" Nama Depan : {pegawai.NamaDepan}");
    Console.WriteLine($"Nama Belakang {pegawai.NamaBelakang}");
    Console.WriteLine($"Nomor KTP:  {pegawai.NomorKTP }");
    Console.WriteLine($"Penjualan kotor :{pegawai.PenjualanKotor :C}");
    Console.WriteLine($"Tingkat Komisi {pegawai.TingkatKomisi :F2}");
    Console.WriteLine($"Earnings are {pegawai.Earnings() :C}");
    Console.WriteLine("\nInformasi karyawan yang diperbarui diperoleh oleh ToString:\n");
    Console.WriteLine( pegawai);
    Console.WriteLine($"pendapatan: { pegawai.Earnings():C}");

    Console.WriteLine("===================================================");
    var karyawan = new KaryawanDasarTambahKomisi("Bob", "Lewis","333-33-3333", 5000.00M, .04M, 300.00M);
    Console.WriteLine("Informasi karyawan diperoleh dengan properti dan metode: \n");
    Console.WriteLine($"Nama Depan adalah {karyawan.NamaDepan }");
    Console.WriteLine($"Nama Belakang adalah {karyawan.NamaBelakang }");
    Console.WriteLine($"Nomor KTP adalah {karyawan.NomorKTP }");
    Console.WriteLine($"Penjualan kotor :  {karyawan.PenjualanKotor :C}");
    Console.WriteLine($"Tingkat Komisi:  { karyawan.TingkatKomisi:F2}");
    Console.WriteLine($"Earnings are {karyawan.Earnings() :C}");
    Console.WriteLine($"Gaji Pokok : {karyawan.GajiPokok:C}");
    Console.WriteLine( "\nInformasi karyawan yang diperbarui diperoleh oleh ToString:\n");
    Console.WriteLine(karyawan );
    Console.WriteLine($"pendapatan: { karyawan.Earnings():C}");
  
 
  }
}