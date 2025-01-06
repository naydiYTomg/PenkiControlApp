using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenkiControlApp.Core.InputModels
{
    public class OrderInputModel
    {
        public int Id { get; set; }
        public int Sum { get; set; }
        public int Date {  get; set; }
        public int UserId { get; set; }
        public int ClientId { get; set; }


    }
}
