namespace Motor_Lounge.Entities.Helpers
{
    public class Information : Entity
    {
        public string Info { get; set; }

        public Information(string info)
        {
            Info = info;
        }

        public Information()
        { }
    }
}
