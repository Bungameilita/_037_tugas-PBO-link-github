using System;
public interface Harusdibayar
{
  decimal DapatkanJumlahPembayaran();
}

public class Faktur : Harusdibayar
{
  public string NomorBagian { get; }
  public string DeskripsiBagian { get; }
  private int kuantitas;
  private decimal hargaPerBarang;

  
  public Faktur(string nomorBagian, string deskripsiBagian, int kuantitas, decimal hargaPerBarang)
  {
    NomorBagian = nomorBagian;
    DeskripsiBagian = deskripsiBagian;
    Kuantitas = kuantitas; 
    HargaPerBarang = hargaPerBarang; 
  }
  
  public int Kuantitas
  {
    get
    {
      return kuantitas;
    }
    set
    {
      if (value < 0) 
      {
        throw new ArgumentOutOfRangeException(nameof(value),
        value, $"{nameof(Kuantitas)} must be >= 0");
      }

     kuantitas = value;
     }
  }

  
  public decimal HargaPerBarang
  {
    get
    {
      return hargaPerBarang;
    }
    set
    {
      if (value < 0) 
      {
        throw new ArgumentOutOfRangeException(nameof(value),
        value, $"{nameof(HargaPerBarang)} must be >= 0");
       }

       hargaPerBarang = value;
    }
  }
  
  public override string ToString() =>
  $"faktur:\nnoor bagian: {NomorBagian} ({DeskripsiBagian})\n" + $"kuantitas: {Kuantitas}\nharga per barang: {HargaPerBarang:C}";
 
 public decimal DapatkanJumlahPembayaran() => Kuantitas * HargaPerBarang;
}

public abstract class Karyawan : Harusdibayar
{
  public string NamaDepan { get; }
  public string NamaBelakang { get; }
  public string NomorKTP { get; }

  
  public Karyawan(string namaDepan, string namaBelakang,
  string nomorKTP)
  {
    NamaDepan = namaDepan;
    NamaBelakang = namaBelakang;
    NomorKTP = nomorKTP;
  }
  
  public override string ToString() => $"{NamaDepan} {NamaBelakang}\n" + $"nomor KTP: {NomorKTP}";

  
  public abstract decimal Earnings(); 

  
  public decimal DapatkanJumlahPembayaran() =>Earnings();
}


public class KaryawanBergaji : Karyawan
{
 private decimal gajiMingguan;

  
 public KaryawanBergaji(string namaDepan, string namaBelakang,string nomorKTP, decimal gajiMingguan)
 : base(namaDepan, namaBelakang, nomorKTP)
 {
   GajiMingguan = gajiMingguan;  
 }
 
 public decimal GajiMingguan
 {
   get
   {
     return gajiMingguan;
   }
   set
   {
     if (value < 0)
     {
       throw new ArgumentOutOfRangeException(nameof(value),
       value, $"{nameof(GajiMingguan)} must be >= 0");
     }

     gajiMingguan = value;
    } 
  }
  
 public override decimal Earnings() => GajiMingguan;
 
 public override string ToString()=>
 $"salaried employee: {base.ToString()}\n" +
 $"weekly salary: {GajiMingguan:C}";
}
