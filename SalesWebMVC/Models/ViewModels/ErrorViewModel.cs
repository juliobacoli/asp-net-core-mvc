using System;

namespace SalesWebMVC.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; } //Id interno da requisição
        public string Message { get; set; } //Mensagem personalizada

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}