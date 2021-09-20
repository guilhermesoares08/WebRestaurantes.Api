using System;

namespace WebRestaurantes.Domain
{
    public class DomainValue
    {
        public Guid Id { get; set; }

        public int DomainId { get; set; }

        public string Description { get; set; }
        public string Value { get; set; }

        public Domain Domain { get; }
    }
}