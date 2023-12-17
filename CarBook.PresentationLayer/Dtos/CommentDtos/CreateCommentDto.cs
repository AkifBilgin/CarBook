using CarBook.EntityLayer.Concrete;

namespace CarBook.PresentationLayer.Dtos.CommentDtos
{
    public class CreateCommentDto
    {
        public string NameSurname { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CarID { get; set; }
    }
}
