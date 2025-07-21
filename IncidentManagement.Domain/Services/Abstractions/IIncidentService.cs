using IncidentManagement.Domain.Dtos.Incident;

namespace IncidentManagement.Domain.Services.Abstractions
{
    public interface IIncidentService
    {
        Task<IncidentDto> GetByNameAsync(string name, CancellationToken cancellationToken);
        Task<IncidentDto> UpdateAsync(UpdateIncidentDto dto, CancellationToken cancellationToken);
        Task DeleteAsync(DeleteIncidentDto dto, CancellationToken cancellationToken);
        Task<IncidentDto> HandleFullIncidentCreationAsync(CreateFullIncidentDto dto, CancellationToken cancellationToken);
    }
}
