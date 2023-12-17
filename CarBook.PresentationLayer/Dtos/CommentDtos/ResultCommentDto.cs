using CarBook.EntityLayer.Concrete;

namespace CarBook.PresentationLayer.Dtos.CommentDtos
{
    public class ResultCommentDto
    {
        public int CommentID { get; set; }
        public string NameSurname { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Car Car { get; set; }
    }
}
