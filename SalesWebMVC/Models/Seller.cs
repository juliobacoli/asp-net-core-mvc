using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; }

        [Display(Name = "Data de aniversário")] //Definição de labels personalizadas
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} é obrigatório")] // {0} pega o atributo automaricamento
        public DateTime BirthDate { get; set; }

        [Display(Name = "Salário Base")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Range(1.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")] //{1} primeiro valor e {2} segundo valor
        [DisplayFormat(DataFormatString = "{0:F2}")] //F2 indica 2 casas decimais
        public double BaseSalary { get; set; }

        public Department Department { get; set; }

        [Display(Name = "Id do Departamento")]
        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        internal static double Sum(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final) 
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
