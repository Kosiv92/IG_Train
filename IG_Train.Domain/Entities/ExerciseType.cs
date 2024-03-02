﻿
namespace IG_Train.Domain.Entities
{
    public class ExerciseType
    {
        const int MIN_NAME_LENGTH = 3;
        const int MAX_NAME_LENGTH = 100;
        const int MAX_DESCRIPTION_LENGTH = 400;

        public ExerciseType(string name, string description)
        {            
            Name = name;
            Description = description;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public static (string error, ExerciseType exerciseType) Create(string name, string description)
        {
            string error = string.Empty;

            if(string.IsNullOrEmpty(name) 
                || name.Length < MIN_NAME_LENGTH 
                || name.Length > MAX_NAME_LENGTH)
            {
                error = "The length of the name must be in the range of 3-100 characters";
            }
            if (!string.IsNullOrEmpty(description)
                && name.Length < MAX_DESCRIPTION_LENGTH)
            {
                error += "\nThe length of the description can not be longer then 400 characters";
            }

            ExerciseType exerciseType = new ExerciseType(name, description);

            return (error, exerciseType);
        }

    }
}
