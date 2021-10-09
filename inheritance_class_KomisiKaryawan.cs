using System;

public class KomisiKaryawan 
{
  public string NamaDepan { get; }
  public string NamaBelakang { get; }
  public string NomorKTP { get; }
  private decimal penjualanKotor; 
  private decimal tingkatKomisi; 

  public KomisiKaryawan(string namaDepan, string namaBelakang,string nomorKTP, decimal penjualanKotor,
  decimal tingkatKomisi)
  {
    NamaDepan = namaDepan;
    NamaBelakang = namaBelakang;
    NomorKTP = nomorKTP;
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
        throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(PenjualanKotor)} must be >= 0");
      }
      penjualanKotor = value;
    }
  }
 
  public decimal TingkatKomisi
  {
    get
    {
      return tingkatKomisi ;
    }
    set
    {
      if (value <= 0 || value >= 1) 
      {
        throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(TingkatKomisi)} must be > 0 and < 1");
      }
      tingkatKomisi = value;
    }
  }
  
  public virtual decimal Earnings() => TingkatKomisi * PenjualanKotor;
  public override string ToString() =>
  $"Komisi Karyawan: {NamaDepan} {NamaBelakang}\n" + $"Noor KTP: {NomorKTP}\n" + $"Penjualan Kotor: { PenjualanKotor:C}\n" + $"Tingkat Komisi: {TingkatKomisi :F2}";
 
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

  public override decimal Earnings() => GajiPokok + base.Earnings();
  public override string ToString() => $"gaji pokok {base.ToString()}\ngaji pokok {GajiPokok:C}";
}

