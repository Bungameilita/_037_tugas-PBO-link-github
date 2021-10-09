using System;
public abstract class Karyawan 
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

public class KaryawanPerjam : Karyawan
{
  private decimal upah; 
 private decimal jam; 

 
 public KaryawanPerjam(string namaDepan, string namaBelakang,
   string nomorKTP, decimal upahPerjam,
   decimal jamKerja)
   : base(namaDepan, namaBelakang, nomorKTP)
 {
    Upah = upahPerjam; 
    Jam = jamKerja; 
 }

 
 public decimal Upah
 {
    get
   {
     return upah;
   }
   set
   {
     if (value < 0) 
     {
        throw new ArgumentOutOfRangeException(nameof(value),
        value, $"{nameof(Upah)} must be >= 0");
     }

     upah = value;
   }
  } 
  
 public decimal Jam
 {
    get
    {
      return jam;
    }
   set
   {
     if (value < 0 || value > 168) 
     {
       throw new ArgumentOutOfRangeException(nameof(value),
       value, $"{nameof(Jam)} must be >= 0 and <= 168");
     }

     jam = value;
   }
  }
  public override decimal Earnings()
  {
    if (Jam <= 40) 
    {
      return Upah * Jam;
    }
    else
    {
      return (40 * Upah) + ((Jam - 40) * Upah * 1.5M);
    }
 }
 
 public override string ToString() =>
  $"hourly employee: {base.ToString()}\n" +
  $"hourly wage: {Upah:C}\nhours worked: {Jam :F2}";
}

public class KomisiKaryawan : Karyawan
{
  private decimal penjualanKotor; 
  private decimal tingkatKomisi; 

  public KomisiKaryawan(string namaDepan, string namaBelakang,string nomorKTP, decimal penjualanKotor,
  decimal tingkatKomisi)
  : base(namaDepan, namaBelakang, nomorKTP)
  {
    PenjualanKotor = penjualanKotor; 
    TingkatKomisi = tingkatKomisi; 
  }

  public decimal PenjualanKotor
  {
    get
    {
      return penjualanKotor;
    }
    set
    {
      if (value < 0) 
      {
        throw new ArgumentOutOfRangeException(nameof(value),
        value, $"{nameof(PenjualanKotor)} must be >= 0");
      }

     penjualanKotor = value;
    }
  }
 
  public decimal TingkatKomisi
  {
    get
    {
      return tingkatKomisi;
    }
    set
    {
      if (value <= 0 || value >= 1) 
      {
        throw new ArgumentOutOfRangeException(nameof(value),
        value, $"{nameof(TingkatKomisi)} must be > 0 and < 1");
      }

     tingkatKomisi = value;
    }
  }

 public override decimal Earnings()=> TingkatKomisi * PenjualanKotor;
 public override string ToString() =>
  $"komisi karyawan: {base.ToString()}\n" +
  $"penjualan kotor: {PenjualanKotor:C}\n" +
  $"tingkat komisi: {TingkatKomisi:F2}";
}

public class KaryawanDasarTambahKomisi : KomisiKaryawan
{
  private decimal gajiPokok; 
  public KaryawanDasarTambahKomisi(string namaDepan, string namaBelakang,string nomorKTP, decimal penjualanKotor,
  decimal tingkatKomisi, decimal gajiPokok)
  : base(namaDepan, namaBelakang, nomorKTP,
  penjualanKotor, tingkatKomisi)
  {
    GajiPokok = gajiPokok; 
  }

  public decimal GajiPokok
  {
    get
    {
      return gajiPokok;
    }
    set
    {
      if (value < 0) 
      {
        throw new ArgumentOutOfRangeException(nameof(value),
        value, $"{nameof(GajiPokok)} must be >= 0");
      }

     gajiPokok = value;
    }
  }

  
  public override decimal Earnings()=> GajiPokok + base.Earnings();

  public override string ToString()=>
    $"base-salaried {base.ToString()}\nbase salary: {GajiPokok:C}";
}

 