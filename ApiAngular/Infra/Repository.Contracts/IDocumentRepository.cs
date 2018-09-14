using ApiAngular.Models;
using System;
using System.Collections.Generic;

namespace ApiAngular.Infra.Repository.Contracts
{
    public interface IDocumentRepository : IRepositoryBase<Document>
    {
        List<Document> GetByFilters(Guid? id, string description, string initials, int? status);
    }
}