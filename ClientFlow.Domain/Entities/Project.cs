using ClientFlow.Domain.Common;
using ClientFlow.Domain.Enums;

namespace ClientFlow.Domain.Entities;

public class Project : EntityBase
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public ProjectStatus Status { get; set; }
    public decimal Budget { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; set; }
}
