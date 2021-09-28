using System;
using WebRestaurantes.Domain;

namespace WebRestaurantes.WebAPI
{
    public class DomainValueDto
    {
         public Guid Id { get; set; }

        public int DomainId { get; set; }

        public string Description { get; set; }
        public string Value { get; set; }        
    }
}