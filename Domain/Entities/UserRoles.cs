namespace Domain.Entities
{
    /// <summary>
    /// czy zalogowany user jest administratorem
    /// </summary>
    public class UserRoles
    {
        public int UserRolesId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
