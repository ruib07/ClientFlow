namespace ClientFlow.Domain.Enums;

public enum ProjectStatus
{
    NotStarted,
    InProgress,
    Completed,
    OnHold,
    Cancelled
}

public enum InteractionType
{
    Call,
    Email,
    Meeting,
    FollowUp,
    Other
}