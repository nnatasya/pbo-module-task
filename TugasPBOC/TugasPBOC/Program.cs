
//karyawan: nama, gaji, kerja(), infoKaryawan()
//tetap (mewarisi karyawan) : tunjangan, HitungGajiTotal()
//kontrak (mewarisi karyawan) : durasi, CekKontrak()
//manager dan staff (mewarisi tetap) : memimpin(), kerjakanTugas()
//magang dan freelance (mewarisi kontrak) : belajar(), ambilProyek()
//perusahaan: koleksi karyawan, TambahKaryawan(), daftarKaryawan()
//override kerja() di setiap class

using System;
using System.Diagnostics.Contracts;

public abstract class Karyawan
{
    public string nama;
    public double gaji;
    
    public Karyawan (string nama, double gaji){
        this.nama = nama;
        this.gaji = gaji;
    }

    public virtual void Kerja()
    {
        Console.WriteLine($"Karyawan atas nama {nama} sedang bekerja");
    }

    public void InfoKaryawan()
    {
        Console.WriteLine($"NAMA : {nama}\nGAJI : {gaji}");
    }
}

public class Tetap : Karyawan
{
    public double tunjangan;

    public Tetap(string nama, double gaji, double tunjangan) : base(nama, gaji)
    {
        this.tunjangan = tunjangan;
    }

    public override void Kerja()
    {
        Console.WriteLine($"Karyawan tetap atas nama {nama} sedang bekerja");
    }

    public void HitungGajiTotal()
    {
        Console.WriteLine($"Total gaji (gaji + tunjangan) : {gaji+tunjangan}");
    }
}

public class Manager : Tetap
{

    public Manager(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan)
    {

    }

    public override void Kerja()
    {
        Console.WriteLine($"Manager atas nama {nama} sedang meninjau kerja tim");
    }

    public void Memimpin()
    {
        Console.WriteLine($"Manager {nama} memimpin rapat divisi");
    }
}

public class Staff : Tetap
{

    public Staff(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan)
    {

    }

    public override void Kerja()
    {
        Console.WriteLine($"Staff atas nama {nama} sedang mengerjakan tugas harian");
    }
    public void KerjakanTugas()
    {
        Console.WriteLine($"Staff {nama} sedang menyelesaikan daily report");
    }
}

public class Kontrak : Karyawan
{
    public int durasi;

    public Kontrak(string nama, double gaji, int durasi) : base(nama, gaji) 
    { 
        this.durasi = durasi;
    }

    public override void Kerja()
    {
        Console.WriteLine($"Karyawan kontrak atas nama {nama} sedang bekerja");
    }

    public void CekKontrak()
    {
        Console.WriteLine($"Sisa kontrak : {durasi}");
    }
}



public class Magang : Kontrak
{

    public Magang(string nama, double gaji, int durasi) : base(nama, gaji, durasi)
    {

    }

    public override void Kerja()
    {
        Console.WriteLine($"Karyawan magang atas nama {nama} sedang membantu senior");
    }

    public void Belajar()
    {
        Console.WriteLine($"Karyawan magang {nama} sedang mempelajari alur kerja perusahaan");
    }
}

public class Freelance : Kontrak
{

    public Freelance(string nama, double gaji, int durasi) : base(nama, gaji, durasi)
    {

    }

    public override void Kerja()
    {
        Console.WriteLine($"Freelance atas nama {nama} sedang bekerja secara remote");
    }
    public void AmbilProyek()
    {
        Console.WriteLine($"Freelance {nama} dilibatkan dalam proyek baru");
    }
}

public class Perusahaan
{
    private List<Karyawan> daftarKaryawan = new List<Karyawan>();
    public void TambahKaryawan (Karyawan karyawan)
    {
        daftarKaryawan.Add(karyawan);
        Console.WriteLine($"{karyawan.nama} berhasil ditambahkan ke dalam perusahaan");
    }

    public void DaftarKaryawan()
    {
        Console.WriteLine("=== DAFTAR SEMUA KARYAWAN ===");
        foreach (var k in daftarKaryawan)
        {
            k.InfoKaryawan();
            k.Kerja();
            Console.WriteLine("------------------------");
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Perusahaan PT = new Perusahaan();
        Manager mng = new Manager("tenxi", 10000000, 2500000);
        Staff stf = new Staff("budi", 6000000, 1000000);
        Magang mg = new Magang("dela", 3000000, 4);
        Freelance fl = new Freelance("andra", 5500000, 2);
        Console.WriteLine(" ");

        PT.TambahKaryawan(mng);
        PT.TambahKaryawan(stf);
        PT.TambahKaryawan(mg);
        PT.TambahKaryawan(fl);

        Console.WriteLine("\nINFO PERUSAHAAN DAN KARYAWAN\n");
        PT.DaftarKaryawan();

        Console.WriteLine("\nDETAIL KARYAWAN");

        mng.InfoKaryawan();
        mng.Memimpin();
        mng.HitungGajiTotal();

        Console.WriteLine(" ");
        stf.InfoKaryawan();
        stf.KerjakanTugas();
        stf.HitungGajiTotal();

        Console.WriteLine(" ");
        mg.InfoKaryawan();
        mg.Belajar();
        mg.CekKontrak();

        Console.WriteLine(" ");
        fl.InfoKaryawan();
        fl.AmbilProyek();
        fl.CekKontrak();

        Console.WriteLine("\nSOAL 1 : jalankan method kerja pada manager dan freelance");
        Console.WriteLine(" ");
        mng.Kerja();
        fl.Kerja();

        Console.WriteLine("\nSOAL 2 : jalankan method memimpin manager");
        mng.Memimpin();

        Console.WriteLine("\nSOAL 3 : panggil nama, gaji, tunjangan manager");
        mng.InfoKaryawan();
        Console.WriteLine($"Tunjangan : {mng.tunjangan}");

        Console.WriteLine("\nSOAL 4 : jalankan method belajar magang");
        mg.Belajar();

        Console.WriteLine("\nSOAL 5 : variabel karyawan, object staff, method kerja");
        Karyawan coba = new Staff("nat", 70000000, 1500000);
        coba.Kerja();

        Console.ReadLine();

    }
}
