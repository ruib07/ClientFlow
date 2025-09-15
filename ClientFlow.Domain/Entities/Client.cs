using ClientFlow.Domain.Common;

namespace ClientFlow.Domain.Entities;

public class Client : EntityBase
{
    public string Company { get; set; }
    public string Contact { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public ICollection<Project> Projects { get; set; } = new List<Project>();
    public ICollection<Interaction> Interactions { get; set; } = new List<Interaction>();
}
