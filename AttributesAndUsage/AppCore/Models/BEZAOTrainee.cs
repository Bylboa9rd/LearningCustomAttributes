using ValidationComponent_.CustomAttributes;

namespace AppCore.Models
{
    [Document(Description = "A Software Engineering Trainee.")]
    public class BEZAOTrainee
    {
        [Required]
        [Document(Description = "This sets and gets the trainee's full name.")]
        public string FullName { get; private set; }


        [Document(Description = "This sets and gets the trainee's age.")]
        public int Age { get; set; }


        [Document(Description = "This initializes the BEZAOTrainee with a full name.", Input = "It takes a full name as string.")]
        public BEZAOTrainee(string fullName)
        {
            FullName = fullName;

        }

        [Document(Description = "BEZAOTrainee's default constructor")]
        public BEZAOTrainee() { }

        [Document(Description = "This makes the trainee quiet when something strange happens.", Input = "It takes in a someThingStrange as an object.")]
        public void Quiet(object someThingStrange)
        {
            //maintaining silence
        }

        [Document(Description = "This makes the trainee code when an idea comes.", Input = "It takes in a someThingStrange as an object.", Output = "It returns an object.")]
        public object Code(object someIdea)
        {
            return someIdea;
        }




        [Document(Description = "A software engineering training program.")]
        public class BEZAO
        {
            [Required]
            [Document(Description = "This sets and gets the BEZAO cohort.")]
            public string Cohort { get; private set; }

            [Document(Description = "This initializes BEZAO with a cohort.", Input = "It takes a cohort as a string.")]
            BEZAO(string cohort)
            {
                Cohort = cohort;
            }


        }

    }
    [Document(Description ="These are what trainees scream")]
    public enum Scream
    {
        Omo,
        HeyGod,
        GodAbeg,
        OhShit,
        Chukwunna,
        Haeeewwwww,
        GodWhen
    }
}
