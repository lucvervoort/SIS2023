using System.ComponentModel.DataAnnotations;

namespace SIS.API.DTO
{
    public class RubricInstanceDTO
    {
        [Range(1, int.MaxValue)]
        public int RubricInstanceId { get; set; }

        [Range(1, int.MaxValue)]
        public int AuthorPersonId { get; set; }

        [Range(1, int.MaxValue)]
        public int RubricId { get; set; }

        [Range(1, int.MaxValue)]
        public int ScorePersonId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeCreation { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AutoTimeUpdate { get; set; }

        [Range(0, int.MaxValue)]
        public int AutoUpdateCount { get; set; }

        public bool IsDeleted { get; set; }

        public PersonDTO AuthorPerson { get; set; } 
        public RubricDTO Rubric { get; set; } 
        public ICollection<RubricInstanceScoreDTO> RubricInstanceScores { get; set; } 
        public PersonDTO ScorePerson { get; set; } 
    }
}
