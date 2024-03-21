namespace IG_Train.Domain.Entities;

public class ExerciseTypeEntity : BaseEntity<int>
{
    public ExerciseTypeEntity(int id, string name, string description)
        : base(id)
    {            
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }
}
