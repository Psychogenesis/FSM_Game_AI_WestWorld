using System.ComponentModel.DataAnnotations;

namespace FSMTest
{
    public enum EntityNameType
    {
        [Display(Name = "Miner Bob")]
        Miner,

        [Display(Name = "Elsa")]
        Wife
    }

    public class EntityType
    {
        public static string GetEntityName(int name)
        {
            switch((EntityNameType) name)
            {
                case EntityNameType.Miner:
                    return "Miner Bob";
                case EntityNameType.Wife:
                    return "Elsa";
                default:
                    return "UNKNOWN!";
            }
        }
    }
}
