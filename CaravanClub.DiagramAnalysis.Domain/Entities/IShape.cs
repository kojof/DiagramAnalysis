namespace CaravanClub.DiagramAnalysis.Domain.Entities
{
    public interface IShape
    {
        decimal Height { get; set; }
        decimal Width { get; set; }

        decimal Area { get; }
    }
}
