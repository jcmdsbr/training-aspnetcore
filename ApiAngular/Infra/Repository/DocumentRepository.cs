using ApiAngular.Infra.Repository.Context;
using ApiAngular.Infra.Repository.Contracts;
using ApiAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiAngular.Infra.Repository
{
    public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
    {
        public DocumentRepository(ApiAngularContext angularContext) : base(angularContext)
        {
        }

        public List<Document> GetByFilters(Guid? id, string description, string initials, int? status)
        {
            return ApiAngularContext.Documents
                .Where(x => id == null || x.Id == id)
                .Where(x => string.IsNullOrEmpty(description) || x.Description.Contains(description))
                .Where(x => string.IsNullOrEmpty(initials) || x.Initials.Contains(initials))
                .Where(x => status == null || (int)x.Status == status).ToList();
        }
    }
}