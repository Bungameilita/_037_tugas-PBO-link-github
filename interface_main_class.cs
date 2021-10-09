using System;
using System.Collections.Generic;

class Program
{
  static void Main()
  {
    
    var objekHarusdibayar = new List<Harusdibayar>() {
    new Faktur("01234", "seat", 2, 375.00M),
    new Faktur("56789", "tire", 4, 79.95M),
    new KaryawanBergaji("John", "Smith", "111-11-1111", 800.00M),
    new KaryawanBergaji("Lisa", "Barnes", "888-88-8888", 1200.00M)};
    Console.WriteLine("Invoices and Employees processed polymorphically:\n");
    
    foreach (var hutang in objekHarusdibayar)
    {
      
       Console.WriteLine($"{hutang }");
       Console.WriteLine(
       $"tanggal jatuh tempo: { hutang.DapatkanJumlahPembayaran():C}\n");
    }
  }
}