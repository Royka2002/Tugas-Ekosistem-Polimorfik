using System;
using System.Collections.Generic;

namespace EkosistemKaryawan
{
abstract class Karyawan
{
protected string nama;
protected double gajiPokok;

public Karyawan(string nama, double gajiPokok)
{
this.nama = nama;
this.gajiPokok = gajiPokok;
}

public string Nama
{
get { return nama; }
}

public abstract double HitungGajiAkhir();

public abstract void TampilkanTugas();
}

class Manager : Karyawan
{
private double tunjanganJabatan;

public Manager(string nama, double gajiPokok, double tunjanganJabatan)
: base(nama, gajiPokok)
{
this.tunjanganJabatan = tunjanganJabatan;
}

public override double HitungGajiAkhir()
{
return gajiPokok + tunjanganJabatan;
}

public override void TampilkanTugas()
{
Console.WriteLine(nama + " (Manager) sedang memimpin rapat lane kaizen");
}
}

class StaffIT : Karyawan
{
private int jumlahProjectSelesai;

public StaffIT(string nama, double gajiPokok, int jumlahProjectSelesai)
: base(nama, gajiPokok)
{
this.jumlahProjectSelesai = jumlahProjectSelesai;
}

public override double HitungGajiAkhir()
{
double bonusProject = jumlahProjectSelesai * 150000;
return gajiPokok + bonusProject;
}

public override void TampilkanTugas()
{
Console.WriteLine(nama + " (Staff IT) sedang memperbaiki bug pada sistem server");
}
}

class SalesMarketing : Karyawan
{
private double totalPenjualan;
private double persenKomisi;

public SalesMarketing(string nama, double gajiPokok, double totalPenjualan, double persenKomisi)
: base(nama, gajiPokok)
{
this.totalPenjualan = totalPenjualan;
this.persenKomisi = persenKomisi;
}

public override double HitungGajiAkhir()
{
double komisi = totalPenjualan * (persenKomisi / 100);
return gajiPokok + komisi;
}

public override void TampilkanTugas()
{
Console.WriteLine(nama + " (Sales & Marketing) sedang menghubungi klien untuk endorse PT");
}
}

class Program
{
static List<Karyawan> daftarKaryawan = new List<Karyawan>();

static void Main(string[] args)
{
daftarKaryawan.Add(new Manager("Jokowi", 8000000, 2500000));
daftarKaryawan.Add(new StaffIT("Benjamin Netanyahu", 5500000, 4));
daftarKaryawan.Add(new SalesMarketing("Prabowo Subianto", 4000000, 25000000, 5));

bool lanjut = true;

while (lanjut)
{
TampilkanMenu();
string pilihan = Console.ReadLine();

switch (pilihan)
{
case "1":
TampilkanSemuaKaryawan();
break;
case "2":
TambahManager();
break;
case "3":
TambahStaffIT();
break;
case "4":
TambahSales();
break;
case "5":
lanjut = false;
Console.WriteLine("Program selesai. Sampai jumpa.");
break;
default:
Console.WriteLine("Pilihan tidak dikenali, coba lagi.");
break;
}

if (lanjut)
{
Console.WriteLine("\nTekan enter untuk kembali ke menu...");
Console.ReadLine();
Console.Clear();
}
}
}

static void TampilkanMenu()
{
Console.WriteLine("========== PT. MAHAYA TOMOR ( DATA KARYAWAN ) ==========");
Console.WriteLine("1. Tampilkan semua data karyawan");
Console.WriteLine("2. Tambah data Manager");
Console.WriteLine("3. Tambah data Staff IT");
Console.WriteLine("4. Tambah data Sales & Marketing");
Console.WriteLine("5. Keluar");
Console.WriteLine("==============================================");
Console.Write("Pilih menu (1-5): ");
}

static void TampilkanSemuaKaryawan()
{
Console.WriteLine("\n=== Laporan Kegiatan dan Gaji Karyawan ===\n");

foreach (Karyawan k in daftarKaryawan)
{
k.TampilkanTugas();
Console.WriteLine("Gaji akhir " + k.Nama + ": Rp" + k.HitungGajiAkhir().ToString("N0"));
Console.WriteLine();
}

Console.WriteLine("Total karyawan dalam list: " + daftarKaryawan.Count);
}

static void TambahManager()
{
Console.Write("\nNama Manager: ");
string nama = Console.ReadLine();
Console.Write("Gaji pokok: ");
double gaji = Convert.ToDouble(Console.ReadLine());
Console.Write("Tunjangan jabatan: ");
double tunjangan = Convert.ToDouble(Console.ReadLine());

daftarKaryawan.Add(new Manager(nama, gaji, tunjangan));
Console.WriteLine("Data Manager berhasil ditambahkan.");
}

static void TambahStaffIT()
{
Console.Write("\nNama Staff IT: ");
string nama = Console.ReadLine();
Console.Write("Gaji pokok: ");
double gaji = Convert.ToDouble(Console.ReadLine());
Console.Write("Jumlah project selesai: ");
int project = Convert.ToInt32(Console.ReadLine());

daftarKaryawan.Add(new StaffIT(nama, gaji, project));
Console.WriteLine("Data Staff IT berhasil ditambahkan.");
}

static void TambahSales()
{
Console.Write("\nNama Sales & Marketing: ");
string nama = Console.ReadLine();
Console.Write("Gaji pokok: ");
double gaji = Convert.ToDouble(Console.ReadLine());
Console.Write("Total penjualan: ");
double penjualan = Convert.ToDouble(Console.ReadLine());
Console.Write("Persen komisi: ");
double komisi = Convert.ToDouble(Console.ReadLine());

daftarKaryawan.Add(new SalesMarketing(nama, gaji, penjualan, komisi));
Console.WriteLine("Data Sales & Marketing berhasil ditambahkan.");
}
}
}