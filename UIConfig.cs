using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace modul8_1302220131.UIConfig
{
    using System.IO;
    using System.Text.Json.Serialization;
    using modul8_1302220131.BankTransferConfig;
    internal class UIConfig
    {
        public BankTransferConfig config;
        public const String filePath = @"bank_transfer_confiig.json";
        public UIConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                addConfig();
                WriteNewConfigFile();
            }
        }
        public BankTransferConfig ReadConfigFile()
        {
            String path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            String jsonString = File.ReadAllText(path +"\\"+filePath);
            this.config = JsonConvert.DeserializeObject<BankTransferConfig>(jsonString);
            return this.config;
        }

        public void addConfig()
        {
            Console.WriteLine("Please insert language :");
            config.lang = Console.ReadLine();
            switch (config.lang)
            {
                case "en":
                    Console.WriteLine("Please Insert fee :");
                    int fee = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(this.config);
                    if (fee < config.transfer.threshold)
                    {
                        Console.WriteLine("total payment is a" + fee + config.transfer.low_fee);
                    }
                    else
                    {
                        Console.WriteLine("total payment is a" + fee + config.transfer.high_fee);
                    }
                    Console.WriteLine("Please Select transfer method :");
                    Console.WriteLine("1. RTO");
                    Console.WriteLine("2. SKN");
                    Console.WriteLine("3. RIGS");
                    Console.WriteLine("4. BI FAST");
                    Console.WriteLine("input :");
                    String input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("You have selected RTO");
                            this.config.methods = "RTO";
                            break;
                        case "2":
                            Console.WriteLine("You have selected SKN");
                            this.config.methods = "SKN";
                            break;
                        case "3":
                            Console.WriteLine("You have selected RIGS");
                            this.config.methods = "RIGS";
                            break;
                        case "4":
                            Console.WriteLine("You have selected BI FAST");
                            this.config.methods = "BI FAST";
                            break;
                        default:
                            Console.WriteLine("Method not supported");
                            break;
                    }
                    Console.WriteLine("Please type \"<CONFIG6>\" to confirm the transaction :");
                    String input1 = Console.ReadLine();
                    if (input1 == "<CONFIG6>")
                    {
                        this.config.confirmation.en = "Transaction confirmed";
                        Console.WriteLine("Transaction confirmed");
                    }
                    else
                    {
                        this.config.confirmation.en = "Transaction canceled";
                        Console.WriteLine("Transaction canceled");
                    }
                    break;
                case "id":
                    Console.WriteLine("Masukkan pembayaran :");
                    int pembayaran = Convert.ToInt32(Console.ReadLine());
                    if (pembayaran < config.transfer.threshold)
                    {
                        Console.WriteLine("total pembayaran adalah " + pembayaran + config.transfer.low_fee);
                    }
                    else
                    {
                        Console.WriteLine("total pembayaran adalah " + pembayaran + config.transfer.high_fee);
                    }
                    Console.WriteLine("Pilih metode transfer :");
                    Console.WriteLine("1. RTO");
                    Console.WriteLine("2. SKN");
                    Console.WriteLine("3. RIGS");
                    Console.WriteLine("4. BI FAST");
                    Console.WriteLine("input :");
                    String input2 = Console.ReadLine();
                    switch (input2)
                    {
                        case "1":
                            Console.WriteLine("Anda telah memilih RTO");
                            this.config.methods = "RTO";
                            break;
                        case "2":
                            Console.WriteLine("Anda telah memilih SKN");
                            this.config.methods = "SKN";
                            break;
                        case "3":
                            Console.WriteLine("Anda telah memilih RIGS");
                            this.config.methods = "RIGS";
                            break;
                        case "4":
                            Console.WriteLine("Anda telah memilih BI FAST");
                            this.config.methods = "BI FAST";
                            break;
                        default:
                            Console.WriteLine("Method tidak didukung");
                            break;
                    }
                    Console.WriteLine("Silahkan ketik \"<CONFIG7>\" untuk konfirmasi transaksi :");
                    String input3 = Console.ReadLine();
                    if (input3 == "<CONFIG7>")
                    {
                        this.config.confirmation.id = "Transaksi berhasil";
                        Console.WriteLine("Transaksi berhasil");
                    }
                    else
                    {
                        this.config.confirmation.id = "Transaksi dibatalkna";
                        Console.WriteLine("Transaksi dibatalkan");
                    }
                    break;
                default:
                    Console.WriteLine("Language not supported");
                    break;
            }
            this.WriteNewConfigFile();
        }
        private void SetDefault()
        {

        }
        private void WriteNewConfigFile()
        {
            String path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            Console.WriteLine(this.config);
            String jsonString = JsonConvert.SerializeObject(this.config);
            File.WriteAllText(path + "\\" + filePath, jsonString);
        }
    }
}