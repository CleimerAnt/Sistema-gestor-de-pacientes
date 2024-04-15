

namespace SistemeGestorDePacientes.Core.Commons
{
    public class AuditableDaseEntity
    {
        public virtual int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LasModified { get; set; }
    }
}
