namespace Abon.Database.Model.Portal
{
    public class UserSecret:ModelBase
    {
        public string Hash { get; set; }    

        public string Salt { get; set; }

        public virtual User User { get; set; }
    }
}
