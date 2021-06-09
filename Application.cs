using BEIS.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BEIS
{
    public interface IApplication
    {
        int RecordCount { get; }

        void FileExist(string file);
        void Load();
        void ValidateProducts();
        void DisplayProduct();

    }

    public  class Application : IApplication
    { 
        string _fileName;
        
        List<ProductDTO> _productDTOs;
        IEnumerable<Product> _productList;
        
        public int RecordCount => _productDTOs?.Count ?? 0;

        public void DisplayProduct()
        {
            Console.Write(ConsoleTables.ConsoleTable.From(_productList).ToMinimalString());
        }

        public void FileExist(string file)
        {
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "inputfolder", file);

            if (File.Exists(fileName))
                _fileName = fileName;
            else
            {
                throw new FileNotFoundException("File not found!");
            }
        }

        public void Load()
        {
            try
            {
                using (var reader = new StreamReader(_fileName))
                using (var csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    TrimOptions = TrimOptions.Trim,
                    IgnoreBlankLines = true
                }))
                {
                    _productDTOs = csvReader.GetRecords<ProductDTO>().ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: File cannot be read!");
                throw;
            }
        }

        public void ValidateProducts()
        {
            var productValid = new ProductValidator();
            _productList = _productDTOs.Select(x=> productValid.ConvertToProduct(x));
        }
    }
}