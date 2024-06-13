namespace IG_Train.Domain.Entities;

public class ExerciseTypeEntity : BaseEntity<int>
{
    public ExerciseTypeEntity(int id, string name, string description)
        : base(id)
    {            
        Name = name;
        Description = description;
    }

    public string Name { get; set; }

    public string Description { get; set; }
}
