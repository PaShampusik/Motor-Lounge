namespace Motor_Lounge.Entities.Helpers
{
    public class Photo
    {
        public List<string> Photos { get; set; }

        public Photo(List<string> photos)
        {
            Photos = photos;
        }

        public Photo() { }
    }
}
