using System;
using System.Collections.Generic;

class Program
{
  static void Main()
  {
    var karyawanBergaji = new KaryawanBergaji("John", "Smith","111-11-1111", 800.00M);
    var karyawanPerjam = new KaryawanPerjam("Karen", "Price","222-22-2222", 16.75M, 40.0M);
    var komisiKaryawan = new KomisiKaryawan("Sue", "Jones","333-33-3333", 10000.00M, .06M);
    var karyawanDasarTambahKomisi =
    new KaryawanDasarTambahKomisi("Bob", "Lewis", "444-44-4444", 5000.00M, .04M, 300.00M);
    Console.WriteLine("Karyawan diproses secara individual:\n"); 
  
   Console.WriteLine($"{karyawanBergaji}\ndiperoleh: " + $"{karyawanBergaji.Earnings():C}\n");
   Console.WriteLine( $"{karyawanPerjam}\ndiperoleh: {karyawanPerjam.Earnings():C}\n");
   Console.WriteLine($"{komisiKaryawan}\ndiperoleh: " + $"{komisiKaryawan.Earnings():C}\n");
   Console.WriteLine($"{karyawanDasarTambahKomisi}\ndiperoleh: " + $"{karyawanDasarTambahKomisi.Earnings():C}\n");
   
   var karyawan = new List<Karyawan>() {karyawanBergaji,
   karyawanPerjam, komisiKaryawan, karyawanDasarTambahKomisi};
   Console.WriteLine("Karyawan diproses secara polimorfik:\n");
   
   foreach (var karyawanSekarang in karyawan)
   {
     Console.WriteLine(karyawanSekarang ); 
     if ( karyawanSekarang is KaryawanDasarTambahKomisi )
     {
       var pegawai = (KaryawanDasarTambahKomisi) karyawanSekarang;

       pegawai.GajiPokok *= 1.10M;
       Console.WriteLine("gaji pokok baru dengan kenaikan 10% adalah: " + $"{pegawai.GajiPokok:C}");
      }

      Console.WriteLine($"diperoleh: {karyawanSekarang.Earnings() :C}\n");
    }
    for (int j = 0; j < karyawan.Count; j++)
    { 
      Console.WriteLine( $"Karyawan {j} is a {karyawan[j].GetType() }");
    }
 }
}