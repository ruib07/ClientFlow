using ClientFlow.Domain.Common;
using ClientFlow.Domain.Enums;

namespace ClientFlow.Domain.Entities;

public class Interaction : EntityBase
{
    public InteractionType Type { get; set; }
    public DateTime Date { get; set; }
    public string Notes { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; set; }
}
