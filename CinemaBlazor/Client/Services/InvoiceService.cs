using CinemaBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBlazor.Client.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly HttpClient httpClient;

        public InvoiceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
